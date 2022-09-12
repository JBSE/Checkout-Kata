using Checkout_Kata.Models;

namespace Checkout_Kata
{
    public class Checkout
    {
        private readonly List<Product> _products = new List<Product>();
        private List<string> _scannedItem = new List<string>();

        public Checkout(List<Product> product)
        {
            _products = product;
        }
        
        public void ScanItem(string product)
        {
            if (string.IsNullOrEmpty(product) || !_products.Any(x => x.ProductName.Contains(product)))
            {
                throw new ArgumentException($"Invalid Item scanned");
            }
            
            _scannedItem.Add(product);
        }

        public decimal CalculateTotal()
        {
            var total = 0M;
            foreach (var item in _scannedItem)
            {
                if (_products.Any(x => x.ProductName.Contains(item)))
                {
                    total += _products.Where(x => item.Contains(x.ProductName)).Sum(y => y.ProductPrice);
                }
            }

            return total;
        }
    }
}