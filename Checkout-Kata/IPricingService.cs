using System.Collections.Generic;

namespace Checkout_Kata;

public interface IPricingService
{
    int CalculateTotal(Inventory inventory, List<string> currentBasket, IReadOnlyList<SpecialOffer> currentSpecialOffers);
}