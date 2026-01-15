namespace JiraLike.Api.services
{
    using JiraLike.Application.Dtos;

    public class OllamaService
    {
        private readonly HttpClient _client;

        public OllamaService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> Generate(string prompt)
        {
            var response = await _client.PostAsJsonAsync(
                "http://localhost:11434/api/generate",
                new { model = "tinyllama", prompt, stream = false }
            );

            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();
            return result?.response ?? "No response from LLM";
        }
    }

}
