namespace Facade.Subsystems
{
    internal class InventoryService
    {
        private readonly Dictionary<string, int> _stock = new()
        {
            ["LAPTOP-15"] = 5,
            ["MONITOR-27"] = 0
        };

        public bool Reserve(string sku, int quantity)
        {
            if (_stock.GetValueOrDefault(sku) < quantity)
            {
                Console.WriteLine($"  [Inventory] Not enough stock for {sku}");
                return false;
            }

            _stock[sku] -= quantity;
            Console.WriteLine($"  [Inventory] Reserved {quantity} x {sku} ({_stock[sku]} left)");
            return true;
        }

        public void Release(string sku, int quantity)
        {
            _stock[sku] += quantity;
            Console.WriteLine($"  [Inventory] Released {quantity} x {sku} ({_stock[sku]} left)");
        }
    }
}
