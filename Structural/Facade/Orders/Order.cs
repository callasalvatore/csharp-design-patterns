namespace Facade.Orders
{
    internal record Order(
        string Id,
        string CustomerEmail,
        string ShippingAddress,
        string Sku,
        int Quantity,
        decimal Amount,
        string PaymentToken);
}
