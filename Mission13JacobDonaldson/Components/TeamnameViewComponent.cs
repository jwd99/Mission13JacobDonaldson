using Microsoft.AspNetCore.Mvc;
using Mission13JacobDonaldson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13JacobDonaldson.Components
{
    public class TeamnameViewComponent : ViewComponent
    {

        private IBowlingRepo repo { get; set; }

        public TeamnameViewComponent(IBowlingRepo temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeamname = RouteData?.Values["teamName"];

            var teamnames = repo.Bowlers
                .Select(t => t.Team.TeamName)
                .Distinct()
                .OrderBy(t => t);

            return View(teamnames);
        }
    }
}
