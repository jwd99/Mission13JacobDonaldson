using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Models
{
    public class EFBowlingRepo : IBowlingRepo
    {
        private BowlingDbContext _context { get; set; }
        public EFBowlingRepo(BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
    }
}
