using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Threading;
using ThreadRacer.Tracks;

namespace ThreadRacer
{
    class Car
    {
        private IThreading threadingMethod;
        private int numberOfThreads;

        private long time;
        private bool finished;

        public Car(IThreading method, int numberOfThreads)
        {
            threadingMethod = method;
            this.numberOfThreads = numberOfThreads;
            finished = false;
        }

        public void Start(ITrack track)
        {
            bool result = false;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            result = threadingMethod.Start(track, numberOfThreads);

            stopWatch.Stop();
            finished = result;
            time = stopWatch.ElapsedMilliseconds;
        }

        public long GetTime()
        {
            return time;
        }

        public bool IsFinished()
        {
            return finished;
        }

        public string GetThreadMethod()
        {
            if (threadingMethod is Threading.Task)
            {
                return "Task";
            }
            else if (threadingMethod is Threading.LINQMethod)
            {
                return "LINQ";
            }
            else if (threadingMethod is Threading.ThreadPool)
            {
                return "ThreadPool";
            }
            else if (threadingMethod is Threading.Single)
            {
                return "Single Thread";
            }
            else if (threadingMethod is Threading.AsyncAwait)
            {
                return "Async Await";
            }
            else
            {
                return "Nope";
            }
        }
    }
}
