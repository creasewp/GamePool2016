using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class PoolGame : BaseEntity
    {
        public string PoolId { get; set; }
        public virtual Pool Pool { get; set; }
    }
}
