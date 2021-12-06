using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class Cat_TipoSolicitudConfiguration : EntityTypeConfiguration<Cat_TipoSolicitud>
    {
        public override void Map(EntityTypeBuilder<Cat_TipoSolicitud> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoSolicitud");
            modelBuilder.HasKey(p => p.IdTipoSolicitud);
            modelBuilder.Property(c => c.Descripcion).HasMaxLength(50);
            modelBuilder.Property(c => c.Activo).IsRequired();
        }
    }
}
