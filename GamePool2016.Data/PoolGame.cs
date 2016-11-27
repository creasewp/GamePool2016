using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class PoolGame : BaseEntity
    {
        public bool IsSelected { get; set; }
        public string PoolId { get; set; }
        public virtual Pool Pool { get; set; }
        public string GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
