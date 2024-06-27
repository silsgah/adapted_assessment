using Taxes.Application.Models;
using Taxes.Application.Repository;

namespace SalaryApi.Tests
{
    public class TaxServiceTests
    {
        private readonly ITaxeRepository _taxesRepository;
        public TaxServiceTests()
        {
            _taxesRepository = new TaxeRepository();
        }
        [Fact]
        public async void TestCalculateGrossSalary()
        {
            // Arrange
            var request = new TaxRequest { net = 1000, allowance = 200 };

            // Act
            var response = _taxesRepository.CreateGrossAsync(request);

            // Asserts for the expected values based on the graduated tax rates
            Assert.True(response.Result.GrossSalary > 1000);
            Assert.True(response.Result.BasicSalary > 800);
            Assert.True(response.Result.TotalPayeTax > 0);
            Assert.True(response.Result.EmployeePensionContribution > 0);
            Assert.True(response.Result.EmployerPensionContribution > 0);
        }
    }
}