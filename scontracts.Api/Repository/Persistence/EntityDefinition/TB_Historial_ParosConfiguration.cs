using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Historial_ParosConfiguration
    /// </summary>
    public class TB_Historial_ParosConfiguration : EntityTypeConfiguration<TB_Historial_Paros>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Historial_Paros> modelBuilder)
        {
            modelBuilder.ToTable("TB_Historial_Paros");
            modelBuilder.HasKey(p => p.Id_HistorialParos);
            modelBuilder.Property(c => c.IdContrato);
            modelBuilder.Property(c => c.FechaParo);
            modelBuilder.Property(c => c.FechaActivacion);
            modelBuilder.Property(c => c.Comentario);
            modelBuilder.Property(c => c.UsuarioAplicoParo).HasMaxLength(50);
            modelBuilder.Property(c => c.UsuarioAplicoActivacion).HasMaxLength(50);
            modelBuilder.Property(c => c.UltimoEstatus);
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
