using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Email_Supervisor_ContratoConfiguration : EntityTypeConfiguration<TB_Email_Supervisor_Contrato>
    {
        public override void Map(EntityTypeBuilder<TB_Email_Supervisor_Contrato> modelBuilder)
        {
            modelBuilder.ToTable("TB_Email_Supervisor_Contrato");
            modelBuilder.HasKey(p => p.ID_CorreoSupervisor);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.Email).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo);
        }
    }
}
