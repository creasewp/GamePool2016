using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class Player : BaseEntity
    {
        public bool IsSysadmin { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public bool IsLocked { get; set; }

        public bool IsEligible { get; set; }
        public int PoolScore { get; set; }
        public int LostPoints { get; set; }
        public int PossiblePoints { get; set; }
        public double WinPercent { get; set; }

        public virtual ICollection<PlayerPool> Pools { get; set; }
    }
}
