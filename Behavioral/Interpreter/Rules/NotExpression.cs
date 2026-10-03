namespace Interpreter.Rules
{
    /// <summary>
    /// Nonterminal expression: negates its sub-expression.
    /// </summary>
    internal class NotExpression : IExpression
    {
        private readonly IExpression _operand;

        public NotExpression(IExpression operand)
        {
            _operand = operand;
        }

        public bool Interpret(OrderContext context) => !_operand.Interpret(context);

        public override string ToString() => $"NOT {_operand}";
    }
}
