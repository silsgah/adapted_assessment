
namespace Taxes.Contract.Request
{
    public class UpdateTaxe
    {
        public required double net { get; init; }
        public required double allowance { get; init; }
    }
}
