using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class ControlDigitAlgorithm
    {
        private Func<long, IEnumerable<int>> GetDigitsOf { get; }
        private IEnumerable<int> MultiplyingFactors { get; }
        private int Modulo { get; set; }

        public ControlDigitAlgorithm(Func<long, IEnumerable<int>> getDigitsOf, 
                                     IEnumerable<int> multiplyingFactors,
                                     int modulo)
        {
            GetDigitsOf = getDigitsOf;
            MultiplyingFactors = multiplyingFactors;
            Modulo = modulo;
        }

        public int GetControlDigit(long number) =>
                GetDigitsOf(number)
                    .Zip(MultiplyingFactors, (a, b) => a*b)
                    .Sum()
                    %Modulo;
    }
}
