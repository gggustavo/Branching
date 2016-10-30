using System;

namespace BranchingDemo
{
    internal class Account
    {
        public decimal Balance { get; private set; }
        public bool IsVerified { get; set; }
        public bool IsClosed { get; set; }
        //public bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
            ManageUnfreezing = StayUnfrozen;

            //ManageUnfreezing = () =>
            //{
            //    if (IsFrozen)
            //    {
            //        OnUnfreeze();
            //    }
            //    else
            //    {
            //        StayUnfrozen();
            //    }
            //};
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;

            ManageUnfreezing();
            Balance += amount;//Deposit money.
        }

        //private void ManageUnfreezing()
        //{
        //    if (IsFrozen)
        //    {
        //        OnUnfreeze();
        //    }
        //    else
        //    {
        //        StayUnfrozen();
        //    }
        //}

        private void StayUnfrozen()
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return; // Or do something else...

            if (IsClosed)
                return; //// Or do something else...

            ManageUnfreezing();

            Balance -= amount; //Withdraw money.
        }

        public void HolderVerfied()
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

            //IsFrozen = true;
            ManageUnfreezing = Unfreeze;
        }

        private void Unfreeze()
        {
            OnUnfreeze();
            ManageUnfreezing = StayUnfrozen;
        }

    }
}
