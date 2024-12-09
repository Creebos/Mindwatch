using KR.Hanyang.Mindwatch.Domain.MlService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Infrastructure.MlService
{
    public class MlService : IMlService
    {
        private readonly HttpClient _httpClient;

        public MlService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MlServiceOutput> PredictAsync(MlServiceInput input)
        {
            // Serialize the input to JSON
            var json = JsonSerializer.Serialize(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the AI model API
            var response = await _httpClient.PostAsync("/predict", content);

            // Ensure the response was successful
            response.EnsureSuccessStatusCode();

            // Deserialize the response content to the output DTO
            var responseContent = await response.Content.ReadAsStringAsync();
            var output = JsonSerializer.Deserialize<MlServiceOutput>(responseContent);

            return output;
        }
    }
}
