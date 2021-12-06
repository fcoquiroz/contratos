using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// cat_IdiomaConfiguration
    /// </summary>
    public class cat_IdiomaConfiguration : EntityTypeConfiguration<cat_Idioma>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<cat_Idioma> modelBuilder)
        {
            modelBuilder.ToTable("cat_Idioma");
            modelBuilder.HasKey(p => p.idIdioma);
            modelBuilder.Property(c => c.Idioma).HasMaxLength(25);
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
