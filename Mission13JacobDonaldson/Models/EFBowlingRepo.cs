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
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowler(Bowler b)
        {
            _context.SaveChanges();
        }   
        public void CreateBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }   
        public void DeleteBowler(Bowler b)
        {//delete works
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
        }
    }
}
