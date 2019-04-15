using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class CaclPI : ITrack
    {

        private List<Func<bool>> functions;
        private int smallPi = 10000;
        private int mediumPi = 100000;
        private int bigPi = 1000000;

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
            GetPi(smallPi, 1);
            return true;
        }

        public bool MediumPi()
        {
            GetPi(mediumPi, 1);
            return true;
        }

        public bool BigPi()
        {
            GetPi(bigPi, 1);
            return true;
        }
        
        private BigInteger GetPi(int digits, int iterations)
        {
            return 16 * CalcArcTan(5, digits).ElementAt(iterations)- 4 * CalcArcTan(239, digits).ElementAt(iterations);
        }

        private IEnumerable<BigInteger> CalcArcTan(int x, int digits)
        {
            var mag = BigInteger.Pow(10, digits);
            var sum = BigInteger.Zero;
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
