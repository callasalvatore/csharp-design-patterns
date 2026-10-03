namespace Proxy.Documents
{
    /// <summary>
    /// The proxy: has the same interface as the real document and controls access to it.
    /// - Virtual proxy: the document is downloaded only when its content is really needed.
    /// - Protection proxy: only users of the allowed department can read it.
    /// </summary>
    internal class DocumentProxy : IDocument
    {
        private readonly string _id;
        private readonly string _allowedDepartment;
        private readonly User _currentUser;
        private CloudDocument? _realDocument;

        // The title is cheap metadata: the proxy can answer without downloading anything
        public string Title { get; }

        public DocumentProxy(string id, string title, string allowedDepartment, User currentUser)
        {
            _id = id;
            Title = title;
            _allowedDepartment = allowedDepartment;
            _currentUser = currentUser;
        }

        public string GetContent()
        {
            if (_currentUser.Department != _allowedDepartment)
                throw new UnauthorizedAccessException(
                    $"{_currentUser.Name} ({_currentUser.Department}) cannot open '{Title}': reserved to {_allowedDepartment}.");

            // Created on first use, then reused
            _realDocument ??= new CloudDocument(_id, Title);
            return _realDocument.GetContent();
        }
    }
}
