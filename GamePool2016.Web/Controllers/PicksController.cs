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

        public ActionResult MyPicks()
        {
            //ViewBag.Message = "My Picks";
            var viewModel = new MyPicksViewModel();
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
            viewModel.PlayersInPool = db.Players.Count(item => item.Pools.Any(p => p.Id == viewModel.SelectedPoolId));

            viewModel.Games = viewModel.Player.Pools.Single(item => item.Id == viewModel.SelectedPoolId).Games.Where(item => item.PoolGame.IsSelected).ToList();

            viewModel.IsLocked = true;//TODO
            return View(viewModel);
        }

        [HttpPost]
        //[Bind(Include = "SelectedPoolId, Player, Pools")] 
        public ActionResult MyPicks(MyPicksViewModel viewModel)
        {
            //ViewBag.Message = "My Picks";

            //save any game changes
            foreach (PlayerPoolGame game in viewModel.Games)
            {
                //update game
                var dbGame = db.PlayerPoolGames.Single(item => item.Id == game.Id);
                dbGame.Confidence = game.Confidence;
                dbGame.WinnerTeamId = game.WinnerTeamId;
            }
            db.SaveChanges();

            //refresh what is sent to the browser
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
            viewModel.PlayersInPool = db.Players.Count(item => item.Pools.Any(p => p.Id == viewModel.SelectedPoolId));

            viewModel.Games = viewModel.Player.Pools.Single(item => item.Id == viewModel.SelectedPoolId).Games.Where(item => item.PoolGame.IsSelected).ToList();

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