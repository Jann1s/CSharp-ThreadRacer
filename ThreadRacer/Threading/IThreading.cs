using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    interface IThreading
    {
        bool Start(ITrack track, int numberOfThreads);
    }
}
