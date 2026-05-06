using System;
using System.Collections.Generic;

namespace Checkout_Kata;

public class Inventory
{
    public Dictionary<string, int> inventoryList = new Dictionary<string, int>();

    public Inventory()
    {
        
    }

    public Dictionary<string, int> InventoryList
    {
        get => inventoryList;
        set => inventoryList = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Add(string sku, int price)
    {
        InventoryList[sku] = price;
    }

    public bool DoesProductExist(string sku)
    {
        return InventoryList.ContainsKey(sku);
    }

    public int GetPrice(string sku)
    {
        return InventoryList.TryGetValue(sku, out var price) ? price : 0;
    }
}