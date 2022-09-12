using Checkout_Kata.Enums;

namespace Checkout_Kata.Models
{
    public class DiscountRule
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DiscountType DiscountType { get; set; }

        public string DiscountValue { get; set; }
    }
}
