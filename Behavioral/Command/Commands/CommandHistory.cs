namespace Command.Commands
{
    /// <summary>
    /// The invoker: executes commands and keeps them in two stacks for undo and redo.
    /// It works with any ICartCommand without knowing what it does.
    /// </summary>
    internal class CommandHistory
    {
        private readonly Stack<ICartCommand> _undoStack = new();
        private readonly Stack<ICartCommand> _redoStack = new();

        public void Execute(ICartCommand command)
        {
            command.Execute();
            _undoStack.Push(command);

            // A new action makes the undone ones no longer valid
            _redoStack.Clear();
            Console.WriteLine($"Do:   {command.Description}");
        }

        public void Undo()
        {
            if (!_undoStack.TryPop(out var command))
            {
                Console.WriteLine("Nothing to undo");
                return;
            }

            command.Undo();
            _redoStack.Push(command);
            Console.WriteLine($"Undo: {command.Description}");
        }

        public void Redo()
        {
            if (!_redoStack.TryPop(out var command))
            {
                Console.WriteLine("Nothing to redo");
                return;
            }

            command.Execute();
            _undoStack.Push(command);
            Console.WriteLine($"Redo: {command.Description}");
        }
    }
}
