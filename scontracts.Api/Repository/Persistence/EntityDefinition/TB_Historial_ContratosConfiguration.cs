using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Historial_ContratosConfiguration
    /// </summary>
    public class TB_Historial_ContratosConfiguration : EntityTypeConfiguration<TB_Historial_Contratos>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Historial_Contratos> modelBuilder)
        {
            modelBuilder.ToTable("TB_Historial_Contratos");
            modelBuilder.HasKey(p => p.ID_HistorialContrato);
            modelBuilder.Property(c => c.ID_Estatus).IsRequired();
            modelBuilder.Property(c => c.ID_Unidad).IsRequired();
            modelBuilder.Property(c => c.ID_Proveedor).IsRequired();
            modelBuilder.Property(c => c.ID_TipoContrato).IsRequired();
            modelBuilder.Property(c => c.ID_TipoMoneda).IsRequired();
            modelBuilder.Property(c => c.ID_Unidad_Usuario).IsRequired();
            modelBuilder.Property(c => c.ID_ResponsableJuridico).IsRequired();
            modelBuilder.Property(c => c.Folio).IsRequired().HasMaxLength(20);
            modelBuilder.Property(c => c.FechaSolicitud).IsRequired();
            modelBuilder.Property(c => c.ComentariosEstatus).HasMaxLength(3500);
            modelBuilder.Property(c => c.ObjetoContrato).HasMaxLength(3000);
            modelBuilder.Property(c => c.Solicitante).IsRequired().HasMaxLength(250);
            modelBuilder.Property(c => c.FechaVencimientoContrato).HasMaxLength(250);
            modelBuilder.Property(c => c.Anio).IsRequired();
            modelBuilder.Property(c => c.Motivo).HasMaxLength(1000);
            modelBuilder.Property(c => c.FechaAccion);
            modelBuilder.Property(c => c.ContratoAdjunto);
            modelBuilder.Property(c => c.ID_TipoSolicitud);
            modelBuilder.Property(c => c.ValidoJuridico);
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
