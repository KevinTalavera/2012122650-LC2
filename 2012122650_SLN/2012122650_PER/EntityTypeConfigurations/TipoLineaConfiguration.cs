using _2012122650_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_PER.EntityTypeConfigurations
{
    class TipoLineaConfiguration : EntityTypeConfiguration<TipoLinea>
    {
        public TipoLineaConfiguration()
        {
            ToTable("TipoLinea");
            HasKey(a => a.codTipoLinea);

        }
    }
}
