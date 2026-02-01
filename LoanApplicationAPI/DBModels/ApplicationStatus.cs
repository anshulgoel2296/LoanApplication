using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanApplicationAPI.DBModels
{
    [Table("application_status", Schema = "dbo")]
    public class ApplicationStatus
    {
        [Key]
        [Column("status_id")]
        [JsonPropertyName("statusId")]
        public int StatusId { get; set; }

        [Column("status_code")]
        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; } = null!;

        [Column("description")]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [Column("is_update_enabled")]
        [JsonPropertyName("isUpdateEnabled")]
        public bool IsUpdateEnabled { get; set; }

    }

}
