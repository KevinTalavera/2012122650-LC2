﻿using _2012122650_ENT.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_PER.EntityTypeConfigurations
{
    public class ContratoConfiguration : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfiguration()
        {
            
            HasRequired(v => v.Venta)
                 .WithMany(c => c.Contratos)
                 .HasForeignKey(c => c.VentaId);

        }
    }
}
