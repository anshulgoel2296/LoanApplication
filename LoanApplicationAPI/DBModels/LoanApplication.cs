using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanApplicationAPI.DBModels
{
    [Table("loan_applications")]
    public class LoanApplication
    {
        [Column("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("user_id")]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [Column("loan_type_id")]
        [JsonPropertyName("loanTypeId")]
        public int LoanTypeId { get; set; }

        [Column("current_status_id")]
        [JsonPropertyName("currentStatusId")]
        public int CurrentStatusId { get; set; }

        [Column("previous_status_id")]
        [JsonPropertyName("id")]
        public int PreviousStatusId { get; set; }

        [Column("loan_amount")]
        [JsonPropertyName("amount")]
        public decimal LoanAmount { get; set; }

        [Column("created_datetime")]
        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("updated_datetime")]
        [JsonPropertyName("updatedDateTime")]
        public DateTime UpdatedDateTime { get; set; }

    }

}
