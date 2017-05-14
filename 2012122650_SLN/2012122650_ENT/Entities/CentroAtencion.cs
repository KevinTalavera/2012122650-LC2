using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class CentroAtencion
    {
        public int codCentroAten { get; set; }
        public string sucursal { get; set; }
        public Direccion Direccion { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }
        public ICollection<Venta> Venta { get; set; }

        public CentroAtencion()
        {
            Evaluacion = new Collection<Evaluacion>();
            Venta = new Collection<Venta>();
        }
    }
}
