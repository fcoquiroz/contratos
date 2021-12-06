using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cfg_CorreosConfiguration
    /// </summary>
    public class Cfg_CorreosConfiguration : EntityTypeConfiguration<Cfg_Correos>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cfg_Correos> modelBuilder)
        {
            modelBuilder.ToTable("Cfg_Correos");
            modelBuilder.HasKey(p => p.ID_Correo);
            modelBuilder.Property(c => c.Correo).IsRequired().HasMaxLength(8000);
            modelBuilder.Property(c => c.ID_Estatus);
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
