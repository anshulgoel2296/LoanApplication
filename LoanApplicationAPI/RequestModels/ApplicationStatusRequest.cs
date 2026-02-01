using System.Text.Json.Serialization;

namespace LoanApplicationAPI.RequestModels
{
    public class ApplicationStatusRequest
    {
        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("isUpdateEnabled")]
        public bool IsUpdateEnabled { get; set; }
    }
}
