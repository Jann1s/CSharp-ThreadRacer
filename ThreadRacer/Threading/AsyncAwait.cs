using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Threading
{
    class AsyncAwait : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Func<bool>> functions = track.GetFunctions();

            for (int i = 0; i < functions.Count; i++)
            {
                    // custom implementation here 
            }

            //wait for the tasks to complete and then return true

           
     

            return true;
        }
    }
}
