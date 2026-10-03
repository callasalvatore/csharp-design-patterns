namespace Iterator.Customers
{
    /// <summary>
    /// Simulates a remote CRM API that returns customers one page at a time.
    /// </summary>
    internal class CustomerApi
    {
        private static readonly string[] Cities = ["Milano", "Roma", "Napoli", "Bologna"];

        private readonly List<Customer> _customers = Enumerable
            .Range(1, 23)
            .Select(id => new Customer(id, $"Customer {id:00}", id == 14 ? "Torino" : Cities[id % Cities.Length]))
            .ToList();

        public IReadOnlyList<Customer> GetPage(int pageNumber, int pageSize)
        {
            Console.WriteLine($"    [API] GET /customers?page={pageNumber}&size={pageSize}");

            return _customers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
