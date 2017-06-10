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
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {
            
            HasRequired(d => d.Plan)
                 .WithMany(p => p.Evaluaciones)
                 .HasForeignKey(p => p.PlanId);

            HasRequired(t => t.Trabajador)
                .WithMany(e => e.Evaluaciones)
                .HasForeignKey(e => e.TrabajadorId);

            HasRequired(d => d.Cliente)
                .WithMany(p => p.Evaluaciones)
                .HasForeignKey(p => p.ClienteId);


            HasRequired(c => c.CentroAtencion)
                .WithMany(e => e.Evaluaciones)
                .HasForeignKey(e => e.CentroAtencionId);

            HasRequired(d => d.LineaTelefonica)
                 .WithMany(p => p.Evaluaciones)
                 .HasForeignKey(p => p.LineaTelefonicaId);

            HasRequired(d => d.EquipoCelular)
                 .WithMany(p => p.Evaluaciones)
                 .HasForeignKey(p => p.EquipoCelularId);

        }
    }
}
