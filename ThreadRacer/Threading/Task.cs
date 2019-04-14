using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thread = System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class Task : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            List<Thread.Task> tasks = new List<Thread.Task>();
            List<Func<bool>> functions = track.GetFunctions();

            int index = 0;
            int methodCount = functions.Count / numberOfThreads;
            int buffer = functions.Count % numberOfThreads;

            foreach (Func<bool> func in functions)
            {
                Thread.Task task = new Thread.Task(() =>
                {
                    func();
                });

                tasks.Add(task);
            }

            for (int i = 0; i < functions.Count; i++)
            {
                /*
                if (index < functions.Count)
                {
                    Thread.Task task = new Thread.Task(() =>
                    {
                        functions[i]();
                        /*
                        if (buffer >= 1)
                        {
                            functions[index]();
                            index++;
                        }
                        else
                        {
                            index++;
                        }
                    });

                    tasks.Add(task);

                    index++;
                }*/
            }

            foreach(Thread.Task t in tasks)
            {
                t.Start();
            }

            Thread.Task.WaitAll(tasks.ToArray());

            return true;
        }
    }
}
