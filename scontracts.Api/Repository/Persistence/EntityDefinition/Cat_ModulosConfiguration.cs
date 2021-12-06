using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_ModulosConfiguration
    /// </summary>
    public class Cat_ModulosConfiguration : EntityTypeConfiguration<Cat_Modulos>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Modulos> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Modulos");
            modelBuilder.HasKey(p => p.ID_Modulo);
            modelBuilder.Property(c => c.Modulo).IsRequired().HasMaxLength(100);
            modelBuilder.Property(c => c.Icono).HasMaxLength(100);
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
