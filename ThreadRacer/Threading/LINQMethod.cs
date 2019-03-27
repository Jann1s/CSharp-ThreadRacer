using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thread = System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class LINQMethod : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
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
                            functions[index]();
                            index++;
                        }
                    });

                    tasks.Add(task);
                }
            }

            IEnumerable<Thread.Task> linqQuery = from task in tasks.AsParallel()
                                                 where task != null
                                                 select task;
            foreach (Thread.Task item in linqQuery)
            {
                item.Start();
            }

            Thread.Task.WaitAll(tasks.ToArray());

            return true;
        }
    }
}