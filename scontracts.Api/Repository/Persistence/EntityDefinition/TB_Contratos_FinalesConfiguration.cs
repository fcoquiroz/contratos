using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_FinalesConfiguration
    /// </summary>
    public class TB_Contratos_FinalesConfiguration : EntityTypeConfiguration<TB_Contratos_Finales>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Finales> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Finales");
            modelBuilder.HasKey(p => p.ID_ContratoFinal);
            modelBuilder.Property(c => c.ID_Contrato);
            modelBuilder.Property(c => c.ID_HistorialContrato);
            modelBuilder.Property(c => c.ContentType).IsRequired().HasMaxLength(250);
            modelBuilder.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            modelBuilder.Property(c => c.Extension).IsRequired().HasMaxLength(20);
            modelBuilder.Property(c => c.Historico).IsRequired();
            modelBuilder.Property(c => c.FechaAdjunto).IsRequired();
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
