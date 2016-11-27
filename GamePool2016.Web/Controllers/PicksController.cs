using GamePool2016.Data;
using GamePool2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamePool2016.Controllers
{
    [Authorize]
    public class PicksController : Controller
    {
        private GamePoolContext db = new GamePoolContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyPicks(MyPicksViewModel viewModel)
        {
            //ViewBag.Message = "My Picks";
            if (viewModel == null)
                viewModel = new MyPicksViewModel();
            viewModel.Player = db.Players
                .Include("Pools.Games.PoolGame.Game.HomeTeam")
                .Include("Pools.Games.PoolGame.Game.AwayTeam")
                .Single(item => item.UserName == User.Identity.Name);
            foreach (var pool in viewModel.Player.Pools)
            {
                pool.Games = pool.Games.OrderBy(item => item.PoolGame.Game.GameDateTime).ToList();
            }
            viewModel.Pools = new List<SelectListItem>();
            //TODO 
            foreach (Pool pool in db.Pools)//.Where(item => viewModel.Player.Pools.Select(i => i.Id).Contains(item.Id)))
            {
                foreach (var playerPool in viewModel.Player.Pools)
                {
                    if (playerPool.PoolId == pool.Id)
                    {
                        SelectListItem sli = new SelectListItem();
                        sli.Value = playerPool.Id;
                        sli.Text = pool.Description;
                        viewModel.Pools.Add(sli);
                        break;
                    }
                }
            }
            if (viewModel.SelectedPoolId == null)
                viewModel.SelectedPoolId = viewModel.Player.Pools.First().Id;
            viewModel.IsLocked = false;//TODO
            return View(viewModel);
        }


        public ActionResult Leaderboard()
        {
            ViewBag.Message = "Leaderboard";

            return View();
        }

    }
}