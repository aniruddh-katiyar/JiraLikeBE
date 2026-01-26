namespace JiraLike.Infrastructure.Ai
{
    using JiraLike.Application.Interfaces;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    public class AiService : IAiService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public AiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<string> Generate(string prompt)
        {
Console.WriteLine("=== AI CONFIG DEBUG ===");
Console.WriteLine($"RAW ENV Groq__ApiKey = {Environment.GetEnvironmentVariable("Groq__ApiKey")}");
Console.WriteLine($"RAW ENV Groq__Model  = {Environment.GetEnvironmentVariable("Groq__Model")}");
Console.WriteLine($"CONFIG Groq:ApiKey  = {_config["Groq:ApiKey"]}");
Console.WriteLine($"CONFIG Groq:Model   = {_config["Groq:Model"]}");
Console.WriteLine("=======================");
            var apiKey = _config["Groq:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
                return "LLM is not configured.";

            _http.DefaultRequestHeaders.Remove("Authorization");
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var body = new
            {
                model = _config["Groq:Model"]?.Trim(),
                messages = new[]
                {
            new { role = "user", content = prompt }
        },
                max_tokens = 300,
                temperature = 0.2
            };

            var content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json");

            var response = await _http.PostAsync(_config["Groq:BaseUrl"], content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Groq API error ({response.StatusCode}): {error}");
            }

            var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            return json.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString()!;
        }


    }
}
