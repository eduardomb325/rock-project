using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

namespace RockProjectAPI.Domain.Objects
{
    public class Profit
    {
        [JsonPropertyName("saldo_total_disponibilizado")]
        public string BalanceProfit { get; set; }

        [JsonPropertyName("total_disponibilizado")]
        public string ExpectedProfit { get; set; }

        [JsonPropertyName("total_de_funcionarios")]
        public string EmployeesTotal { get; set; }

        [JsonPropertyName("total_distribuido")]
        public string CalculatedProfit { get; set; }

        [JsonPropertyName("participacoes")]
        public List<EmployeeParticipation> Participations { get; set; }

        public Profit(List<EmployeeParticipation> participations, double profit)
        {
            ExpectedProfit = TransformDoubleToBrazilianCulture(profit);
            Participations = participations;


            EmployeesTotal = GetEmployeesTotal();
            CalculatedProfit = GetCalculatedProfit();

            BalanceProfit = CalculateBalance();
        }

        public string GetCalculatedProfit()
        {
            double response = 0;
            int convertedEmployeesTotal = int.Parse(EmployeesTotal);

            if (convertedEmployeesTotal > 0)
            {
                response = Participations.Sum(x => double.Parse(x.ValorParticipacao.Replace("R$ ", "")));
            }

            return TransformDoubleToBrazilianCulture(response);
        }

        public string GetEmployeesTotal()
        {
            return Participations.Count().ToString();
        }

        public string CalculateBalance()
        {
            double expectedProfitConverted = double.Parse(ExpectedProfit.Replace("R$ ", ""));
            double calculatedProfitConverted = double.Parse(CalculatedProfit.Replace("R$ ", ""));

            double balance = expectedProfitConverted - calculatedProfitConverted;

            return TransformDoubleToBrazilianCulture(balance);
        }

        public string TransformDoubleToBrazilianCulture(double valueToConvert)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valueToConvert);
        }
    }
}
