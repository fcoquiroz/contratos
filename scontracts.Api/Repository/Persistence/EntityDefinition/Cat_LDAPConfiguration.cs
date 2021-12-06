using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// Cat_LDAPConfiguration
    /// </summary>
    public class Cat_LDAPConfiguration : EntityTypeConfiguration<Cat_LDAP>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<Cat_LDAP> modelBuilder)
        {
            modelBuilder.ToTable("Cat_LDAP");
            modelBuilder.HasKey(p => p.IdLDAP);
            modelBuilder.Property(c => c.Empresa).IsRequired().HasMaxLength(500);
            modelBuilder.Property(c => c.Dominio).IsRequired().HasMaxLength(500);
            modelBuilder.Property(c => c.LDAP).HasMaxLength(500);
            modelBuilder.Property(c => c.FechaAlta);
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
