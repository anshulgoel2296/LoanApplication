using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanApplicationAPI.DBModels
{
    [Table("loan_types")]
    public class LoanType
    {
        [Column("loan_id")]
        [JsonPropertyName("loanId")]
        public int LoanId { get; set; }

        [Column("loan_code")]
        [JsonPropertyName("loanCode")]
        public string LoanCode { get; set; } = null!;

        [Column("description")]
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

}
