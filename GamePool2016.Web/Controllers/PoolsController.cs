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
            Pool match = db.Pools.SingleOrDefault(item => item.JoinCode == pool.JoinCode);
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
            Player player = db.Players.Single(item => item.UserName == User.Identity.Name);
            var playerPool = new PlayerPool() { Id = Guid.NewGuid().ToString(), PoolId = pool.Id, PlayerId = player.Id };
            player.Pools.Add(playerPool);
            playerPool.Games = new List<PlayerPoolGame>();
            foreach (PoolGame pgame in pool.Games)
            {
                if (create)
                    db.PoolGames.Add(pgame);
                playerPool.Games.Add(new PlayerPoolGame() { PlayerPoolId = playerPool.Id, PoolGameId = pgame.Id, Id = Guid.NewGuid().ToString(), Confidence = 0, WinnerTeamId = string.Empty });
            }
            //add this pool to the current player
            db.SaveChanges();
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
            return View(pool);
        }

        // GET: Pools/Create
        public ActionResult Create()
        {
            var model = new Pool();
            model.Id = Guid.NewGuid().ToString();
            model.Games = new List<PoolGame>();
            using (GamePool2016.Data.GamePoolContext context = new Data.GamePoolContext())
            {
                foreach (Game game in context.Games)
                {
                    model.Games.Add(new PoolGame() { Id = Guid.NewGuid().ToString(), GameId = game.Id, Game = game, PoolId = model.Id, Pool = model, IsSelected = true});
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
                pool.Id = Guid.NewGuid().ToString();
                //create a join code
                pool.JoinCode = GenerateJoinCode();
                db.Pools.Add(pool);
                AddPlayerPool(pool, true);
                return RedirectToAction("Index");
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
