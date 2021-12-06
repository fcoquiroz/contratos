using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_ComercialConfiguration
    /// </summary>
    public class Cat_ComercialConfiguration : EntityTypeConfiguration<Cat_Comercial>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Comercial> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Comercial");
            modelBuilder.HasKey(p => p.ID_Comercial);
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
