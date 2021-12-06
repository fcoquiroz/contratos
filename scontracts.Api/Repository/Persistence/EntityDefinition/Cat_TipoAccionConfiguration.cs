using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_TipoAccionConfiguration
    /// </summary>
    public class Cat_TipoAccionConfiguration : EntityTypeConfiguration<Cat_TipoAccion>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_TipoAccion> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoAccion");
            modelBuilder.HasKey(p => p.ID_TipoAccion);
            modelBuilder.Property(c => c.TipoAccion).IsRequired().HasMaxLength(50);
        }
    }
}

//install Microsoft.EntityFrameworkCore
//install Microsoft.EntityFrameworkCore.SqlServer
//install Microsoft.EntityFrameworkCore.Relational
//install Microsoft.EntityFrameworkCore.Design
//install Microsoft.Extensions.Configuration.Json
//install Microsoft.EntityFrameworkCore.Tools 
//install Microsoft.EntityFrameworkCore.Tools.DotNet optional
