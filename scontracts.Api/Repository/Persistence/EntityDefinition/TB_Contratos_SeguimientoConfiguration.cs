using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_SeguimientoConfiguration
    /// </summary>
    public class TB_Contratos_SeguimientoConfiguration : EntityTypeConfiguration<TB_Contratos_Seguimiento>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Seguimiento> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Seguimiento");
            modelBuilder.HasKey(p => p.ID_Contrato_Seguimiento);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.DiasEstimados);
            modelBuilder.Property(c => c.DiasReales);
            modelBuilder.Property(c => c.DiasAdelanto);
            modelBuilder.Property(c => c.DiasRetraso);
            modelBuilder.Property(c => c.FechaEnvioContrato);
            modelBuilder.Property(c => c.FechaInicio);
            modelBuilder.Property(c => c.FechaVencimiento).IsRequired();
            modelBuilder.Property(c => c.CreateDate);
            modelBuilder.Property(c => c.ReCalculado);
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
