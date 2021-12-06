using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class Cat_ProductoConfiguration : EntityTypeConfiguration<Cat_Producto>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Producto> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Producto");
            modelBuilder.HasKey(p => p.Id_Producto);
            modelBuilder.Property(c => c.Descripcion).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo).IsRequired();
        }
    }
}
