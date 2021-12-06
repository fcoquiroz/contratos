using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_IdiomaUsuarioConfiguration
    /// </summary>
    public class Cat_IdiomaUsuarioConfiguration : EntityTypeConfiguration<Cat_IdiomaUsuario>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_IdiomaUsuario> modelBuilder)
        {
            modelBuilder.ToTable("cat_IdiomaUsuario");
            modelBuilder.HasKey(p => p.ID_Idioma);
            modelBuilder.Property(c => c.Descripcion).HasMaxLength(75);
            modelBuilder.Property(c => c.Nomenclatura).HasMaxLength(5);
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

