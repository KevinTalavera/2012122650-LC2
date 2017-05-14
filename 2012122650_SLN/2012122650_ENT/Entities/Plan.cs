using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Plan
    {
        public int codPlan { get; set; }
        public double monto { get; set; }
        public TipoPlan TipoPlan { get; set; }
        public Evaluacion Evaluacion { get; set; }
    }
}
