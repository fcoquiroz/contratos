using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Usuario_ContraseniasConfiguration
    /// </summary>
    public class TB_Usuario_ContraseniasConfiguration : EntityTypeConfiguration<TB_Usuario_Contrasenias>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Usuario_Contrasenias> modelBuilder)
        {
            modelBuilder.ToTable("TB_Usuario_Contrasenias");
            modelBuilder.HasKey(p => p.ID_Usuario);
            modelBuilder.Property(c => c.Pwd1).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd2).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd3).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd4).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd5).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd6).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd7).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd8).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd9).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd10).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd11).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd12).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd13).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd14).HasMaxLength(50);
            modelBuilder.Property(c => c.Pwd15).HasMaxLength(50);
            modelBuilder.Property(c => c.UltimoPwd).HasMaxLength(50);
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
