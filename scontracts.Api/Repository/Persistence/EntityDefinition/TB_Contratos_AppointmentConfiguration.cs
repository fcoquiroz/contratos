using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_Contratos_AppointmentConfiguration
    /// </summary>
    public class TB_Contratos_AppointmentConfiguration : EntityTypeConfiguration<TB_Contratos_Appointment>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos_Appointment> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos_Appointment");
            modelBuilder.HasKey(p => p.ID_Contrato_Appointment);
            modelBuilder.Property(c => c.ID_Appointment);
            modelBuilder.Property(c => c.ID_Contrato);
            modelBuilder.Property(c => c.Create_Date);
            modelBuilder.Property(c => c.Modify_Date);
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
