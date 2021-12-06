using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_CaratulaConfiguration : EntityTypeConfiguration<TB_Caratula>
    {
        public override void Map(EntityTypeBuilder<TB_Caratula> modelBuilder)
        {
            modelBuilder.ToTable("TB_Caratula");
            modelBuilder.HasKey(p => p.Id_Caratula);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(50);
            modelBuilder.Property(c => c.Plantilla).HasMaxLength(100);
        }
    }
}
