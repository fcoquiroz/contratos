using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class Cat_TipoAutorizadorConfiguration : EntityTypeConfiguration<Cat_TipoAutorizador>
    {
        public override void Map(EntityTypeBuilder<Cat_TipoAutorizador> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoAutorizador");
            modelBuilder.HasKey(p => p.Id_TipoAutorizador);
            modelBuilder.Property(c => c.Descripcion).HasMaxLength(50);
            modelBuilder.Property(c => c.Activo).IsRequired();
        }
    }
}
