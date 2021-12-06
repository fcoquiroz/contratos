using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// CAT_AVISOSConfiguration
    /// </summary>
    public class CAT_AVISOSConfiguration : EntityTypeConfiguration<CAT_AVISOS>
    {
        /// <summary>
        /// TB_Contratos
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<CAT_AVISOS> modelBuilder)
        {
            modelBuilder.ToTable("CAT_AVISOS");
            modelBuilder.HasKey(p => p.Id_Aviso);
            modelBuilder.Property(c => c.Titulo).IsRequired().HasMaxLength(100);
            modelBuilder.Property(c => c.Descripcion).IsRequired().HasMaxLength(500);
            modelBuilder.Property(c => c.Activo).IsRequired();
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
