using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class Cat_FormatoLiberadosConfiguration : EntityTypeConfiguration<Cat_FormatoLiberados>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_FormatoLiberados> modelBuilder)
        {
            modelBuilder.ToTable("Cat_FormatoLiberados");
            modelBuilder.HasKey(p => p.ID_FormatoLiberado);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo).IsRequired();
            modelBuilder.Property(c => c.FechaRegistro);
            modelBuilder.Property(c => c.FechaModifico);
            modelBuilder.Property(c => c.Plantilla).HasMaxLength(100);
            modelBuilder.Property(c => c.Id_TipoDocumento);
            modelBuilder.Property(c => c.Id_TipoSolicitud);


        }
    }
}
