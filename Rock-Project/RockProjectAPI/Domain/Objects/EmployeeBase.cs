using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
