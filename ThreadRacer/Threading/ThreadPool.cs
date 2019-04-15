using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Tracks;
using Windows.Foundation;
using Windows.System.Threading;
using TP = Windows.System.Threading;

namespace ThreadRacer.Threading
{
    class ThreadPool : IThreading
    {
        int totalCompleted;
        int needToComplete;

        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Func<bool>> functions = track.GetFunctions();
            needToComplete = functions.Count;

            foreach (Func<bool> func in functions)
            {
                // dump all the work to the threadpool
                IAsyncAction asyncAction = TP.ThreadPool.RunAsync(
                (workItem) =>
                {
                    func();
                });

                // tell threadpool what happens when the task is completed
                asyncAction.Completed = new AsyncActionCompletedHandler(
                       (IAsyncAction asyncInfo, AsyncStatus asyncStatus) =>
                       {
                           if (asyncStatus == AsyncStatus.Completed)
                           {
                               totalCompleted++;
                           }
                       });
            }

            return isAllCompleted();
        }

        // check if all the tasks are completed
        private bool isAllCompleted()
        {
            bool isAllDone = false;

                while (isAllDone == false)
                {
                    if(totalCompleted == needToComplete)
                    {
                        isAllDone = true;
                    }
                } 

            if(isAllDone)
            {
                return true;
            } else
            {
                return false;
            }
        }


    }
}