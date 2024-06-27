

namespace Taxes.Application.Models
{
    public class Taxe
    {
        private double _grossSalary;
        private double _basicSalary;
        private double _totalPayeTax;
        private double _employeePensionContribution;
        private double _employerPensionContribution;
        public required Guid Id { get; init; }
        public double GrossSalary {
            get => Math.Round(_grossSalary, 2);
            set => _grossSalary = value;
        }
        public double BasicSalary {
            get => Math.Round(_basicSalary, 2);
            set => _basicSalary = value;
        }
        public double TotalPayeTax {
            get => Math.Round(_totalPayeTax, 2);
            set => _totalPayeTax = value;
        }
        public double EmployeePensionContribution
        {
            get => Math.Round(_employeePensionContribution, 2);
            set => _employeePensionContribution = value;
        }
        public double EmployerPensionContribution {
            get => Math.Round(_employerPensionContribution, 2);
            set => _employerPensionContribution = value;
        }
    }
}
