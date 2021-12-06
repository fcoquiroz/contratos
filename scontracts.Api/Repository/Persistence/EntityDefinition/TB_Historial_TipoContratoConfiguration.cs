using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Historial_TipoContratoConfiguration
    /// </summary>
    public class TB_Historial_TipoContratoConfiguration : EntityTypeConfiguration<TB_Historial_TipoContrato>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Historial_TipoContrato> modelBuilder)
        {
            modelBuilder.ToTable("TB_Historial_TipoContrato");
            modelBuilder.HasKey(p => p.IdHistorialTipoContrato);
            modelBuilder.Property(c => c.IdContrato);
            modelBuilder.Property(c => c.IdTipoContratoAnterior);
            modelBuilder.Property(c => c.IdTipoContratoNueva);
            modelBuilder.Property(c => c.UsuarioAplico).HasMaxLength(50);
            modelBuilder.Property(c => c.FechaAplicacion);
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
