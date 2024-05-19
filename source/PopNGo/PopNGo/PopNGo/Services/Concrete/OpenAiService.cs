using System.Text.Json;
using System.Text.Json.Serialization;
using PopNGo.Models;

namespace PopNGo.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OpenAiService> _logger;

        public OpenAiService(HttpClient httpClient, ILogger<OpenAiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<string> FindMostRelevantWordFromString(string description)
        {
            throw new NotImplementedException();
        }
    }
}
