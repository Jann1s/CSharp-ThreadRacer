using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Threading
{
    class ThreadPool : IThreading
    {
        public Start(func task, int numberOfCars)
        {
            //Get al the number of available threads
            int workerThreads;
            int completionPortThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);

            //Dump work into threadpool
            //The threadpool will manage everything
            for (int i = 0; i < numberOfCars; i++)
            {
                ThreadPool.QueueUserWorkItem(task, i);
            }
        }
    }
}
