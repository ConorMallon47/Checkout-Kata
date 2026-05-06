using System;
using System.Collections.Generic;

namespace Checkout_Kata
{
    class Program
    {
      
        public static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.Add("A", 50);
            inventory.Add("B", 30);
            inventory.Add("C", 20);
            inventory.Add("D", 15);

            SpecialOffer specialOffer3for130 = new SpecialOffer("A", 3, 130);
            SpecialOffer specialOffer2for45 = new SpecialOffer("B", 2, 45);
            List<SpecialOffer> currentSpecialOffers = new List<SpecialOffer>();
            currentSpecialOffers.Add(specialOffer3for130);
            currentSpecialOffers.Add(specialOffer2for45);

            IPricingService pricingService = new PricingService();
            
            Scanning(inventory, currentSpecialOffers, pricingService);
        }

        public static void Scanning(Inventory inventory, List<SpecialOffer> currentSpecialOffers, IPricingService pricingService)
        {
            string scanItem = "";
            Checkout checkout = new Checkout(inventory, currentSpecialOffers, pricingService);
            
            while (true)
            {
                Console.WriteLine("Please Scan an Item");
                scanItem = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(scanItem))
                    continue;
                
                if (scanItem == "subtotal")
                {
                    Console.WriteLine($"The Total is {checkout.GetTotalPrice()}");
                    break;
                }
                
                checkout.Scan(scanItem);
            }
            
            Console.WriteLine("Scanning Ended");
        }
        
    }
}

