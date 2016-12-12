using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class PlayerPoolGame : BaseEntity
    {
        public string PlayerPoolId { get; set; }

        public virtual PlayerPool PlayerPool { get; set; }
        public string PoolGameId { get; set; }
        public virtual PoolGame PoolGame { get; set; }
        public int Confidence { get; set; }
        public int PointsEarned { get; set; }

        public string WinnerTeamId { get; set; }
        public bool IsValid { get; set; }//isvalidconfidence
        
    }
}
