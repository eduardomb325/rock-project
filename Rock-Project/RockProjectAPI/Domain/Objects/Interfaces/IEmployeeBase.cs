namespace RockProjectAPI.Domain.Objects.Interfaces
{
    public interface IEmployeeBase
    {
        string Matricula { get; set; }
        string Nome { get; set; }
        string SalarioBruto { get; set; }
    }
}
