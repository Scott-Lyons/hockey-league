using System.Linq;
using System.Web.Mvc;
using DataAccess.Command;
using DataAccess.Query;
using Domain;
using Web.Models;

namespace Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerCommand _playerCommand;
        private readonly IPlayerQuery _playerQuery;

        public PlayerController(IPlayerCommand playerCommand, IPlayerQuery playerQuery)
        {
            _playerCommand = playerCommand;
            _playerQuery = playerQuery;
        }

        // GET: Player/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Player/Create
        [HttpGet]
        public ActionResult Create()
        {
            return createPlayerCreateView();
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(PlayerModel playerModel)
        {
            if (!ModelState.IsValid)
            {
                return createPlayerCreateView();
            }

            _playerCommand.Add(new Player
            {
                Name = playerModel.Name,
                DateOfBirth = playerModel.DateOfBirth,
                TimeInTeam = playerModel.TimeInTeam,
                PlayerPositionIdx = playerModel.PositionIdx
            });

            return RedirectToAction("Index", "Home");
        }

        private ViewResult createPlayerCreateView()
        {
            var playerModel = new PlayerModel
            {
                PlayerPositions = _playerQuery.ListPositions().Select(position => (PlayerPositionModel)position)
            };

            return View(playerModel);
        }
    }
}