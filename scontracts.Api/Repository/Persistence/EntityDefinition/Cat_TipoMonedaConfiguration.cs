using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_TipoMonedaConfiguration
    /// </summary>
    public class Cat_TipoMonedaConfiguration : EntityTypeConfiguration<Cat_TipoMoneda>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_TipoMoneda> modelBuilder)
        {
            modelBuilder.ToTable("Cat_TipoMoneda");
            modelBuilder.HasKey(p => p.ID_Moneda);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(100);
            modelBuilder.Property(c => c.Activo);
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
