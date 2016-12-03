using GamePool2016.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Player")]
        public string UserName { get; set; }
        [Display(Name = "Score")]
        public int PoolScore { get; set; }
        [Display(Name = "Lost")]
        public int LostPoints { get; set; }
        [Display(Name = "Possible")]
        public int PossiblePoints { get; set; }
        [Display(Name = "Win %")]
        public double WinPercent { get; set; }
        [Display(Name = "")]
        public bool IsValid { get; set; }
    }
}