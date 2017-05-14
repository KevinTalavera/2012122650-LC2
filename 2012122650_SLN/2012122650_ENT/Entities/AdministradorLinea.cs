using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class AdministradorLinea
    {
        public int codAdmiLinea { get; set; }
        public int baseDatos { get; set; }
        public ICollection<LineaTelefonica> LineaTelefonica { get; set; }

        public AdministradorLinea()
        {
            LineaTelefonica = new Collection<LineaTelefonica>();
        }
    }
}
