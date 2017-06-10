using _2012122650_ENT.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_PER.EntityTypeConfigurations
{
    public class CentroAtencionConfiguration : EntityTypeConfiguration<CentroAtencion>
    {
        public CentroAtencionConfiguration()
        {

            HasRequired(c => c.Ubigeo)
                   .WithMany(c => c.CentroAtencion)
                   .HasForeignKey(c => c.UbigeoId);

        }
    }
}
