using System;
using System.Collections.Generic;

namespace Checkout_Kata;

public class Checkout : ICheckout
{
    private readonly Inventory inventory;
    private readonly List<string> currentBasket = new();
    private readonly List<SpecialOffer> currentSpecialOffers;

    public Checkout(Inventory inventory, List<SpecialOffer> currentSpecialOffers)
    {
        this.inventory = inventory;
        this.currentSpecialOffers = currentSpecialOffers;
    }
    
    public void Scan(string scannedItem)
    {
        
        bool scanSuccess = inventory.DoesProductExist(scannedItem);
        
        if (scanSuccess)
        {
            currentBasket.Add(scannedItem);
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }
            
    public int GetTotalPrice()
    {
        IPricingService iPricingService = new PricingService();
        int grandTotal = iPricingService.CalculateTotal(inventory, currentBasket, currentSpecialOffers);
        /*
        int totalStandardPricing = 0;
        int totalSpecialOffers = 0;
        
        //discount prices only, then discounted products are removed from basket before standard calculation to avoid duplication
        foreach (var specialOffer in currentSpecialOffers)
        {
            if (currentBasket.Contains(specialOffer.sku))
            {
                int timesOfferApplied;
                int specialOfferItemCount = currentBasket.Count(item => item == specialOffer.sku);
                
                if (specialOfferItemCount >= specialOffer.quantityThreshold)
                {
                    timesOfferApplied = specialOfferItemCount / specialOffer.quantityThreshold;
                    totalSpecialOffers += specialOffer.specialOfferPrice * timesOfferApplied;
                    
                    for (int i = 0; i < timesOfferApplied * specialOffer.quantityThreshold; i++)
                    {
                        currentBasket.Remove(specialOffer.sku);
                    }
                }
            }
        }
        //remaining products
        foreach (var item in currentBasket)
        {
            totalStandardPricing += inventory.GetPrice(item);
        }

        int grandTotal = totalStandardPricing + totalSpecialOffers;
        */
        return grandTotal;
    }
}