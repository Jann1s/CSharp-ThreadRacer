using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    class Database
    {
        private List<Func<bool>> functions;

        public Database()
        {
            functions.Add(longTask1);
            functions.Add(longTask2);
            functions.Add(longTask3);
        }

        public List<Func<bool>> GetFunctions()
        {
            return functions;
        }

        private bool longTask1() {
            // do something what takes time

            return true;
        }

        private bool longTask2()
        {
            // do something what takes time

            return true;
        }

        private bool longTask3()
        {
            // do something what takes time

            return true;
        }
    }
}
