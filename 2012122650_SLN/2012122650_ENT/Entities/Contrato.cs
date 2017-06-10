using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        public DateTime FechaContrato { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; }

        public Contrato()
        {
            Venta = new Venta();
        }
    }
}
