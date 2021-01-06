using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RockProjectAPI.Domain.Objects
{
    public class EmployeeBase
    {
        [Key]
        [Required]
        [JsonPropertyName("matricula")]
        public string Id { get; set; }

        [Required]
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        public EmployeeBase()
        {

        }
    }
}
