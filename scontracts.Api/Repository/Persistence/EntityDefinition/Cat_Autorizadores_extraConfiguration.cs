using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class Cat_Autorizadores_extraConfiguration : EntityTypeConfiguration<Cat_Autorizadores_extra>
    {
        public override void Map(EntityTypeBuilder<Cat_Autorizadores_extra> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Autorizadores_extra");
            modelBuilder.HasKey(p => p.Id_Autorizador_extra);
            //modelBuilder.Property(c => c.Id_Autorizador_extra).UseIdentityColumn(1,1);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(50);
            modelBuilder.Property(c => c.Correo).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.TipoAutorizador);
            modelBuilder.Property(c => c.TipoCaratula);
            modelBuilder.Property(c => c.ID_Contrato);
            modelBuilder.Property(c => c.ID_Usuario);
            modelBuilder.Property(c => c.ID_Pais);
            modelBuilder.Property(c => c.ID_Producto);
        }
    }
}
