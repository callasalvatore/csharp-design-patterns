namespace Bridge.Renderers
{
    /// <summary>
    /// The implementor: low-level formatting primitives.
    /// It knows how to draw a title or a table, but nothing about sales or inventory.
    /// </summary>
    internal interface IReportRenderer
    {
        string Title(string text);
        string Table(IReadOnlyList<string> headers, IReadOnlyList<string[]> rows);
        string Note(string text);
    }
}
