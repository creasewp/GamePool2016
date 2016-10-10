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

        public virtual ICollection<PlayerPoolGame> Games { get; set; }
        public bool IsAdmin { get; set; }
    }
}
