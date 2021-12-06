using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_TipoDocumentoConfiguration
    /// </summary>
    public class Cat_TipoDocumentoConfiguration : EntityTypeConfiguration<Cat_TipoDocumento>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_TipoDocumento> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoDocumento");
            modelBuilder.HasKey(p => p.ID_TipoDocumento);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.Liberado);
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
