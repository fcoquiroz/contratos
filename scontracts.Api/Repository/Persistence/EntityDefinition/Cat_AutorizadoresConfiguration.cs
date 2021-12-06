using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class Cat_AutorizadoresConfiguration : EntityTypeConfiguration<Cat_Autorizadores>
    {
        public override void Map(EntityTypeBuilder<Cat_Autorizadores> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Autorizadores");
            modelBuilder.HasKey(p => p.Id_Autorizador);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(50);
            modelBuilder.Property(c => c.Correo).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.TipoAutorizador);
            modelBuilder.Property(c => c.TipoCaratula);
            modelBuilder.Property(c => c.ID_usuario);
            
        }
    }
}
