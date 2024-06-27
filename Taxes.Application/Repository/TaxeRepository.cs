
using Taxes.Application.Models;

namespace Taxes.Application.Repository
{
    public class TaxeRepository : TaxeRepositoryBase, ITaxeRepository
    {

        public async Task<Taxe?> CreateGrossAsync(TaxRequest request)
        {
            double netSalary = request.net;
            double allowances = request.allowance;

            // Pension rates
            double tier1EmployerRate = 0.13;
            double tier2EmployeeRate = 0.055;
            double tier3EmployeeRate = 0.05;
            double tier3EmployerRate = 0.05;

            // Calculate the total pension contributions
            double employeePensionContribution = (tier2EmployeeRate + tier3EmployeeRate) * netSalary;
            double employerPensionContribution = (tier1EmployerRate + tier3EmployerRate) * netSalary;

            // Calculate gross salary iteratively to account for PAYE
            double grossSalary = netSalary;
            double totalPayeTax = 0;
            double taxableIncome;
            int iteration = 0;
            const int maxIterations = 1000;
            const double tolerance = 0.01;

            do
            {
                iteration++;
                double previousGrossSalary = grossSalary;
                grossSalary = netSalary / (1 - GetEffectiveTaxRate(previousGrossSalary, tier2EmployeeRate, tier3EmployeeRate));
                taxableIncome = grossSalary - employeePensionContribution;
                totalPayeTax = CalculatePayeTax(taxableIncome);

                // Break if change is within the tolerance level or max iterations reached
                if (Math.Abs(grossSalary - previousGrossSalary) < tolerance || iteration > maxIterations)
                {
                    break;
                }
            } while (true);

            // Basic salary calculation
            double basicSalary = grossSalary - allowances;

            // Create response
            Taxe response = new Taxe
            {
                Id = Guid.NewGuid(),
                GrossSalary = grossSalary,
                BasicSalary = basicSalary,
                TotalPayeTax = totalPayeTax,
                EmployeePensionContribution = employeePensionContribution,
                EmployerPensionContribution = employerPensionContribution
            };
            return await Task.FromResult(response);
        }
       
    }
}
