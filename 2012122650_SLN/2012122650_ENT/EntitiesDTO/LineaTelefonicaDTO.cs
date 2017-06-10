using _2012122650_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.EntitiesDTO
{
    public class LineaTelefonicaDTO
    {
        public int LineaTelefonicaId { get; set; }
        public int NumeroLinea { get; set; }

        public TipoLinea TipoLinea { get; set; }
    }
}
