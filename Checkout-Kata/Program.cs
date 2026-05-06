using System;

namespace Checkout_Kata
{
    class Program
    {
        
        //TODO Tests
        //Empty Basket
        //A * 3 for discount
        //B*2 for discount
        //mixed basket with discount
        //mixed basket without discount
        //non discount item
        
    
        public static void Main(string[] args)
        {
            Scanning();
            
        }

        public static void Scanning()
        {
            string scanItem = "";
            Checkout checkout = new Checkout();
            
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

