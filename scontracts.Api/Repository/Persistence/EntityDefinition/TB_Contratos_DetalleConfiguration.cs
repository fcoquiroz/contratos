using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_DetalleConfiguration
    /// </summary>
    public class TB_Contratos_DetalleConfiguration : EntityTypeConfiguration<TB_Contratos_Detalle>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Detalle> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Detalle");
            modelBuilder.HasKey(p => p.ID_Contrato_Detalle);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ObjetoNegociacion).IsRequired();
            modelBuilder.Property(c => c.DescServiciosProductos).IsRequired();
            modelBuilder.Property(c => c.Contraprestacion).IsRequired();
            modelBuilder.Property(c => c.FormaPago).IsRequired();
            modelBuilder.Property(c => c.Vigencia).IsRequired();
            modelBuilder.Property(c => c.LugarFechaFirma).IsRequired();
            modelBuilder.Property(c => c.CondicionesEspeciales);
            modelBuilder.Property(c => c.ImporteTotalContrato);
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
