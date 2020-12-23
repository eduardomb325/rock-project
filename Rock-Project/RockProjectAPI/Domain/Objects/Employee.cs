﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Objects
{
    public class Employee
    {
        [Key]
        [Required]
        [JsonPropertyName("matricula")]
        public string Matricula { get; set; }

        [Required]
        [JsonPropertyName("area")]
        public string Area { get; set; }

        [Required]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Required]
        [JsonPropertyName("cargo")]
        public string Cargo { get; set; }

        [Required]
        [JsonPropertyName("data_de_admissao")]
        public string DataAdmissao { get; set; }

        [Required]
        [JsonPropertyName("salario_bruto")]
        public string SalarioBruto { get; set; }

        public Employee(string id, string occupationArea, string name, string cargo, string admissionalDate, string salary)
        {
            Matricula = id;
            Area = occupationArea;
            Nome = name;
            Cargo = cargo;
            DataAdmissao = admissionalDate;
            SalarioBruto = salary;
        }

    }
}