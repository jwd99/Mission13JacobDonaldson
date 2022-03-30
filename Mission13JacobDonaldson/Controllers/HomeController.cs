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
       
        private IBowlingRepo _context { get; set; }
        public HomeController(IBowlingRepo hold)
        {
            _context = hold;
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
            var holderthing = _context.Bowlers
                .Include(b=>b.Team)
                .Where(t =>t.Team.TeamName == teamName || teamName == null)
                .ToList();
            return View(holderthing);
        }

    }
}
