using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class LineaTelefonica
    {
        public int codLineaTele { get; set; }
        public int numLinea { get; set; }
        public AdministradorLinea AdministradorLinea { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public Venta Venta { get; set; }
        public ICollection<TipoLinea> TipoLinea { get; set; }
        
        public LineaTelefonica()
        {
            TipoLinea = new Collection<TipoLinea>();
        }
    }
}
