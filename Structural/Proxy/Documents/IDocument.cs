namespace Proxy.Documents
{
    /// <summary>
    /// The subject: the interface shared by the real document and its proxy,
    /// so the client can't tell them apart.
    /// </summary>
    internal interface IDocument
    {
        string Title { get; }
        string GetContent();
    }
}
