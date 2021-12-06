using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_PaisConfiguration
    /// </summary>
    public class Cat_PaisConfiguration : EntityTypeConfiguration<Cat_Pais>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Pais> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Pais");
            modelBuilder.HasKey(p => p.ID_Pais);
            modelBuilder.Property(c => c.Pais).HasMaxLength(250);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.Create_Date);
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
