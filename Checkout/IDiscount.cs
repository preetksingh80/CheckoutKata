namespace CheckoutKata
{
    public interface IDiscount
    {
        int Quantity { get; }
        decimal DiscountPercentage { get; }
    }
}