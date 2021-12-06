using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_UsuarioConfiguration
    /// </summary>
    public class Cat_UsuarioConfiguration : EntityTypeConfiguration<Cat_Usuario>
    {
        /// <summary>
        /// Map 
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_Usuario> modelBuilder)
        {
            modelBuilder.ToTable("Cat_Usuario");
            modelBuilder.HasKey(p => p.ID_Usuario);
            modelBuilder.Property(c => c.Nombre).HasMaxLength(150);
            modelBuilder.Property(c => c.ID_UnidadUsuario);
            modelBuilder.Property(c => c.Puesto).HasMaxLength(100);
            modelBuilder.Property(c => c.ID_Rol);
            modelBuilder.Property(c => c.Correo).HasMaxLength(100);
            modelBuilder.Property(c => c.TelefonoExt).HasMaxLength(50);
            modelBuilder.Property(c => c.Socio).HasMaxLength(25);
            modelBuilder.Property(c => c.Contrasena).HasMaxLength(20);
            modelBuilder.Property(c => c.FechaRegistro);
            modelBuilder.Property(c => c.FechaCambioPwd);
            modelBuilder.Property(c => c.FechaUltimoIngreso);
            modelBuilder.Property(c => c.Activo);
            modelBuilder.Property(c => c.Local);
            modelBuilder.Property(c => c.FechaInactiva);
            modelBuilder.Property(c => c.EnvioEmail);
            modelBuilder.Property(c => c.FechaEnvioCorreo);
            modelBuilder.Property(c => c.ID_Idioma);
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
