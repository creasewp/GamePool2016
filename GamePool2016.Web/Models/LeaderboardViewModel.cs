using GamePool2016.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamePool2016.Models
{
    public class LeaderboardViewModel
    {
        public List<LeaderboardPlayerViewModel> Players { get; set; }
        public List<SelectListItem> Pools { get; set; }
        public string SelectedPoolId { get; set; }
    }

    public class LeaderboardPlayerViewModel
    {
        public string UserName { get; set; }
        public int PoolScore { get; set; }
        public int LostPoints { get; set; }
        public int PossiblePoints { get; set; }
        public double WinPercent { get; set; }
    }
}