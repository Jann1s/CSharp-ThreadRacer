using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class ThreadPool : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Func<bool>> functions = track.GetFunctions();

            int completionPortThreads;
            ThreadPool.GetAvailableThreads(out numberOfThreads, out completionPortThreads);

            //Dump work into threadpool
            //The threadpool will manage everything
            for (int i = 0; i < functions.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(functions, i);
              
            }

            // TODO: fix the instant return true
            return true;
        }
    }
}
