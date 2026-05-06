using System.Collections.Generic;

namespace Checkout_Kata;

public class SpecialOffer
{
    public string sku { get; }
    public int quantityThreshold { get; }
    public int specialOfferPrice { get; }
    
    
    public SpecialOffer(string sku, int quantityThreshold, int specialOfferPrice)
    {
        this.sku = sku;
        this.quantityThreshold = quantityThreshold;
        this.specialOfferPrice = specialOfferPrice;
    }
}