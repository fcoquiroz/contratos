using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Log2Configuration
    /// </summary>
    public class TB_Log2Configuration : EntityTypeConfiguration<TB_Log2>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Log2> modelBuilder)
        {
            modelBuilder.ToTable("TB_Log2");
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
