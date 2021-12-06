using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cfg_PrioridadComplejidad_HistoricoConfiguration
    /// </summary>
    public class Cfg_PrioridadComplejidad_HistoricoConfiguration : EntityTypeConfiguration<Cfg_PrioridadComplejidad_Historico>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cfg_PrioridadComplejidad_Historico> modelBuilder)
        {
            modelBuilder.ToTable("Cfg_PrioridadComplejidad_Historico");
            modelBuilder.HasKey(p => p.ID_Prioridad);
            modelBuilder.Property(c => c.ID_TipoContrato).IsRequired();
            modelBuilder.Property(c => c.Dias).IsRequired();
            modelBuilder.Property(c => c.Vuelta);
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
