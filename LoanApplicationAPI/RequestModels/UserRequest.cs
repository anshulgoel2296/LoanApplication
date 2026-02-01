using System.Text.Json.Serialization;

namespace LoanApplicationAPI.RequestModels
{
    public class UserRequest
    {
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("contactNumber")]
        public long? ContactNumber { get; set; }
    }
}
