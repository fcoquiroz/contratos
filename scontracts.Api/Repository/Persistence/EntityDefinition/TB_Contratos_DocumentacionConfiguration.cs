using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_DocumentacionConfiguration
    /// </summary>
    public class TB_Contratos_DocumentacionConfiguration : EntityTypeConfiguration<TB_Contratos_Documentacion>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Documentacion> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Documentacion");
            modelBuilder.HasKey(p => p.ID_Archivo);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ID_Documentacion).IsRequired();
            modelBuilder.Property(c => c.ID_Usuario);
            modelBuilder.Property(c => c.NombreArchivo).IsRequired().HasMaxLength(250);
            modelBuilder.Property(c => c.Extension).IsRequired().HasMaxLength(10);
            modelBuilder.Property(c => c.ContenttType).IsRequired().HasMaxLength(100);
            modelBuilder.Property(c => c.FechaCreacion);
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
