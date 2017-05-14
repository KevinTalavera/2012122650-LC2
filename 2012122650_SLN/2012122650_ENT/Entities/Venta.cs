using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Venta
    {
        public int codVenta { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public Contrato Contrato { get; set; }
        public CentroAtencion CentroAtencion { get; set; }
        public Cliente Cliente { get; set; }
        public TipoPago TipoPago { get; set; }
        public ICollection<LineaTelefonica> LineaTelefonica { get; set; }

        public Venta()
        {
            LineaTelefonica = new Collection<LineaTelefonica>();
        }
    }
}
