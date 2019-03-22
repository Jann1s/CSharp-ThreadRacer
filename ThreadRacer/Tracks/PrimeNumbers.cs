using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class PrimeNumbers
    {

        private List<Func<bool>> functions;

        public PrimeNumbers()
        {
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
            for(int i = 0; i <= Int32.MaxNumber; i++) {
                  if(isPrimeNumber(i)) {
                    primeNumbersCount++;
                  }  
            }
            return true;
        }

        // this function returns a list of prime numbers which are before the given number
        public bool PopulateArrayWithPrimeNumbers() {
            List<int> primeNumbers = new ArrayList();
            for(int i = 0; i <= Int32.MaxNumber; i++) {
                  if(isPrimeNumber(i)) {
                    primeNumbers.add(i);
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
                int boundry = (int) Math.Floor(Math.sqrt(value));

                for(int i = 2; i <= boundry; i++) {
                    if (value % i == 0) {
                        // number has no decimals
                        return false;
                    }
                }
            return true;
            }
        }    
    }
}
