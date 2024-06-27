using Taxes.Application.Models;
using Taxes.Contract.Request;
using Taxes.Contract.Response;

namespace Taxes.Api.Mapping
{
    public static class ContractMapping
    {
        public static TaxRequest MapToTax(this CreateTaxesRequest request)
        {
            return new TaxRequest
            {
                net = request.net,
                allowance = request.allowance,
            };
        }
        public static TaxeResponse MapToResponse(this Taxe taxe)
        {
            return new TaxeResponse
            {
                GrossSalary = taxe.GrossSalary,
                BasicSalary = taxe.BasicSalary,
                TotalPayeTax = taxe.TotalPayeTax,
                EmployeePensionContribution = taxe.EmployeePensionContribution,
                EmployerPensionContribution = taxe.EmployerPensionContribution
            };
        }
    }
}
