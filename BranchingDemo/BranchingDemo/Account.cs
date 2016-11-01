using System;

namespace BranchingDemo
{
    internal class Account
    {
        public decimal Balance { get; private set; }
        public bool IsVerified { get; set; }
        public bool IsClosed { get; set; }
        public bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }

        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;

            if (IsFrozen)
            {
                IsFrozen = false;
                OnUnfreeze();
            }
            Balance += amount;//Deposit money.
        }

        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return; // Or do something else...

            if (IsClosed)
                return; //// Or do something else...

            if (IsFrozen)
            {
                IsFrozen = false;
                OnUnfreeze();
            }

            Balance -= amount; //Withdraw money.
        }

        public void HolderVerified()
        {
            IsVerified = true;
        }

        public void Close()
        {
            IsClosed = true;
        }

        public void Freezen()
        {
            if (IsClosed)
                return; // Account must not be closed

            if (!IsVerified)
                return; // Account must be verified

            IsFrozen = true;
        }

    }
}
