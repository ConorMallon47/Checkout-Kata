namespace Checkout_Kata.Tests;

public class CheckoutTests
{
    [Fact]
    public void GetTotalPrice_EmptyBasket_ReturnsZero()
    {
        var inventory = new Inventory();
        var offers = new List<SpecialOffer>();
        var pricing = new PricingService();

        var checkout = new Checkout(inventory, offers, pricing);

        var total = checkout.GetTotalPrice();
        
        Assert.Equal(0, total);
    }

    [Fact]
    public void GetTotalPrice_SingleItem_ReturnsCorrectPrice()
    {
        var inventory = new Inventory();
        inventory.Add("A", 50);
        
        var checkout = new Checkout(inventory, new List<SpecialOffer>() , new PricingService());
        
        checkout.Scan("A");

        var total = checkout.GetTotalPrice();
        
        Assert.Equal(50, total);
    }

    [Fact]
    public void GetTotalPrice_ThreeAs_AppliesDiscount()
    {
        var inventory = new Inventory();
        inventory.Add("A", 50);

        var offers = new List<SpecialOffer>
        {
            new SpecialOffer("A", 3, 130)
        };
        
        var checkout = new Checkout(inventory, offers, new PricingService());
        
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        var total = checkout.GetTotalPrice();
        
        Assert.Equal(130, total);
    }

    [Fact]
    public void GetTotalPrice_MixedBasket_CalculatesCorrectly()
    {
        var inventory = new Inventory();
        inventory.Add("A", 50);
        inventory.Add("B", 30);
        
        var offers = new List<SpecialOffer>
        {
            new SpecialOffer("A", 3, 130),
            new SpecialOffer("B", 2, 45)
        };
        
        var checkout = new Checkout(inventory, offers, new PricingService());
        
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        
        var total = checkout.GetTotalPrice();
        
        Assert.Equal(175, total);
    }
    
}