using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Application.Models;

namespace Taxes.Application.Repository
{
    public interface ITaxeRepository
    {
        Task<Taxe?> CreateGrossAsync(TaxRequest request);
    }
}
