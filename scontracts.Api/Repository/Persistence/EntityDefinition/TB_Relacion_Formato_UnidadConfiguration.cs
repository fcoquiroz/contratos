using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Relacion_Formato_UnidadConfiguration : EntityTypeConfiguration<TB_Relacion_Formato_Unidad>
    {
        public override void Map(EntityTypeBuilder<TB_Relacion_Formato_Unidad> modelBuilder)
        {
            modelBuilder.ToTable("TB_Relacion_Formato_Unidad");
            modelBuilder.HasKey(p => p.ID_Relacion);
            modelBuilder.Property(c => c.ID_FormatoLiberado).IsRequired();
            modelBuilder.Property(c => c.ID_UnidadUsuario).IsRequired();
            modelBuilder.Property(c => c.Activo).IsRequired();

        }
    }
}
