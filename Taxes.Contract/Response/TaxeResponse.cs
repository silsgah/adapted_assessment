

namespace Taxes.Contract.Response
{
    public class TaxeResponse
    {
        public Guid Id { get; set; }
        public double GrossSalary { get; init; }
        public double BasicSalary { get; init; }
        public double TotalPayeTax { get; init; }
        public double EmployeePensionContribution { get; init; }
        public double EmployerPensionContribution { get; init; }
    }
}
