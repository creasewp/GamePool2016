using GamePool2016.Data;
using GamePool2016.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            RefreshViewModel(viewModel);
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
            RefreshViewModel(viewModel);
            return View(viewModel);
        }

        private void RefreshViewModel(MyPicksViewModel viewModel)
        {
            viewModel.Player = db.Players
                .Include("Pools.Games.PoolGame.Game.HomeTeam")
                .Include("Pools.Games.PoolGame.Game.AwayTeam")
                .Single(item => item.UserName == User.Identity.Name);
            foreach (var pool in viewModel.Player.Pools)
            {
                pool.Games = pool.Games.OrderBy(item => item.PoolGame.Game.GameDateTime).ToList();
            }
            viewModel.Pools = GetPlayerPools(viewModel.Player);

            if (viewModel.SelectedPoolId == null)
                viewModel.SelectedPoolId = viewModel.Player.Pools.First().Id;
            viewModel.PlayersInPool = db.Players.Count(item => item.Pools.Any(p => p.Id == viewModel.SelectedPoolId));

            viewModel.Games = viewModel.Player.Pools.Single(item => item.Id == viewModel.SelectedPoolId).Games.Where(item => item.PoolGame.IsSelected).ToList();

            viewModel.IsLocked = bool.Parse(ConfigurationManager.AppSettings["IsLocked"]);
        }

        private List<SelectListItem> GetPlayerPools(Player player)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            //TODO 
            foreach (Pool pool in db.Pools)//.Where(item => viewModel.Player.Pools.Select(i => i.Id).Contains(item.Id)))
            {
                foreach (var playerPool in player.Pools)
                {
                    if (playerPool.PoolId == pool.Id)
                    {
                        SelectListItem sli = new SelectListItem();
                        sli.Value = playerPool.Id;
                        sli.Text = pool.Description;
                        result.Add(sli);
                        break;
                    }
                }
            }
            return result;
        }

        private List<SelectListItem> GetPoolsForPlayer(Player player)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            //TODO 
            foreach (Pool pool in db.Pools)//.Where(item => viewModel.Player.Pools.Select(i => i.Id).Contains(item.Id)))
            {
                foreach (var playerPool in player.Pools)
                {
                    if (playerPool.PoolId == pool.Id)
                    {
                        SelectListItem sli = new SelectListItem();
                        sli.Value = pool.Id;
                        sli.Text = pool.Description;
                        result.Add(sli);
                        break;
                    }
                }
            }
            return result;
        }
        public ActionResult Leaderboard()
        {
            ViewBag.Message = "Leaderboard";


            var viewModel = new LeaderboardViewModel();
            RefreshLeaderBoardViewModel(viewModel);

            return View(viewModel);
        }

        private void RefreshLeaderBoardViewModel(LeaderboardViewModel viewModel)
        {
            var player = db.Players.Include("Pools").Single(item => item.UserName == User.Identity.Name);
            viewModel.Pools = GetPoolsForPlayer(player);

            if (viewModel.SelectedPoolId == null)
                viewModel.SelectedPoolId = viewModel.Pools.First().Value;
            var tmpList = new List<Models.LeaderboardPlayerViewModel>();
            //get players in this pool
            var poolPlayers = db.Players.Where(item => item.Pools.Any(p => p.PoolId == viewModel.SelectedPoolId)).ToList();
            //load the playerpool for each player
            foreach (var poolPlayer in poolPlayers)
            {
                var playerPool = db.PlayerPools.Single(item => item.PoolId == viewModel.SelectedPoolId && item.PlayerId == poolPlayer.Id);
                var vm = new LeaderboardPlayerViewModel()
                {
                    UserName = poolPlayer.UserName,
                    PoolScore = playerPool.PoolScore,
                    LostPoints = playerPool.LostPoints,
                    PossiblePoints = playerPool.PossiblePoints,
                    WinPercent = playerPool.WinPercent
                };

                tmpList.Add(vm);
            }
            viewModel.Players = new List<LeaderboardPlayerViewModel>();
            viewModel.Players.AddRange(tmpList.OrderBy(item => item.PoolScore));
        }

        [HttpPost]
        public ActionResult Leaderboard(LeaderboardViewModel viewModel)
        {
            ViewBag.Message = "Leaderboard";

            RefreshLeaderBoardViewModel(viewModel);

            return View(viewModel);
        }

    }
}