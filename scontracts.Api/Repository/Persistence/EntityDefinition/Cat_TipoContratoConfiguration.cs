using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_TipoContratoConfiguration
    /// </summary>
    public class Cat_TipoContratoConfiguration : EntityTypeConfiguration<Cat_TipoContrato>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_TipoContrato> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoContrato");
            modelBuilder.HasKey(p => p.ID_TipoContrato);
            modelBuilder.Property(c => c.TipoContrato).IsRequired().HasMaxLength(100);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.ID_TipoSolicitud);
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
