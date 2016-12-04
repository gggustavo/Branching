using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    static class Int64Extensions
    {
        public static IEnumerable<int> DigitsFromLowest(this long number)
        {
            do
            {
                yield return (int) number%10;
                number /= 10;
            } while (number > 10);
        }

        public static IEnumerable<int> DigitsFromHighest(this long number) =>    
             number.DigitsFromLowest().Reverse();
        
    }
}
