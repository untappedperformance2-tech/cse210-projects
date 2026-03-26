using System;

namespace OnlineOrdering
{
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _pricePerUnit;
        private int _quantity;

        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return _pricePerUnit * _quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetProductId()
        {
            return _productId;
        }

        public decimal GetPricePerUnit()
        {
            return _pricePerUnit;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        // Setters if needed
        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
    }
}