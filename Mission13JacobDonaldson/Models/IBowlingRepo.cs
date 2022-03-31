using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Models
{
    public interface IBowlingRepo
    {
        IQueryable<Bowler> Bowlers { get; }


        void SaveBowler(Bowler b);
        void CreateBowler(Bowler b);
        void DeleteBowler(Bowler b);
    }
}
