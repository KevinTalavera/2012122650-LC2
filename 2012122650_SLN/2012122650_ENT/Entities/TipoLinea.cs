﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class TipoLinea
    {
        public int codTipoLinea { get; set; }
        public string nomTipoLinea { get; set; }
        public LineaTelefonica LineaTelefonica { get; set; }
    }
}
