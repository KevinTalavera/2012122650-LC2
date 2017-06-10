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
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
           
            HasRequired(c => c.Provincia)
                .WithMany(c => c.Distritos)
                .HasForeignKey(c => c.ProvinciaId);
        }
    }
}
