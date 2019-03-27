using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Tracks;
using Windows.Foundation;
using TP = Windows.System.Threading;

namespace ThreadRacer.Threading
{
    class ThreadPool : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Func<bool>> functions = track.GetFunctions();

            uint totalFunctionsCompleted = 0;
            for (int i = 0; i < functions.Count; i++)
            {
                IAsyncAction asyncAction = TP.ThreadPool.RunAsync((workItem) =>
                {
                    functions[i]();
                });

                // task is complete
               asyncAction.Completed = new AsyncActionCompletedHandler((IAsyncAction asyncInfo, AsyncStatus asyncStatus) =>
               {
                   totalFunctionsCompleted++;
               });
            }

            if(functions.Count == totalFunctionsCompleted)
            {
                return true;
            }
            return false;
        }
    }
}