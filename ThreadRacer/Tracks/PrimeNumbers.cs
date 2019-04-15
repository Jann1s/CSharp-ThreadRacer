using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class PrimeNumbers : ITrack
    {

        private List<Func<bool>> functions;

        public PrimeNumbers()
        {
            functions = new List<Func<bool>>();

            functions.Add(GetTotalPrimeNumbers);
            functions.Add(PopulateArrayWithPrimeNumbers);
        }

        public List<Func<bool>> GetFunctions()
        {
            return functions;
        }
        
        //this function returns the number of primary numbers which are lower than the given number
        public bool GetTotalPrimeNumbers() {
            int primeNumbersCount = 0;
            for(int i = 0; i <= 5000000; i++) {
                  if(isPrimeNumber(i)) {
                    primeNumbersCount++;
                  }  
            }
            return true;
        }

        // this function returns a list of prime numbers which are before the given number
        public bool PopulateArrayWithPrimeNumbers() {
            List<int> primeNumbers = new List<int>();
            for(int i = 0; i <= 10000000; i++) {
                  if(isPrimeNumber(i)) {
                    primeNumbers.Add(i);
                  }  
            }
            return true;
        }


        // prime number is the number which is dividible by itself and 1
        // we exclude 1 in this function
        private bool isPrimeNumber(int value) {
            if(value == 2) {
                return true;
            }                          

            if(value != 1) {
                int boundry = (int) Math.Floor(Math.Sqrt(value));

                for(int i = 2; i <= boundry; i++) {
                    if (value % i == 0) {
                        // number has no decimals
                        return false;
                    }
                }
                return true;
            }
            return false;
        }    
    }
}
