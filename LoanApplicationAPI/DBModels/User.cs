using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanApplicationAPI.DBModels
{
    [Table("users", Schema = "dbo")]
    public class User
    {
        [Key]
        [Column("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }

        [Column("email")]
        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [Column("contact_number")]
        [JsonPropertyName("contactNumber")]
        public long? ContactNumber { get; set; }

        [Column("created_datetime")]
        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

    }


}
