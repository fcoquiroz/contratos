using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_ModulosMenuporRolConfiguration
    /// </summary>
    public class Cat_ModulosMenuporRolConfiguration : EntityTypeConfiguration<Cat_ModulosMenuporRol>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_ModulosMenuporRol> modelBuilder)
        {
            modelBuilder.ToTable("Cat_ModulosMenuporRol");
            modelBuilder.HasKey(p => p.ID_Menu);
            modelBuilder.Property(c => c.ID_Rol).IsRequired();
            modelBuilder.Property(c => c.ID_Modulo).IsRequired();
            modelBuilder.Property(c => c.ID_Pantalla).IsRequired();
            modelBuilder.Property(c => c.Seleccionado).IsRequired();
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
