using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_HistorialConfiguration
    /// </summary>
    public class TB_Contratos_HistorialConfiguration : EntityTypeConfiguration<TB_Contratos_Historial>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Historial> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Historial");
            modelBuilder.HasKey(p => p.ID_Contrato_Historial);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ID_UsuarioCambio);
            modelBuilder.Property(c => c.FechaCambio).IsRequired();
            modelBuilder.Property(c => c.SolicitanteAnterior).HasMaxLength(150);
            modelBuilder.Property(c => c.SolicitanteNuevo).HasMaxLength(150);
            modelBuilder.Property(c => c.JuridicoAnterior).HasMaxLength(150);
            modelBuilder.Property(c => c.JuridicoNuevo).HasMaxLength(150);
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
