using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class Single : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Func<bool>> functions = track.GetFunctions();

            foreach (Func<bool> func in functions)
            {
                func();
            }

            return true;
        }
    }
}
