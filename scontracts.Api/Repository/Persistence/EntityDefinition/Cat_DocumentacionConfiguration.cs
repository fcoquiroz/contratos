using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_DocumentacionConfiguration
    /// </summary>
    public class Cat_DocumentacionConfiguration : EntityTypeConfiguration<Cat_Documentacion>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Documentacion> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Documentacion");
            modelBuilder.HasKey(p => p.ID_Documentacion);
            modelBuilder.Property(c => c.Documento).IsRequired().HasMaxLength(150);
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
