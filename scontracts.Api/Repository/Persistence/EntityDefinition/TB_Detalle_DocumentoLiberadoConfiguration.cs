using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Detalle_DocumentoLiberadoConfiguration : EntityTypeConfiguration<TB_Detalle_DocumentoLiberado>
    {
        public override void Map(EntityTypeBuilder<TB_Detalle_DocumentoLiberado> modelBuilder)
        {
            modelBuilder.ToTable("TB_Detalle_DocumentoLiberado");
            modelBuilder.HasKey(p => p.ID_Detalle);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ID_Campo).IsRequired();
            modelBuilder.Property(c => c.Valor).IsRequired().HasMaxLength(100);
            modelBuilder.Property(c => c.Activo).IsRequired();
        }
    }
}
