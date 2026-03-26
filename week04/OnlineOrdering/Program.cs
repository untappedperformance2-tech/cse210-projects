using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address usaAddress1 = new Address("123 Main Street", "New York", "NY", "USA");
            Address usaAddress2 = new Address("456 Oak Avenue", "Los Angeles", "CA", "USA");
            Address internationalAddress = new Address("789 Maple Road", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Smith", usaAddress1);
            Customer customer2 = new Customer("Maria Garcia", usaAddress2);
            Customer customer3 = new Customer("David Chen", internationalAddress);

            // Create Order 1 (USA Customer)
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop Computer", "LAP001", 999.99m, 1));
            order1.AddProduct(new Product("Wireless Mouse", "MOU002", 29.99m, 2));
            order1.AddProduct(new Product("Laptop Bag", "BAG003", 49.99m, 1));

            // Create Order 2 (USA Customer)
            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", "PHN001", 699.99m, 1));
            order2.AddProduct(new Product("Phone Case", "CAS002", 19.99m, 3));
            order2.AddProduct(new Product("Screen Protector", "SCR003", 9.99m, 2));

            // Create Order 3 (International Customer)
            Order order3 = new Order(customer3);
            order3.AddProduct(new Product("Gaming Console", "GAM001", 499.99m, 1));
            order3.AddProduct(new Product("Wireless Controller", "CON002", 59.99m, 2));
            order3.AddProduct(new Product("HDMI Cable", "HDM003", 14.99m, 1));

            // Store orders in a list
            List<Order> orders = new List<Order> { order1, order2, order3 };

            // Display all orders
            int orderNumber = 1;
            foreach (Order order in orders)
            {
                Console.WriteLine($"ORDER #{orderNumber}");
                Console.WriteLine("=".PadRight(60, '='));
                Console.WriteLine();
                
                // Display shipping label
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine();
                
                // Display packing label
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine();
                
                // Display total cost
                Console.WriteLine("ORDER SUMMARY");
                Console.WriteLine("-".PadRight(40, '-'));
                Console.WriteLine($"Subtotal: ${order.CalculateTotalCost() - order.GetShippingCost():F2}");
                Console.WriteLine($"Shipping: ${order.GetShippingCost():F2}");
                Console.WriteLine($"Total: ${order.CalculateTotalCost():F2}");
                
                Console.WriteLine();
                Console.WriteLine("=".PadRight(60, '='));
                Console.WriteLine("\n\n");
                
                orderNumber++;
            }
        }
    }
}