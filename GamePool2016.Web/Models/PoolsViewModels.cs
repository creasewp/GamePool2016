using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamePool2016.Models
{
    public class CreatePoolViewModel
    {
        [Required]
        [Display(Name = "Description")]
        [StringLength(20)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Public?")]
        public bool IsPublic { get; set; }

        public List<PoolGameViewModel> Games { get; set; }

    }

    public class PoolGameViewModel
    {
        public string GameId { get; set; }
        public bool IsSelected { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string Description { get; set; }
    }
}