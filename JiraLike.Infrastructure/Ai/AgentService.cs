namespace JiraLike.Infrastructure.Ai
{
    using JiraLike.Application.Dtos.Ai;
    using JiraLike.Application.Interfaces;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http.Json;

    public class AgentService : IAgentService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public AgentService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<AgentResponseDto> AgentProcessingAsync(Guid id, string title, string description)
        {
          var response =  await  _http.PostAsJsonAsync("classfy", new {id,title, description });

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AgentResponseDto>();
                if(result is not null)
                return result;
            }
            return new AgentResponseDto();
        }
    }
}
