using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class Given_a_CheckOut
    {  
        public ICollection<Product> Products { get; set; }
        public Given_a_CheckOut()
        {
            Products = new List<Product>
            {
                new Product("a", 50.00m),
                new Product("b", 30.00m),
                new Product("c", 20.00m),
                new Product("d", 15.00m)
            };
        }

      

        [Test]
        public void We_can_scan_products()
        {
            var checkOut = new Checkout();
            Products.ToList().ForEach(product => checkOut.Scan(product).Should().Be(product.Price));
        }
    }

    public class Checkout
    {
        public decimal Scan(Product product)
        {
            return product.Price;
        }
    }
}
