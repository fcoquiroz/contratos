using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Base_UnidadesConfiguration
    /// </summary>
    public class TB_Base_UnidadesConfiguration : EntityTypeConfiguration<TB_Base_Unidades>
    {
        public override void Map(EntityTypeBuilder<TB_Base_Unidades> modelBuilder)
        {
            modelBuilder.ToTable("TB_Base_Unidades");
            modelBuilder.HasKey(p => p.ID);
            modelBuilder.Property(c => c.Socio).HasMaxLength(510);
            modelBuilder.Property(c => c.Usuario).HasMaxLength(510);
            modelBuilder.Property(c => c.Puesto).HasMaxLength(510);
            modelBuilder.Property(c => c.Unidad).HasMaxLength(510);
            modelBuilder.Property(c => c.UnidadNueva).HasMaxLength(510);
            modelBuilder.Property(c => c.F6).HasMaxLength(510);
            modelBuilder.Property(c => c.F7).HasMaxLength(510);
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
