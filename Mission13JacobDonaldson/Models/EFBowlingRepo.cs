using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Models
{
    public class EFBowlingRepo : IBowlingRepo
    {
        private BowlingDbContext context { get; set; }
        public EFBowlingRepo(BowlingDbContext temp)
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;
        public IQueryable<Team> Teams => context.Teams;

        public void SaveBowler(Bowler b)
        {
            context.Update(b);
            context.SaveChanges();
        }   
        public void CreateBowler(Bowler b)
        {
            context.Add(b);
            context.SaveChanges();
        }   
        public void DeleteBowler(Bowler b)
        {//delete works
            context.Bowlers.Remove(b);
            context.SaveChanges();
        }
    }
}
