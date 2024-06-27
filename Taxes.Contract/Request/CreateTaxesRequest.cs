

namespace Taxes.Contract.Request
{
    public class CreateTaxesRequest
    {
        public required double net { get; init; }
        public required double allowance { get; init; }
    }
}
