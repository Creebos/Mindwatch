using System.Text.Json.Serialization;

namespace KR.Hanyang.Mindwatch.Domain.MlService
{
    public class MlServiceInput
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }
    }
}
