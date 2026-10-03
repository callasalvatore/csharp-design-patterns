using System.Collections;
using Iterator.Customers;

namespace Iterator.Iteration
{
    /// <summary>
    /// The aggregate: represents "all the customers" without loading them.
    /// Every foreach gets a new, independent iterator.
    /// </summary>
    internal class PagedCustomerCollection : IEnumerable<Customer>
    {
        private readonly CustomerApi _api;
        private readonly int _pageSize;

        public PagedCustomerCollection(CustomerApi api, int pageSize)
        {
            _api = api;
            _pageSize = pageSize;
        }

        public IEnumerator<Customer> GetEnumerator() => new PagedCustomerEnumerator(_api, _pageSize);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
