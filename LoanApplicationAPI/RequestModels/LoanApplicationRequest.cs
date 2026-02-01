using System.Text.Json.Serialization;

namespace LoanApplicationAPI.RequestModels
{
    public class LoanApplicationRequest
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("loanTypeId")]
        public int LoanTypeId { get; set; }

        [JsonPropertyName("currentStatusId")]
        public int CurrentStatusId { get; set; }

        [JsonPropertyName("id")]
        public int PreviousStatusId { get; set; }

        [JsonPropertyName("amount")]
        public decimal LoanAmount { get; set; }

    }
}
