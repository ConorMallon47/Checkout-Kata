using System;
using System.Collections.Generic;

namespace Checkout_Kata;

public class Checkout : ICheckout
{
    private readonly Inventory inventory;
    private readonly List<string> currentBasket = new();
    private readonly IReadOnlyList<SpecialOffer> currentSpecialOffers;
    private readonly IPricingService pricingService;

    public Checkout(Inventory inventory, List<SpecialOffer> currentSpecialOffers, IPricingService pricingService)
    {
        this.inventory = inventory;
        this.currentSpecialOffers = currentSpecialOffers;
        this.pricingService = pricingService;
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
            Console.WriteLine("Product Not Found");
        }
    }
            
    public int GetTotalPrice()
    {
        return pricingService.CalculateTotal(inventory, currentBasket, currentSpecialOffers);
    }
}