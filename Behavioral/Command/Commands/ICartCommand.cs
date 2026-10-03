namespace Command.Commands
{
    /// <summary>
    /// The command: an operation turned into an object, which can be executed and undone.
    /// </summary>
    internal interface ICartCommand
    {
        string Description { get; }
        void Execute();
        void Undo();
    }
}
