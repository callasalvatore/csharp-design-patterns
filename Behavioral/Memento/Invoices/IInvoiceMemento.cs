namespace Memento.Invoices
{
    /// <summary>
    /// The memento as seen from outside (narrow interface): the caretaker can store it
    /// and show a description, but it can't read or change the saved state.
    /// </summary>
    internal interface IInvoiceMemento
    {
        string Description { get; }
    }
}
