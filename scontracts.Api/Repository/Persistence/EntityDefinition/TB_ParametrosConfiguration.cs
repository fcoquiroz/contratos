using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_ParametrosConfiguration
    /// </summary>
    public class TB_ParametrosConfiguration : EntityTypeConfiguration<TB_Parametros>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Parametros> modelBuilder)
        {
            modelBuilder.ToTable("TB_Parametros");
            modelBuilder.HasKey(p => p.ID_Parametro);
            modelBuilder.Property(c => c.Parametro).HasMaxLength(50).IsRequired();
            modelBuilder.Property(c => c.Valor).HasMaxLength(500);
            modelBuilder.Property(c => c.TipoParametros).HasMaxLength(50);
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
