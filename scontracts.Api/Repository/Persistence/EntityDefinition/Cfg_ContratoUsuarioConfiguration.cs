using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cfg_ContratoUsuarioConfiguration
    /// </summary>
    public class Cfg_ContratoUsuarioConfiguration : EntityTypeConfiguration<Cfg_ContratoUsuario>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cfg_ContratoUsuario> modelBuilder)
        {
            modelBuilder.ToTable("Cfg_ContratoUsuario");
            modelBuilder.HasKey(p => p.ID_ContratoUsuario);
            modelBuilder.Property(c => c.ID_Contrato).IsRequired();
            modelBuilder.Property(c => c.ID_Usuario).IsRequired();
            modelBuilder.Property(c => c.ID_UsuarioAlta);
            modelBuilder.Property(c => c.FechaAlta);
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
