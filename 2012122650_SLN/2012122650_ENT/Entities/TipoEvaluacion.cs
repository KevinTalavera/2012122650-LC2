using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class TipoEvaluacion
    {
        public int codTipoEva { get; set; }
        public string nomTipoEva { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }

        public TipoEvaluacion()
        {
            Evaluacion = new Collection<Evaluacion>();
        }

    }
}
