using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class Game : BaseEntity
    {
        public string Description { get; set; }

        public string HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public string AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        public byte HomeScore { get; set; }
        public byte AwayScore { get; set; }
        public string GameDateTime { get; set; }
        public string Network { get; set; }
        public bool IsGameFinished { get; set; }
        public int HomeSelectedCount { get; set; }
        public int AwaySelectedCount { get; set; }

    }
}
