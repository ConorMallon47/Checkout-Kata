using System;
using System.Collections.Generic;

namespace Checkout_Kata;

public class Checkout : ICheckout
{
    private readonly Inventory inventory;
    private readonly List<string>? CurrentTransactionList = new();

    public Checkout(Inventory inventory)
    {
        this.inventory = inventory;
    }
    
    public void Scan(string scannedItem)
    {
        
        bool scanSuccess = inventory.DoesProductExist(scannedItem);
        
        if (scanSuccess)
        {
            CurrentTransactionList.Add(scannedItem);
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }
            
    public int GetTotalPrice()
    {
        int totalBeforeDiscount = 0;

        foreach (var item in CurrentTransactionList)
        {
            totalBeforeDiscount += inventory.GetPrice(item);
        }
        
        return totalBeforeDiscount;
    }
}