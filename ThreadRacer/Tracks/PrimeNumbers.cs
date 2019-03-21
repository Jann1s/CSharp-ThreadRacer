using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class PrimeNumbers
    {

       
        
        //this function returns the number of primary numbers which are lower than the given number
        public int calcPrimeNumbersBeforeMe(int number) {
            int primeNumbersCount = 0;
            for(int i = 0; i <= number; i++) {
                  if(isPrimeNumber(i)) {
                    Console.WriteLine("Prime number: " + i);
                    primeNumbersCount++;
                  }  
            }
            return primeNumbersCount;
        }

        // this function returns a list of prime numbers which are before the given number
        public List<int> getPrimeNumbersBeforeMe(int number) {
            List<int> primeNumbers = new ArrayList();
            for(int i = 0; i <= number; i++) {
                  if(isPrimeNumber(i)) {
                     Console.WriteLine("Prime number is added to the list: " + i);
                    primeNumbers.add(i);
                  }  
            }
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
        
        // validate
        private bool isNumberValid(int number) {
            if(number >= int.MaxValue) {
                return false;
            }
            return true;
        }
    }
}
