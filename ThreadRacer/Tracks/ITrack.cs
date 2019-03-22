using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadRacer.Tracks
{
    interface ITrack
    {
        List<Func<bool>> GetFunctions();
    }
}
