using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Contract.Response
{
    public class TaxesResponse
    {
        public required IEnumerable<TaxesResponse> Item { get; set; } = Enumerable.Empty<TaxesResponse>();
    }
}
