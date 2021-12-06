using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Historial_EstatusConfiguration
    /// </summary>
    public class TB_Historial_EstatusConfiguration : EntityTypeConfiguration<TB_Historial_Estatus>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Historial_Estatus> modelBuilder)
        {
            modelBuilder.ToTable("TB_Historial_Estatus");
            modelBuilder.HasKey(p => p.Id_HistorialEstatus);
            modelBuilder.Property(c => c.IdContrato);
            modelBuilder.Property(c => c.IdEstatus);
            modelBuilder.Property(c => c.Comentario).HasMaxLength(300);
            modelBuilder.Property(c => c.FechaAplicado);
            modelBuilder.Property(c => c.UsuarioAplico).HasMaxLength(50);
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
