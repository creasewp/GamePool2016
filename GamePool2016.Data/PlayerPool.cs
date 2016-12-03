using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class PlayerPool : BaseEntity
    {
        public string PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public virtual List<PlayerPoolGame> Games { get; set; }
        public bool IsAdmin { get; set; }
        public string PoolId { get; set;}
        public virtual Pool Pool { get; set; }
        public bool IsEligible { get; set; }
        public int PoolScore { get; set; }
        public int LostPoints { get; set; }
        public int PossiblePoints { get; set; }
        public double WinPercent { get; set; }
        public bool IsValid { get; set; }

    }
}
