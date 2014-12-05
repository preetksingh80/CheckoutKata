namespace CheckoutKata
{
    public class MultiBuyDiscount : IDiscount
    {
        public int Quantity { get; private set; }

        public decimal DiscountPercentage { get; private set; }
        public MultiBuyDiscount(int quantity, decimal discountPercentage)
        {
            Quantity = quantity;
            DiscountPercentage = discountPercentage;
        }

        
    }
}