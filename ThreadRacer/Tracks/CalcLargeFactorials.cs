using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class CalcLargeFactorials : ITrack
    {
        private List<Func<bool>> functions;
        const uint FACTORIAL_LARGE = 5000;
        const uint FACTORIAL_LARGER = 10000;
        const uint FACTORIAL_LARGEST = 15000;

        public CalcLargeFactorials()
        {
            functions = new List<Func<bool>>();
            functions.Add(CalcLargeFactorial);
            functions.Add(CalcLargerFactorial);
            functions.Add(CalcLargestFactorial);
        }

        public List<Func<bool>> GetFunctions()
        {
            return functions;
        }

        private bool CalcLargeFactorial()
        {
            return CalculateFactorial(FACTORIAL_LARGE);
        }

        private bool CalcLargerFactorial()
        {
            return CalculateFactorial(FACTORIAL_LARGER);
        }

        private bool CalcLargestFactorial()
        {
            return CalculateFactorial(FACTORIAL_LARGEST);
        }

        private bool CalculateFactorial(uint factorial)
        {
            var bi = new BigInteger(1);
            for (var i = 1; i <= factorial; i++)
            {
                bi *= i;
            }
            return true;
        }
    }
}
