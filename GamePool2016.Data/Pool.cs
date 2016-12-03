using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class Pool : BaseEntity
    {
        [Display(Name = "Pool Name")]
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public virtual List<PoolGame> Games { get; set; }
        [Display(Name = "Invitation Code")]
        public string JoinCode { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
