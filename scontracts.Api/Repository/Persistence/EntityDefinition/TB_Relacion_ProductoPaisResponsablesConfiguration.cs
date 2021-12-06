using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Relacion_ProductoPaisResponsablesConfiguration : EntityTypeConfiguration<TB_Relacion_ProductoPaisResponsables>
    {
        public override void Map(EntityTypeBuilder<TB_Relacion_ProductoPaisResponsables> modelBuilder)
        {
            modelBuilder.ToTable("TB_Relacion_ProductoPaisResponsables");
            modelBuilder.HasKey(p => p.Id_Relacion);
            modelBuilder.Property(c => c.Id_Producto);
            modelBuilder.Property(c => c.ID_Pais);
            modelBuilder.Property(c => c.ID_Responsable);
            modelBuilder.Property(c => c.Activo);
        }
    }
}
