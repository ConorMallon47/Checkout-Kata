using System.Collections.Generic;

namespace Checkout_Kata;

public interface IPricingService
{
    int CalculateTotal(IEnumerable<string> items);
}