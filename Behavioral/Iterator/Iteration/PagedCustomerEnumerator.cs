using System.Collections;
using Iterator.Customers;

namespace Iterator.Iteration
{
    /// <summary>
    /// The iterator: keeps track of the current position and loads
    /// the next page from the API only when the current one is finished.
    /// </summary>
    internal class PagedCustomerEnumerator : IEnumerator<Customer>
    {
        private readonly CustomerApi _api;
        private readonly int _pageSize;

        private IReadOnlyList<Customer> _page = [];
        private int _pageNumber;
        private int _indexInPage = -1;
        private bool _isLastPage;

        public PagedCustomerEnumerator(CustomerApi api, int pageSize)
        {
            _api = api;
            _pageSize = pageSize;
        }

        public Customer Current => _page[_indexInPage];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            // Still items in the current page
            if (_indexInPage + 1 < _page.Count)
            {
                _indexInPage++;
                return true;
            }

            if (_isLastPage)
                return false;

            // Current page finished: fetch the next one
            _page = _api.GetPage(++_pageNumber, _pageSize);
            _indexInPage = 0;

            // A page shorter than the page size is the last one
            _isLastPage = _page.Count < _pageSize;
            return _page.Count > 0;
        }

        public void Reset()
        {
            _page = [];
            _pageNumber = 0;
            _indexInPage = -1;
            _isLastPage = false;
        }

        public void Dispose()
        {
        }
    }
}
