using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Detalle_CaratulaConfiguration : EntityTypeConfiguration<TB_Detalle_Caratula>
    {
        public override void Map(EntityTypeBuilder<TB_Detalle_Caratula> modelBuilder)
        {
            modelBuilder.ToTable("TB_Detalle_Caratula");
            modelBuilder.HasKey(p => p.Id_Detalle_Caratula);
            modelBuilder.Property(c => c.Id_Contrato).IsRequired();
            modelBuilder.Property(c => c.Id_Campo);
            modelBuilder.Property(c => c.Valor).HasMaxLength(8000);
        }
    }
}
