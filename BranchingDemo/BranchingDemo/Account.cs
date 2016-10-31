using System;

namespace BranchingDemo
{
    internal class Account
    {
        public decimal Balance { get; private set; }

        private IAccountState State { get; set; }

        public Account(Action onUnfreeze)
        {
            State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            State = State.Deposit(() => { Balance += amount; });
        }

        public void Withdraw(decimal amount)
        {
            State = State.Withdraw(() => { Balance -= amount; });
        }

        public void HolderVerfied()
        {
            State = State.HolderVerified();
        }

        public void Close()
        {
            State = State.Close();
        }

        public void Freezen()
        {
            State = State.Freeze();
        }

    }
}
