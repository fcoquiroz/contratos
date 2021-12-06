using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_PantallasConfiguration
    /// </summary>
    public class Cat_PantallasConfiguration : EntityTypeConfiguration<Cat_Pantallas>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Pantallas> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Pantallas");
            modelBuilder.HasKey(p => p.ID_Pantalla);
            modelBuilder.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
            modelBuilder.Property(c => c.ID_Modulo).IsRequired();
            modelBuilder.Property(c => c.URL).HasMaxLength(150);
            modelBuilder.Property(c => c.Orden);
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
