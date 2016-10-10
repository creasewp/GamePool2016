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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyPicks()
        {
            ViewBag.Message = "My Picks";

            return View();
        }

        public ActionResult Leaderboard()
        {
            ViewBag.Message = "Leaderboard";

            return View();
        }

    }
}