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
            for (int i = 0; i < cars.Count; i++)
            {
                if (i != 0)
                {
                    if (IsFinished(cars[i - 1]))
                    {
                        cars[i].Start(track);
                    }
                }
                else
                {
                    cars[i].Start(track);
                }
            }
        }

        private bool IsFinished(Car car)
        {
            if (car.IsFinished())
            {
                return true;
            }
            else
            {
                Thread.Task.Delay(1000).Wait();
                IsFinished(car);
            }

            return false;
        }

        public int AmountFinished()
        {
            int amount = 0;

            foreach (Car car in cars)
            {
                if (car.IsFinished())
                {
                    amount++;
                }
            }

            return amount;
        }

        public int AmountCars()
        {
            return cars.Count();
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
                result.Clear();
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

        public List<string> GetCars()
        {
            List<string> carList = new List<string>();

            foreach(Car car in cars)
            {
                carList.Add(car.GetThreadMethod());
            }

            return carList;
        }
    }
}
