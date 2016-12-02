using GamePool2016.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamePool2016.Models
{
    public class MyPicksViewModel
    {
        public Player Player { get; set; }
        public List<PlayerPoolGame> Games { get; set; }
        public List<SelectListItem> Pools { get; set; }
        public string SelectedPoolId { get; set; }
        public bool IsLocked { get; set; }
        public int PlayersInPool { get; set; }
    }
}