using ChainOfResponsibility.Expenses;

namespace ChainOfResponsibility.Approvers
{
    internal class TeamLead : Approver
    {
        protected override string Role => "Team lead";

        protected override bool CanApprove(ExpenseRequest request) => request.Amount <= 500m;
    }
}
