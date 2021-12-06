using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_EmailConfiguration
    /// </summary>
    public class TB_Contratos_EmailConfiguration : EntityTypeConfiguration<TB_Contratos_Email>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Email> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Email");
            modelBuilder.HasKey(p => p.ID_Contrato_Email);
            modelBuilder.Property(c => c.ID_Correo).IsRequired();
            modelBuilder.Property(c => c.ID_Contrato);
            modelBuilder.Property(c => c.Asunto).IsRequired().HasMaxLength(150);
            modelBuilder.Property(c => c.Body).IsRequired();
            modelBuilder.Property(c => c.Destinatarios).IsRequired().HasMaxLength(250);
            modelBuilder.Property(c => c.Attachment).HasMaxLength(500);
            modelBuilder.Property(c => c.FechaGeneroCorreo);
            modelBuilder.Property(c => c.FechaEnvio);
            modelBuilder.Property(c => c.Enviado).IsRequired();
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
