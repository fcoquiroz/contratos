using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_EstatusConfiguration
    /// </summary>
    public class Cat_EstatusConfiguration : EntityTypeConfiguration<Cat_Estatus>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Estatus> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Estatus");
            modelBuilder.HasKey(p => p.ID_Estatus);
            modelBuilder.Property(c => c.Estatus).IsRequired().HasMaxLength(100);
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
