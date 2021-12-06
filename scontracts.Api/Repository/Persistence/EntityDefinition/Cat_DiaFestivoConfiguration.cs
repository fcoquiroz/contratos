using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_DiaFestivoConfiguration
    /// </summary>
    public class Cat_DiaFestivoConfiguration : EntityTypeConfiguration<Cat_DiaFestivo>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_DiaFestivo> modelBuilder)
        {
            modelBuilder.ToTable("Cat_DiaFestivo");
            modelBuilder.HasKey(p => p.ID_DiaFestivo);
            modelBuilder.Property(c => c.Fecha);
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
