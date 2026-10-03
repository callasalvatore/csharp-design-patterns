namespace Bridge.Reports
{
    internal record Sale(string Product, int Quantity, decimal UnitPrice)
    {
        public decimal Total => Quantity * UnitPrice;
    }
}
