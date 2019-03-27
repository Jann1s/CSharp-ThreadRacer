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
            for(int i = 0; i <= Int32.MaxValue; i++) {
                  if(isPrimeNumber(i)) {
                    primeNumbersCount++;
                  }  
            }
            return true;
        }

        // this function returns a list of prime numbers which are before the given number
        public bool PopulateArrayWithPrimeNumbers() {
            List<int> primeNumbers = new List<int>();
            for(int i = 0; i <= Int32.MaxValue; i++) {
                  if(isPrimeNumber(i)) {
                    primeNumbers.Add(i);