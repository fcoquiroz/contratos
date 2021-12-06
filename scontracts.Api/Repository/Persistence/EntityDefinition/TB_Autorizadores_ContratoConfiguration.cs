using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Autorizadores_ContratoConfiguration : EntityTypeConfiguration<TB_Autorizadores_Contrato>
    {
        public override void Map(EntityTypeBuilder<TB_Autorizadores_Contrato> modelBuilder)
        {
            modelBuilder.ToTable("TB_Autorizadores_Contrato");
            modelBuilder.HasKey(p => p.IDAutorizadoresContrato);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.Id_Autorizador);
            modelBuilder.Property(c => c.Extra);
            modelBuilder.Property(c => c.Activo);
        }
    }
}
