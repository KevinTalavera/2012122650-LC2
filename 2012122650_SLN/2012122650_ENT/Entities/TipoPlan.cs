using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class TipoPlan
    {
        public int codTipoPlan { get; set; }
        public string nomTipoPlan { get; set; }
        public ICollection<Plan> Plan { get; set; }

        public TipoPlan()
        {
            Plan = new Collection<Plan>();
        }
    }
}
