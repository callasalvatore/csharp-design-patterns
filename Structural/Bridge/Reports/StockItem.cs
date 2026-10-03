namespace Bridge.Reports
{
    internal record StockItem(string Product, int Quantity, int ReorderLevel)
    {
        public bool NeedsReorder => Quantity <= ReorderLevel;
    }
}
