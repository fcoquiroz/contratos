using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_FolioConsecutivoConfiguration
    /// </summary>
    public class TB_FolioConsecutivoConfiguration : EntityTypeConfiguration<TB_FolioConsecutivo>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_FolioConsecutivo> modelBuilder)
        {
            modelBuilder.ToTable("TB_FolioConsecutivo");
            modelBuilder.HasKey(p => p.IdFolioConsecutivo);
            modelBuilder.Property(c => c.IdConsecutivo);
            modelBuilder.Property(c => c.Ano);
            modelBuilder.Property(c => c.ID_TipoSolicitud);
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
