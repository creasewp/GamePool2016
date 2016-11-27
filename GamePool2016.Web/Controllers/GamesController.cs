using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamePool2016.Data;

namespace GamePool2016.Controllers
{
    //[Authorize]
    public class GamesController : Controller
    {
        private GamePoolContext db = new GamePoolContext();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.AwayTeam).Include(g => g.HomeTeam);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Description");
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Description");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,HomeTeamId,AwayTeamId,HomeScore,AwayScore,GameDateTime,Network,IsGameFinished,HomeSelectedCount,AwaySelectedCount")] Game game)
        {
            if (ModelState.IsValid)
            {
                game.Id = Guid.NewGuid().ToString();
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Description", game.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Description", game.HomeTeamId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Description", game.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Description", game.HomeTeamId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,HomeTeamId,AwayTeamId,HomeScore,AwayScore,GameDateTime,Network,IsGameFinished,HomeSelectedCount,AwaySelectedCount")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AwayTeamId = new SelectList(db.Teams, "Id", "Description", game.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Description", game.HomeTeamId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
