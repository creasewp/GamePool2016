using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePool2016.Data
{
    public class Pool : BaseEntity
    {
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public virtual List<PoolGame> Games { get; set; }
        public string JoinCode { get; set; }
    }
}
