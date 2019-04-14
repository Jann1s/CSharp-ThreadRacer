using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using microTasks = System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class AsyncAwait : IThreading
    {
        public bool Start(ITrack track, int numberOfThreads)
        {
            AsyncTask(track, numberOfThreads);
            return true;
        }

        public async void AsyncTask(ITrack track, int numberOfThreads)
        {
            List<microTasks.Task> tasks = new List<microTasks.Task>();
            List<Func<bool>> functions = track.GetFunctions();

            foreach (Func<bool> func in functions)
            {
                microTasks.Task task = new microTasks.Task(() =>
                {
                    func();
                });

                tasks.Add(task);
            }

            foreach (microTasks.Task t in tasks)
            {
                t.Start();
                await t;
            }
        }
    }
}
