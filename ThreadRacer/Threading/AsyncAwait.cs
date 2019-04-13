using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thread = System.Threading.Tasks;
using System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class AsyncAwait : IThreading
    {
        public async bool Start(ITrack track, int numberOfThreads)
        {
            List<Thread.Task> tasks = new List<Thread.Task>();
            List<Func<bool>> functions = track.GetFunctions();

            int index = 0;
            int methodCount = functions.Count / numberOfThreads;
            int buffer = functions.Count % numberOfThreads;

            for (int i = 0; i < numberOfThreads; i++)
            {
                if (index < functions.Count)
                {
                    Thread.Task task = new Thread.Task(() =>
                    {
                        functions[index]();
                        index++;

                        if (buffer >= 1)
                        {
                            await functions[index]();
                            index++;
                        }
                    });

                    tasks.Add(task);
                }
            }

            foreach (Thread.Task t in tasks)
            {
                t.Start();
            }

            Thread.Task.WaitAll(tasks.ToArray());

            return true;
        }






        //public bool Start(ITrack track, int numberOfThreads)
        //{
        //    List<Func<bool>> functions = track.GetFunctions();

        //    for (int i = 0; i < functions.Count; i++)
        //    {
        //        // custom implementation here 
        //    }

        //    //wait for the tasks to complete and then return true

        //    return true;
        //}
    }
}
