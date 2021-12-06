using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cfg_UsuarioUnidadConsultaConfiguration
    /// </summary>
    public class Cfg_UsuarioUnidadConsultaConfiguration : EntityTypeConfiguration<Cfg_UsuarioUnidadConsulta>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cfg_UsuarioUnidadConsulta> modelBuilder)
        {
            modelBuilder.ToTable("Cfg_UsuarioUnidadConsulta");
            modelBuilder.HasKey(p => p.ID_UnidadConsulta);
            modelBuilder.Property(c => c.ID_Usuario).IsRequired();
            modelBuilder.Property(c => c.ID_UnidadUsuario).IsRequired();
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
