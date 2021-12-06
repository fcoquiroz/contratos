using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cfg_PrioridadComplejidadSegundaConfiguration
    /// </summary>
    public class Cfg_PrioridadComplejidadSegundaConfiguration : EntityTypeConfiguration<Cfg_PrioridadComplejidadSegunda>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cfg_PrioridadComplejidadSegunda> modelBuilder)
        {
            modelBuilder.ToTable("Cfg_PrioridadComplejidadSegunda");
            modelBuilder.HasKey(p => p.ValorX);
            modelBuilder.Property(c => c.ValorY).IsRequired();
            modelBuilder.Property(c => c.ValorZ).IsRequired();
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
