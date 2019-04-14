using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thread = System.Threading.Tasks;
using ThreadRacer.Threading;
using ThreadRacer.Tracks;

namespace ThreadRacer
{
    class Race
    {
        private List<Car> cars = new List<Car>();
        public ITrack track { get; set; }

        public Race()
        {
            
        }

        public void AddCar(IThreading threadingMethod, int numberOfThreads)
        {
            cars.Add(new Car(threadingMethod, numberOfThreads));
        }

        public void StartRace()
        {
            foreach (Car car in cars)
            {
                car.Start(track);
            }
        }

        public Dictionary<string, long> GetResult()
        {
            Dictionary<string, long> result = new Dictionary<string, long>();

            foreach (Car car in cars)
            {
                result.Add(car.GetThreadMethod(), car.GetTime());
            }

            if (result.ContainsValue(0))
            {
                result = new Dictionary<string, long>();
            }

            return result;
        }

        private void CheckFinished()
        {
            bool finished = true;

            foreach (Car car in cars)
            {
                if (car.GetTime() == 0)
                {
                    Thread.Task.Delay(1000).Wait();
                    finished = false;
                }
            }

            if (!finished)
            {
                CheckFinished();
            }
        }
    }
}
