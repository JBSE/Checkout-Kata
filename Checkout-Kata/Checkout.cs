using System.Security.Cryptography.X509Certificates;
using Checkout_Kata.Models;

namespace Checkout_Kata
{
    public class Checkout
    {
        private readonly Product _product;
        private List<string> _scannedItem = new List<string>();

        public Checkout(Product product)
        {
            _product = product;
        }
        
        public void ScanItem(string product)
        {
            if (string.IsNullOrEmpty(product) || !_product.ProductName.Contains(product))
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
                if (_product.ProductName.Contains(item))
                {
                    total += _product.ProductPrice;
                }
            }

            return total;
        }
    }
}