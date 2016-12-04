using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class FirstChangeAlgorithm
    {
        public static int GetControlDigit(long number)
        {
            int sum = 0;
            bool isOddPos = true;

            foreach (var digit in GetDigitOf(number))
            {
                if (isOddPos)
                {
                    sum += 3 * digit;
                }
                else
                {
                    sum += digit;
                }
                number /= 10;
                isOddPos = !isOddPos;
            }
            int modulo = sum % 7;
            return modulo;
        }

        private static IEnumerable<int> GetDigitOf(long number)
        {
            IList<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits;
        }
    }

    public class SecondChangeAlgorithm
    {
        public static int GetControlDigit(long number)
        {
            int sum = 0;
            IEnumerator<int> factor = MultiplyingFactors.GetEnumerator();

            foreach (var digit in GetDigitOf(number))
            {
                factor.MoveNext();
                sum += digit * factor.Current;
            }
            int modulo = sum % 7;
            return modulo;
        }

        private static IEnumerable<int> MultiplyingFactors
        {
            get
            {
                return new int[] { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1 };
            }
            
        }

        private static IEnumerable<int> GetDigitOf(long number)
        {
            IList<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits;
        }
    }

    public class ThirdChangeAlgorithm
    {
        public static int GetControlDigit(long number)
        {
            IEnumerator<int> factor = MultiplyingFactors.GetEnumerator();
            IList<int> ponderedDigits = new List<int>();

            foreach (var digit in GetDigitOf(number))
            {
                factor.MoveNext();

                ponderedDigits.Add(digit *  factor.Current);
            }
            int sum = ponderedDigits.Sum();
            int modulo = sum % 7;
            return modulo;
        }

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

        private static IEnumerable<int> GetDigitOf(long number)
        {
            IList<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits;
        }
    }

    public class FourthChangeAlgorithm
    {
        public static int GetControlDigit(long number) =>
            GetDigitOf(number)
                .Zip(MultiplyingFactors, (a, b) => a*b)
                .Sum()
                 %7;

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

        private static IEnumerable<int> GetDigitOf(long number)
        {
            IList<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits;
        }
    }

    public class FifthChangeAlgorithm
    {
        //New requirement
        //Digits of the number can be read right-to-left or left-to-right

        public static int GetControlDigit(long number) =>
            number.DigitsFromLowest()
                  .Zip(MultiplyingFactors, (a, b) => a * b)
                  .Sum()
                   % 7;

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
