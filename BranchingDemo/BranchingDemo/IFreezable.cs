﻿namespace BranchingDemo
{
    public interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();

    }
}