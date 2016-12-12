using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamePool2016.Data;
using GamePool2016.Models;
using System.Configuration;
using GamePool2016.Helpers;

namespace GamePool2016.Controllers
{
    [Authorize]
    public class PoolsController : Controller
    {
        private GamePoolContext db = new GamePoolContext();

        // GET: Pools
        public ActionResult Index()
        {
            //only return pools for the current user
            List<string> playerpools = db.Players.Include("Pools").Single(item => item.UserName == User.Identity.Name).Pools.Select(item => item.PoolId).ToList();
            
            return View(db.Pools.Where(item => playerpools.Contains(item.Id)));
        }

        public ActionResult JoinPrivate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JoinPrivate([Bind(Include = "JoinCode")] Pool pool)
        {
            //look for a match
            Pool match = db.Pools.Include("Games.Game").SingleOrDefault(item => item.JoinCode == pool.JoinCode);
            if (match == null)
                ModelState.AddModelError(string.Empty, "No pool with that code exists.");
            else
            {
                //add a player pool
                AddPlayerPool(match, false);
                return RedirectToAction("Index");

            }
            return View();
        }

        private void AddPlayerPool(Pool pool, bool create)
        {
            Player player = db.Players.Include("Pools").Single(item => item.UserName == User.Identity.Name);
            var playerPool = new PlayerPool() { Id = Guid.NewGuid().ToString(), PoolId = pool.Id, PlayerId = player.Id, IsValid = false };
            //make sure this player isn't already in this pool
            if (player.Pools.SingleOrDefault(item => item.PoolId == pool.Id) == null)
            {
                player.Pools.Add(playerPool);
                playerPool.Games = new List<PlayerPoolGame>();

                //if the poolgame game is null, fill them
                if (pool.Games.First().Game == null)
                {
                    foreach (PoolGame game in pool.Games)
                    {
                        game.Game = db.Games.Find(game.GameId);
                    }
                }

                int confidence = 1;
                foreach (PoolGame pgame in pool.Games.OrderBy(item => item.Game.GameDateTime, new StringToDateTimeComparer()))
                {
                    if (create)
                        db.PoolGames.Add(pgame);
                    playerPool.Games.Add(new PlayerPoolGame() { PlayerPoolId = playerPool.Id, PoolGameId = pgame.Id, Id = Guid.NewGuid().ToString(), Confidence = confidence, WinnerTeamId = string.Empty, IsValid = true });
                    confidence++;
                }
                //add this pool to the current player
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "You are already joined to that pool. Cannot join pool.");
            }
        }

        // GET: Pools/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = db.Pools.Find(id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            PoolDetailViewModel viewModel = new Models.PoolDetailViewModel();
            viewModel.Description = pool.Description;
            viewModel.Players = new List<Models.PlayerPoolViewModel>();
            foreach (Player player in db.Players.Include("Pools").Where(item => item.Pools.Any(p => p.PoolId == pool.Id)))
            {
                PlayerPoolViewModel vm = new PlayerPoolViewModel();
                vm.PlayerName = player.UserName;
                vm.IsValid = player.Pools.Single(item => item.PoolId == pool.Id).IsValid;
                viewModel.Players.Add(vm);
            }
            return View(viewModel);
        }

        // GET: Pools/Create
        public ActionResult Create()
        {
            bool isLocked = bool.Parse(ConfigurationManager.AppSettings["IsLocked"]);
            var model = new Pool();
            model.Games = new List<PoolGame>();
            if (isLocked)
                ModelState.AddModelError("", "Cannot create new pool. Games have started.");
            else
            {
                model.Id = Guid.NewGuid().ToString();
                using (GamePool2016.Data.GamePoolContext context = new Data.GamePoolContext())
                {
                    var games = context.Games.ToList();
                    foreach (Game game in games.OrderBy(item => item.GameDateTime, new StringToDateTimeComparer()))
                    {
                        model.Games.Add(new PoolGame() { Id = Guid.NewGuid().ToString(), GameId = game.Id, Game = game, PoolId = model.Id, Pool = model, IsSelected = true });
                    }
                }
            }

            return View(model);
        }

        // POST: Pools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsPublic,Games")] Pool pool)
        {
            if (ModelState.IsValid)
            {
                //pool name unique?
                var apool = db.Pools.SingleOrDefault(item => item.Description == pool.Description);
                if (apool != null)
                    ModelState.AddModelError(string.Empty, "A pool with that name already exists. Please enter a different name");
                else
                {
                    pool.Id = Guid.NewGuid().ToString();
                    //create a join code
                    pool.JoinCode = GenerateJoinCode();
                    db.Pools.Add(pool);
                    AddPlayerPool(pool, true);
                    return RedirectToAction("Index");
                }
            }

            return View(pool);
        }

        private char[] chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();
        private string GenerateJoinCode()
        {
            string result = string.Empty;
            //random 6 chars from available list
            Random random = new Random();
            for (int i=0; i< 6; i++)
            {
                result += chars[random.Next(chars.Length - 1)];
            }
            return result;
        }

        // GET: Pools/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = db.Pools.Find(id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            return View(pool);
        }

        // POST: Pools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsPublic")] Pool pool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pool);
        }

        // GET: Pools/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pool pool = db.Pools.Find(id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            return View(pool);
        }

        // POST: Pools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pool pool = db.Pools.Find(id);
            db.Pools.Remove(pool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
