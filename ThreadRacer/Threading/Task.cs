using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadRacer.Tracks;

namespace ThreadRacer.Threading
{
    class Task
    {
        public float Start(ITrack track)
        {
            int maxThreads = 5;
            List<System.Threading.Tasks.Task> tasks = new List<System.Threading.Tasks.Task>();

            List<Func<int>> methods = new List<Func<int>>();
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);
            methods.Add(TestTask);

            int index = 0;
            int methodCount = methods.Count / maxThreads;
            int buffer = methods.Count % maxThreads;

            for (int i = 0; i < maxThreads; i++)
            {
                System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() =>
                {
                    for (int j = 0; j < methodCount; j++)
                    {
                        methods[index]();
                        index++;
                    }
                });

                tasks.Add(task);
            }

            foreach(System.Threading.Tasks.Task t in tasks)
            {
                t.Start();
            }

            return 0;
        }

        private int TestTask()
        {
            for (int i = 0; i < 10000000; i++)
            {
                float test = (156 / 5) * i;
            }

            return 0;
        }
    }
}
