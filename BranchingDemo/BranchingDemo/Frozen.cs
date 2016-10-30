using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => new Active(OnUnfreeze);

        public IFreezable Withdraw() => new Active(OnUnfreeze);

        public IFreezable Freeze() => this;
    }
}
