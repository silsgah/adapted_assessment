using Taxes.Application.Models;

namespace Taxes.Application.Repository
{
    public class TaxeRepositoryBase
    {
        private readonly List<TaxBracket> taxBrackets = new List<TaxBracket>
        {
            new TaxBracket { UpperLimit = 490, Rate = 0 },
            new TaxBracket { UpperLimit = 600, Rate = 0.05 },
            new TaxBracket { UpperLimit = 730, Rate = 0.10 },
            new TaxBracket { UpperLimit = 3896.67, Rate = 0.175 },
            new TaxBracket { UpperLimit = 19896.67, Rate = 0.25 },
            new TaxBracket { UpperLimit = 50416.67, Rate = 0.30 },
            new TaxBracket { UpperLimit = double.MaxValue, Rate = 0.35 }
        };
        public double CalculatePayeTax(double taxableIncome)
        {
            double tax = 0;
            double remainingIncome = taxableIncome;

            foreach (var bracket in taxBrackets)
            {
                if (remainingIncome > bracket.UpperLimit)
                {
                    tax += bracket.UpperLimit * bracket.Rate;
                    remainingIncome -= bracket.UpperLimit;
                }
                else
                {
                    tax += remainingIncome * bracket.Rate;
                    break;
                }
            }

            return tax;
        }
        public double GetEffectiveTaxRate(double grossSalary, double tier2EmployeeRate, double tier3EmployeeRate)
        {
            double taxableIncome = grossSalary - ((tier2EmployeeRate + tier3EmployeeRate) * grossSalary);
            double payeTax = CalculatePayeTax(taxableIncome);
            return payeTax / grossSalary;
        }
    }
}