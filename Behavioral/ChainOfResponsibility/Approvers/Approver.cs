using ChainOfResponsibility.Expenses;

namespace ChainOfResponsibility.Approvers
{
    /// <summary>
    /// The handler: each approver either handles the request
    /// or passes it to the next approver in the chain.
    /// </summary>
    internal abstract class Approver
    {
        private Approver? _next;

        protected abstract string Role { get; }

        /// <summary>
        /// Links the next approver and returns it, so the chain can be built fluently.
        /// </summary>
        public Approver SetNext(Approver next)
        {
            _next = next;
            return next;
        }

        public void Handle(ExpenseRequest request)
        {
            if (CanApprove(request))
            {
                Approve(request);
                Console.WriteLine($"  APPROVED by {Role}");
                return;
            }

            if (_next is null)
            {
                Console.WriteLine($"  {Role}: cannot approve it and there is nobody above. REJECTED");
                return;
            }

            Console.WriteLine($"  {Role}: above my authority, forwarding");
            _next.Handle(request);
        }

        protected abstract bool CanApprove(ExpenseRequest request);

        // Hook for approvers that need to do something when they approve
        protected virtual void Approve(ExpenseRequest request)
        {
        }
    }
}
