namespace Interpreter.Rules
{
    /// <summary>
    /// Nonterminal expression: true when at least one sub-expression is true.
    /// </summary>
    internal class OrExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public OrExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public bool Interpret(OrderContext context) => _left.Interpret(context) || _right.Interpret(context);

        public override string ToString() => $"({_left} OR {_right})";
    }
}
