using ChainOfResponsibility.Expenses;

namespace ChainOfResponsibility.Approvers
{
    internal class Manager : Approver
    {
        protected override string Role => "Manager";

        protected override bool CanApprove(ExpenseRequest request) => request.Amount <= 5_000m;
    }
}
