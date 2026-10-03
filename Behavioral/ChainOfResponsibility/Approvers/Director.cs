using System.Globalization;
using ChainOfResponsibility.Expenses;

namespace ChainOfResponsibility.Approvers
{
    /// <summary>
    /// The last link: besides a higher limit, it checks the remaining annual budget.
    /// </summary>
    internal class Director : Approver
    {
        private decimal _remainingBudget;

        public Director(decimal annualBudget)
        {
            _remainingBudget = annualBudget;
        }

        protected override string Role => "Director";

        protected override bool CanApprove(ExpenseRequest request) =>
            request.Amount <= 20_000m && request.Amount <= _remainingBudget;

        protected override void Approve(ExpenseRequest request)
        {
            _remainingBudget -= request.Amount;
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"  Director: remaining budget {_remainingBudget:0.00} EUR"));
        }
    }
}
