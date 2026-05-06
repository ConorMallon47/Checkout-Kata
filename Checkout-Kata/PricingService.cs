using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata;

public class PricingService : IPricingService
{
    public int CalculateTotal(Inventory inventory, List<string> currentBasket, List<SpecialOffer> currentSpecialOffers)
    {
        int total = 0;

        var groupedItems = currentBasket
            .GroupBy(item => item)
            .ToDictionary(g => g.Key, g => g.Count());

        foreach (var (sku, count) in groupedItems)
        {
            var offer = currentSpecialOffers
                .FirstOrDefault(o => o.sku == sku);

            if (offer != null && count >= offer.quantityThreshold)
            {
                int offerSets = count / offer.quantityThreshold;
                int remainder = count % offer.quantityThreshold;
                
                total += (offerSets * offer.specialOfferPrice) +
                         (remainder * inventory.GetPrice(sku));
            }
            else
            {
                total += count * inventory.GetPrice(sku);
            }
        }
        
        return total;
    }
}