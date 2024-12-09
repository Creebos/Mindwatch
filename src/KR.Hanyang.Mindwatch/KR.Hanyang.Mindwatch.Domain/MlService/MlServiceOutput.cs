using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.MlService
{
    public class MlServiceOutput
    {
        [JsonPropertyName("prediction")]
        public required string Prediction { get; set; }
    }
}
