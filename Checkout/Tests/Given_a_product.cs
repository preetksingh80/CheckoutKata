using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class Given_a_product
    {
        [Test]
        public void It_can_be_priced_indiviual()
        {
           var product = new Product("a", 50.00m);
            product.Code.Should().Be("a");
            product.Price.Should().Be(50.00m);

        }

        [Test]
        public void It_can_be_multi_priced()
        {
            var product = new Product("a", 50.00m);
            IDiscount multiBuyDiscount = new MultiBuyDiscount(3, 13.33m);
            var expectedDiscounts = new List<IDiscount> {multiBuyDiscount};
            product.Discounts.Add(multiBuyDiscount);
            product.Discounts.Should().Equal(expectedDiscounts);





        }

        
    }
}
