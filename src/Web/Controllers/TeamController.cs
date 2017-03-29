using System;
using System.Web.Mvc;
using DataAccess.Command;
using Domain;
using Web.Models;

namespace Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamCommand _teamCommand;

        public TeamController(ITeamCommand teamCommand)
        {
            _teamCommand = teamCommand;
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View(new TeamModel());
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(TeamModel teamModel)
        {
            if (!ModelState.IsValid)
            {
                return View(teamModel);
            }

            _teamCommand.Add(new Team
            {
                Idx = Guid.NewGuid(),
                Name = teamModel.Name
            });

            return RedirectToAction("Index", "Home");
        }
    }
}