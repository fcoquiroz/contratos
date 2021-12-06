using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_ResponsablesConfiguration
    /// </summary>
    public class Cat_ResponsablesConfiguration : EntityTypeConfiguration<Cat_Responsables>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Responsables> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Responsables");
            modelBuilder.HasKey(p => p.ID_Responsable);
            modelBuilder.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            modelBuilder.Property(c => c.Cargo).IsRequired().HasMaxLength(150);
            modelBuilder.Property(c => c.Unidad).HasMaxLength(150);
            modelBuilder.Property(c => c.Telefono).IsRequired().HasMaxLength(50);
            modelBuilder.Property(c => c.Activo).IsRequired();
            modelBuilder.Property(c => c.ID_Usuario_Registro);
            modelBuilder.Property(c => c.ID_UnidadUsuario);
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
