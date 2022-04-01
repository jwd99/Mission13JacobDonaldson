using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13JacobDonaldson.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Controllers
{
    public class HomeController : Controller
    {
       
        private IBowlingRepo context { get; set; }
        public HomeController(IBowlingRepo hold)
        {
            context = hold;
        }

        public IActionResult Index(string teamName)
        {
            if(teamName != null)
            {
                ViewBag.TeamName = teamName;
            }
            else
            {
                ViewBag.TeamName = "Bowlers";
            }
            var holderthing = context.Bowlers
                .Include(b=>b.Teams)
                .Where(t =>t.Teams.TeamName == teamName || teamName == null)
                .ToList();
            return View(holderthing);
        }
        //editbowler
        [HttpGet]
        public IActionResult EditBowlerForm(int id, int teamid)
        {
            
            var holder = context.Bowlers.Single(x => x.BowlerID == id);
            //ViewBag.bowler = _context.Bowlers.FirstOrDefault(b => b.BowlerID == id);
            ViewBag.Trent = context.Teams.Single(x=> x.TeamID == teamid);
                //_context.Bowlers.Include(b => b.Team)
                //.Where(b => b.BowlerID == id).ToList();
            return View("EditBowlerForm", holder);
           
        }
        [HttpPost]
        public IActionResult EditBowlerForm(Bowler bwl)
        {
            if (ModelState.IsValid)
            {
          
                context.SaveBowler(bwl);
               
                
                return View("Confirmation", bwl);
            }
            else
            {//needs validation fix
              
                return View();
            }

        }
        [HttpGet]
        public IActionResult createBowlerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult createBowlerForm(Bowler bwl)
        {
            if (ModelState.IsValid)
            {

                context.CreateBowler(bwl);
            
                return View("Confirmation", bwl);
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult deleteBowler(int id)
        {
            var delBow = context.Bowlers.FirstOrDefault(b => b.BowlerID == id);
            if (delBow != null)
            {
                context.DeleteBowler(delBow);
            }
            return RedirectToAction("Index");
        }





        }
}
