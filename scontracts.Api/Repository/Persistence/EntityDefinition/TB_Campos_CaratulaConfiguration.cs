using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Campos_CaratulaConfiguration : EntityTypeConfiguration<TB_Campos_Caratula>
    {
        public override void Map(EntityTypeBuilder<TB_Campos_Caratula> modelBuilder)
        {
            modelBuilder.ToTable("TB_Campos_Caratula");
            modelBuilder.HasKey(p => p.Id_Campo);
            modelBuilder.Property(c => c.Id_Caratula);
            modelBuilder.Property(c => c.KeyCampo).HasMaxLength(40);
            modelBuilder.Property(c => c.NombreCampo).HasMaxLength(300);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.IdConstante);
        }
    }
}
