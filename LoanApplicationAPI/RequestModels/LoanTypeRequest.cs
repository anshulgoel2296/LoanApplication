using System.Text.Json.Serialization;

namespace LoanApplicationAPI.RequestModels
{
    public class LoanTypeRequest
    {
        [JsonPropertyName("loanCode")]
        public string LoanCode { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
