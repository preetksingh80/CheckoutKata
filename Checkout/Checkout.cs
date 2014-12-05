using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private List<Product> _scannedProduts;
        private decimal _totalSofar;
        private decimal _totalDiscountSoFar;
        public Checkout()
        {
            _totalSofar = 0;
            _totalDiscountSoFar = 0;
            _scannedProduts = new List<Product>();
        }
        public decimal Scan(Product product)
        {
            _scannedProduts.Add(product);
            _totalSofar = _scannedProduts.Sum(product1 => product1.Price);
            var quantity = _scannedProduts.Count(scannedProduct => scannedProduct.Code == product.Code);
            var discountsToApply = product.Discounts.Where(discount => discount.Quantity == quantity).ToList();
            _totalDiscountSoFar += discountsToApply.Any()? discountsToApply.Select(discount => DiscountToTakeOffTheTotal(discount.DiscountPercentage, product.Price, quantity)).Min(): 0;
            return _totalSofar - _totalDiscountSoFar;



        }

        private decimal DiscountToTakeOffTheTotal(decimal discountPercentage, decimal price, int quantity)
        {
            var totalBeforeDiscount = price*quantity;
            var discount = totalBeforeDiscount * (discountPercentage/100);
            return totalBeforeDiscount - discount;
        }
    }
}