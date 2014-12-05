namespace CheckoutKata
{
    public class Product
    {
        public string Code { get; set; }
        public decimal Price { get; set; }

        public Product(string code, decimal price)
        {
            Code = code;
            Price = price;
        }
    }
}