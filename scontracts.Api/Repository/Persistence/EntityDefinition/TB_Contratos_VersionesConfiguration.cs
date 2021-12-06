using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_VersionesConfiguration
    /// </summary>
    public class TB_Contratos_VersionesConfiguration : EntityTypeConfiguration<TB_Contratos_Versiones>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Versiones> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Versiones");
            modelBuilder.HasKey(p => p.ID_Contrato_Version);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ID_UsuarioEnvio).IsRequired();
            modelBuilder.Property(c => c.ID_TipoAccion).IsRequired();
            modelBuilder.Property(c => c.Version);
            modelBuilder.Property(c => c.NombreContrato).HasMaxLength(250);
            modelBuilder.Property(c => c.Extension).HasMaxLength(50);
            modelBuilder.Property(c => c.ContenttType).HasMaxLength(100);
            modelBuilder.Property(c => c.Comentarios);
            modelBuilder.Property(c => c.FechaCreacion).IsRequired();
            modelBuilder.Property(c => c.EvidenciaCancelacion).HasMaxLength(250);
            modelBuilder.Property(c => c.Agrupar);
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
