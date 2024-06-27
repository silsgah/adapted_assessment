using Microsoft.AspNetCore.Mvc;
using Taxes.Api.Mapping;
using Taxes.Application.Models;
using Taxes.Application.Repository;
using Taxes.Contract.Request;

namespace Taxes.Api.Controllers
{

    [ApiController]
    public class GrossController : ControllerBase
    {
        private readonly ITaxeRepository _repository;

        public GrossController(ITaxeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(ApiEndPoints.Taxes.Create)]
        public async Task<IActionResult> create([FromBody]CreateTaxesRequest request)
        {
            var taxe = request.MapToTax();
            Taxe response = await _repository.CreateGrossAsync(taxe);
            return Created($"/api/tax/{response.Id}", response);
        }
    }
}
