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
    /// RefreshTokenConfiguration
    /// </summary>
    public class RefreshTokenConfiguration : EntityTypeConfiguration<RefreshToken>
    {
        /// <summary>
        /// Map RefreshToken
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<RefreshToken> modelBuilder)
        {
            modelBuilder.ToTable("Cfg_RefreshToken");
            modelBuilder.HasKey(p => p.TokenId);
            modelBuilder.Property(c => c.UserId).IsRequired();
            modelBuilder.Property(c => c.Token).IsRequired().HasMaxLength(400);
            modelBuilder.Property(c => c.ExpiryDate).IsRequired();
           
        }
    }
}
