using System.Collections.Generic;

namespace Checkout_Kata;

public class Checkout : ICheckout
{
    private List<string>? TransactionList = new List<string>();

    public void Scan(string item)
    {
        TransactionList.Add(item);
    }
            
    public int GetTotalPrice()
    {
        throw new System.NotImplementedException();
    }
}