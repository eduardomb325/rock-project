using RockProjectAPI.Domain.Objects.Interfaces;
using System.Text.Json.Serialization;

namespace RockProjectAPI.Domain.Objects
{
    public class EmployeeParticipation : IEmployeeBase
    {
        [JsonPropertyName("matricula")]
        public string Matricula { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("valor_da_participacao")]
        public string ValorParticipacao { get; set; }

        public EmployeeParticipation(string matricula, string nome, string valorParticipacao)
        {
            Matricula = matricula;
            Nome = nome;
            ValorParticipacao = valorParticipacao;
        }

        public EmployeeParticipation()
        {

        }
    }
}
