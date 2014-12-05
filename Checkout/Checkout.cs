using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        public decimal Scan(Product product, int quantity)
        {
            var discountsToApply = product.Discounts.Where(discount => discount.Quantity == quantity).ToList();
            if(!discountsToApply.Any()) return product.Price * quantity;
            var bestDiscountedPrice = discountsToApply.Select(discount => PriceAfterDiscount(discount.DiscountPercentage, product.Price, quantity)).Min();
            return bestDiscountedPrice;



        }

        private decimal PriceAfterDiscount(decimal discountPercentage, decimal price, int quantity)
        {
            var totalBeforeDiscount = price*quantity;
            var discount = totalBeforeDiscount * (discountPercentage/100);
            return totalBeforeDiscount - discount;
        }
    }
}