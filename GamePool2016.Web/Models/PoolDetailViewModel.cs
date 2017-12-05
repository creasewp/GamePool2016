using GamePool2016.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamePool2016.Models
{
    public class PlayerPoolViewModel
    {
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Pool Selections Valid?")]
        public bool IsValid { get; set; }
    }
    public class PoolDetailViewModel
    {
        [Display(Name = "Pool Name")]
        public string Description { get; set; }
        public List<PlayerPoolViewModel> Players { get; set; }
    }
}