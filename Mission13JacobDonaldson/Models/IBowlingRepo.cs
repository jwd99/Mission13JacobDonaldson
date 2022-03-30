using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Models
{
    public interface IBowlingRepo
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
