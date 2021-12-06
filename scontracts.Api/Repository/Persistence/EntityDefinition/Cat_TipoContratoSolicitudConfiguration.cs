using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_TipoContratoSolicitudConfiguration
    /// </summary>
    public class Cat_TipoContratoSolicitudConfiguration : EntityTypeConfiguration<Cat_TipoContratoSolicitud>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_TipoContratoSolicitud> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoContratoSolicitud");
            modelBuilder.HasKey(p => p.ID_TipoSolicitud);
            modelBuilder.Property(c => c.TipoSolicitud).IsRequired().HasMaxLength(100);
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
