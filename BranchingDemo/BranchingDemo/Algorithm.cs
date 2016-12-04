using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class Algorithm
    {

        public static int GetControlDigit(long number)
        {
            //Requirements
            //Multiple every other digit by 3
            //sum the digits up
            //take module 7
            int sum = 0;
            bool isOddPos = true;

            while (number > 0)
            {
                int digit = (int) (number%10);
                if (isOddPos)
                {
                    sum += 3*digit;
                }
                else
                {
                    sum += digit;
                }
                number /= 10;
                isOddPos = !isOddPos;
            }
            int modulo = sum%7;
            return modulo;
        }
    }
}
