using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_UnidadConfiguration
    /// </summary>
    public class Cat_UnidadConfiguration : EntityTypeConfiguration<Cat_Unidad>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Unidad> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Unidad");
            modelBuilder.HasKey(p => p.ID_Unidad);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(255);
            modelBuilder.Property(c => c.Activo);
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
