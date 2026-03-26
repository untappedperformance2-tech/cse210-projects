using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _products = new List<Product>();
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalProductCost = 0;
            
            foreach (Product product in _products)
            {
                totalProductCost += product.GetTotalCost();
            }

            // Add shipping cost
            decimal shippingCost = _customer.LivesInUSA() ? 5.00m : 35.00m;
            
            return totalProductCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder packingLabel = new StringBuilder();
            packingLabel.AppendLine("PACKING LABEL");
            packingLabel.AppendLine("=".PadRight(40, '='));
            
            foreach (Product product in _products)
            {
                packingLabel.AppendLine($"Product: {product.GetName()}");
                packingLabel.AppendLine($"ID: {product.GetProductId()}");
                packingLabel.AppendLine($"Quantity: {product.GetQuantity()}");
                packingLabel.AppendLine($"Price per unit: ${product.GetPricePerUnit():F2}");
                packingLabel.AppendLine($"Item Total: ${product.GetTotalCost():F2}");
                packingLabel.AppendLine("-".PadRight(40, '-'));
            }
            
            return packingLabel.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder shippingLabel = new StringBuilder();
            shippingLabel.AppendLine("SHIPPING LABEL");
            shippingLabel.AppendLine("=".PadRight(40, '='));
            shippingLabel.AppendLine($"Customer: {_customer.GetName()}");
            shippingLabel.AppendLine("Address:");
            shippingLabel.AppendLine(_customer.GetAddress().GetFullAddress());
            
            return shippingLabel.ToString();
        }

        public decimal GetShippingCost()
        {
            return _customer.LivesInUSA() ? 5.00m : 35.00m;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}