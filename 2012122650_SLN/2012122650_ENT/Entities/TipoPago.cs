using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class TipoPago
    {
        public int codTipoPago { get; set; }
        public string modoPago { get; set; }
        public ICollection<Venta> Venta { get; set; }

        public TipoPago()
        {
            Venta = new Collection<Venta>();
        }
    }
}
