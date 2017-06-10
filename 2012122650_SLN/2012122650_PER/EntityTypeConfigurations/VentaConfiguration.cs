using _2012122650_ENT.Entities;
using _2012122650_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2012122650_PER.EntityTypeConfigurations
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
        {
           
            HasRequired(e => e.Evaluacion)
                .WithMany(v => v.Ventas)
                .HasForeignKey(v => v.EvaluacionId);

        }
    }
}
