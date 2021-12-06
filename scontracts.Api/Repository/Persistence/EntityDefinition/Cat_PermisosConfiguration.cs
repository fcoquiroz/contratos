using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_PermisosConfiguration
    /// </summary>
    public class Cat_PermisosConfiguration : EntityTypeConfiguration<Cat_Permisos>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Permisos> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Permisos");
            modelBuilder.HasKey(p => p.ID_Permiso);
            modelBuilder.Property(c => c.ID_Pantalla);
            modelBuilder.Property(c => c.ID_Modulo);
            modelBuilder.Property(c => c.ID_Rol);
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
