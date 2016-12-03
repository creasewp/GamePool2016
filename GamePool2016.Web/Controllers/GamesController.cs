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
            var games = db.Games.Include(g => g.AwayTeam).Include(g => g.HomeTeam).OrderBy(item => item.GameDateTime);
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
                DoCalc();
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

        public ActionResult Calc()
        {
            DoCalc();

            return RedirectToAction("Index");
        }

        private void DoCalc()
        {
            foreach (PoolGame poolGame in db.PoolGames.Include("Game").ToList())
            {
                poolGame.HomeSelectedCount = db.PlayerPoolGames.Count(item => item.WinnerTeamId == poolGame.Game.HomeTeamId);
                poolGame.AwaySelectedCount = db.PlayerPoolGames.Count(item => item.WinnerTeamId == poolGame.Game.AwayTeamId);
            }
            foreach (PlayerPool playerPool in db.PlayerPools.Include("Games.PoolGame.Game"))
            {
                if (playerPool.IsValid)
                {
                    int score = 0;
                    int lostPoints = 0;
                    int possiblePoints = 0;
                    int gamesCorrect = 0;
                    int gamesIncorrect = 0;

                    foreach (PlayerPoolGame playerPoolGame in playerPool.Games)
                    {
                        if (playerPoolGame.PoolGame.Game.IsGameFinished)
                        {
                            string winningTeamId = (playerPoolGame.PoolGame.Game.HomeScore > playerPoolGame.PoolGame.Game.AwayScore) ? playerPoolGame.PoolGame.Game.HomeTeamId : playerPoolGame.PoolGame.Game.AwayTeamId;
                            if (playerPoolGame.WinnerTeamId == winningTeamId)
                            {
                                score += playerPoolGame.Confidence;
                                playerPoolGame.PointsEarned = playerPoolGame.Confidence;
                                gamesCorrect++;
                            }
                            else
                            {
                                lostPoints += playerPoolGame.Confidence;
                                gamesIncorrect++;
                            }
                        }
                        else
                        {
                            possiblePoints += playerPoolGame.Confidence;
                        }
                    }
                    playerPool.PoolScore = score;
                    playerPool.LostPoints = lostPoints;
                    playerPool.PossiblePoints = possiblePoints;
                    if (gamesCorrect + gamesIncorrect > 0)
                        playerPool.WinPercent = (100 * Math.Round((double)((double)gamesCorrect / (double)(gamesCorrect + gamesIncorrect)), 3));
                    else
                        playerPool.WinPercent = 0;
                }
            }
            db.SaveChanges();
        }
    }
}
