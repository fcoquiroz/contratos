using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_ProveedorConfiguration
    /// </summary>
    public class Cat_ProveedorConfiguration : EntityTypeConfiguration<Cat_Proveedor>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Proveedor> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Proveedor");
            modelBuilder.HasKey(p => p.ID_Proveedor);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(255);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.CreateDate);
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
