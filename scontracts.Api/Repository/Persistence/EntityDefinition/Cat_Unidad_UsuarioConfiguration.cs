using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_Unidad_UsuarioConfiguration
    /// </summary>
    public class Cat_Unidad_UsuarioConfiguration : EntityTypeConfiguration<Cat_Unidad_Usuario>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Unidad_Usuario> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Unidad_Usuario");
            modelBuilder.HasKey(p => p.ID_UnidadUsuario);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(100);
            modelBuilder.Property(c => c.Tipo).HasMaxLength(10);
            modelBuilder.Property(c => c.Create_Date);
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
