using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission13JacobDonaldson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Components
{
    public class ModalpopViewComponent : ViewComponent
    {

        private IBowlingRepo repo { get; set; }

        public ModalpopViewComponent(IBowlingRepo temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeamname = RouteData?.Values["teamName"];

            var holderthing = repo.Bowlers
                .ToList();
            return View(holderthing);
        }
    }
}
