using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    static class ControlDigitAlgorithms
    {
        public static ControlDigitAlgorithm ForAccountingDepartament => 
            new ControlDigitAlgorithm(_ => _.DigitsFromHighest(), MultiplyingFactors, 7);

        public static ControlDigitAlgorithm ForSaleDepartament =>
            new ControlDigitAlgorithm(_ => _.DigitsFromLowest(), MultiplyingFactors, 9);


        private static IEnumerable<int> MultiplyingFactors
        {
            get
            {
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }

        }

    }
}
