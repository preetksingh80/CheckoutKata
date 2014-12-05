using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class Given_a_CheckOut
    {
        public Product ProductA { get; set; }
        public Product ProductB { get; set; }
        public Product ProductC { get; set; }
        public Product ProductD { get; set; }
        public Given_a_CheckOut()
        {
            ProductA = new Product("a", 50.00m);
            ProductB = new Product("b", 30.00m);
            ProductC = new Product("c", 20.00m);
            ProductD = new Product("d", 15.00m);

        }




        [Test]
        public void We_can_scan_single_product_with_no_discounts()
        {
            
            var checkOut = new Checkout();
            checkOut.Scan(ProductA).Should().Be(50);
            
        }

        [Test]
        public void We_can_scan_multiple_products_with_no_discounts()
        {
            var expectedTotal = new List<Product> {ProductA, ProductB, ProductC, ProductD}.Sum(product => product.Price);
            var checkOut = new Checkout();
            checkOut.Scan(ProductA);
            checkOut.Scan(ProductB);
            checkOut.Scan(ProductC);
            checkOut.Scan(ProductD).Should().Be(expectedTotal);

        }

        [Test]
        public void We_can_scan_multiple_products_with_discounts()
        {
            var productWithDiscount = new Product("x", 50);
            var discount = new MultiBuyDiscount(2, 50);
            productWithDiscount.Discounts.Add(discount);
            var checkOut = new Checkout();
            checkOut.Scan(ProductA).Should().Be(50);
            checkOut.Scan(productWithDiscount).Should().Be(100);
            checkOut.Scan(productWithDiscount).Should().Be(100);
            checkOut.Scan(ProductA).Should().Be(150);
         }

        [Test]
        public void We_can_scan_multiple_products_with_discounts2()
        {
            var productWithDiscount = new Product("x", 50);
            var productWithDiscount2 = new Product("y", 50);
            var discount = new MultiBuyDiscount(2, 50);
            productWithDiscount.Discounts.Add(discount);
            productWithDiscount2.Discounts.Add(discount);
            var checkOut = new Checkout();
            checkOut.Scan(productWithDiscount2).Should().Be(50);
            checkOut.Scan(productWithDiscount).Should().Be(100);
            checkOut.Scan(productWithDiscount).Should().Be(100);
            checkOut.Scan(ProductA).Should().Be(150);


        }

        [Test]
        public void We_can_scan_multiple_products_with_discounts3()
        {
            var productWithDiscount = new Product("x", 50);
            var productWithDiscount2 = new Product("y", 50);
            var discount = new MultiBuyDiscount(2, 50);
            productWithDiscount.Discounts.Add(discount);
            productWithDiscount2.Discounts.Add(discount);
            var checkOut = new Checkout();
            checkOut.Scan(productWithDiscount2).Should().Be(50);
            checkOut.Scan(productWithDiscount).Should().Be(100);
            checkOut.Scan(productWithDiscount).Should().Be(100);
            checkOut.Scan(ProductA).Should().Be(150);
            checkOut.Scan(productWithDiscount2).Should().Be(150);
        }
    }
}
