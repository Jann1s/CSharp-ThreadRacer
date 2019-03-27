using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class SingleThread : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Func<bool>> functions = track.GetFunctions();

            foreach (Func<bool> f in functions)
            {
                f();
            }

            return true;
        }
    }
}
