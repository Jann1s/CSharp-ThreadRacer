using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ThreadRacer.Tracks
{
    // calculates the given digits after the comma, while calculating PI (3.14......)
    class CaclPI : ITrack
    {
        private List<Func<bool>> functions;
        private const int numbersAfterCommaAfterCommaSmall = 1000;
        private const int numbersAfterCommaAfterCommaNormal = 10000;
        private const int numbersAfterCommaAfterCommaBig = 10000000;

        public CaclPI()
        {
            functions = new List<Func<bool>>();
            functions.Add(SmallPi);
            functions.Add(MediumPi);
            functions.Add(MediumPi);
            functions.Add(BigPi);
            functions.Add(BigPi);
        }

        public List<Func<bool>> GetFunctions()
        {
            return functions;
        }

        public bool SmallPi()
        {
            return CalculatePi(numbersAfterCommaAfterCommaSmall);
        }

        public bool MediumPi()
        {
            return CalculatePi(numbersAfterCommaAfterCommaNormal);
        }

        public bool BigPi()
        {
            return CalculatePi(numbersAfterCommaAfterCommaBig);
        }
        
        private bool CalculatePi(int numbersAfterComma)
        {
            BigInteger pi = 16 * CalcArcTan(5, numbersAfterComma).ElementAt(1)- 4 * CalcArcTan(239, numbersAfterComma).ElementAt(1);
            return true;
        }

        private IEnumerable<BigInteger> CalcArcTan(int x, int numbersAfterComma)
        {
            BigInteger mag = BigInteger.Pow(10, numbersAfterComma);
            BigInteger sum = BigInteger.Zero;
            bool sign = true;
            for (int i = 1; true; i += 2)
            {
                var cur = mag / (BigInteger.Pow(x, i) * i);
                if (sign)
                {
                    sum += cur;
                }
                else
                {
                    sum -= cur;
                }
                yield return sum;
                sign = !sign;
            }
        }

    }


}
