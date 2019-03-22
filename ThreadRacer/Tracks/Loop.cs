using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class Loop : ITrack
    {
        private List<Func<bool>> functions;

        public Loop()
        {
            functions.Add(EasyLoop);
            functions.Add(MediumLoop);
            functions.Add(HardLoop);
        }

        public List<Func<bool>> GetFunctions()
        {
            return functions;
        }

        private bool EasyLoop()
        {
            int count = Int32.MinValue;

            for (int i = 0; i < Int32.MaxValue; i++)
            {
                count += (2 / 2);
            }

            return true;
        }

        private bool MediumLoop()
        {
            int count = Int32.MinValue;

            for (double i = 0; i < Int32.MaxValue; i += 0.25)
            {
                count += (2 / 2);
            }

            return true;
        }

        private bool HardLoop()
        {
            List<int> numberList = new List<int>();

            for (int i = 0; i < Int32.MaxValue; i++)
            {
                numberList.Add(i);
            }

            int count = Int32.MinValue;

            foreach(int number in numberList)
            {
                count += ((2 / 2) * 2) - 1;
            }

            return true;
        }
    }
}
