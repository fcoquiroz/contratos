using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_LogConfiguration
    /// </summary>
    public class TB_LogConfiguration : EntityTypeConfiguration<TB_Log>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Log> modelBuilder)
        {
            modelBuilder.ToTable("TB_Log");
            modelBuilder.HasKey(p => p.Id_log);
            modelBuilder.Property(c => c.Usuario).HasMaxLength(100);
            modelBuilder.Property(c => c.Path).HasMaxLength(500);
            modelBuilder.Property(c => c.Control).HasMaxLength(50);
            modelBuilder.Property(c => c.Message).IsRequired();
            modelBuilder.Property(c => c.Date);
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
