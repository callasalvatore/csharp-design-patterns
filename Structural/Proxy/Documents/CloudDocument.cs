namespace Proxy.Documents
{
    /// <summary>
    /// The real subject: creating it means downloading the whole file from cloud storage,
    /// which is slow and costs bandwidth.
    /// </summary>
    internal class CloudDocument : IDocument
    {
        private readonly string _content;

        public string Title { get; }

        public CloudDocument(string id, string title)
        {
            Title = title;

            Console.WriteLine($"  [Storage] Downloading '{id}' from the cloud...");
            _content = $"<content of {id}>";
        }

        public string GetContent() => _content;
    }
}
