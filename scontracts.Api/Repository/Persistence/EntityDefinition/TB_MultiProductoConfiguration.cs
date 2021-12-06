using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_MultiProductoConfiguration : EntityTypeConfiguration<TB_MultiProducto>
    {
        public override void Map(EntityTypeBuilder<TB_MultiProducto> modelBuilder)
        {
            modelBuilder.ToTable("Tb_MultiProducto");
            modelBuilder.HasKey(p => p.ID_MultiProducto);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ID_Producto);
            modelBuilder.Property(c => c.Activo);
        }
    }
}
