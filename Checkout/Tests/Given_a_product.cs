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

        
    }
}
