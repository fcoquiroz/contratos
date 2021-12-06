using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.EntityDefinition
{
    public class TB_Autorizadores_AutConfiguration : EntityTypeConfiguration<TB_Autorizadores_Aut>
    {
        public override void Map(EntityTypeBuilder<TB_Autorizadores_Aut> modelBuilder)
        {
            modelBuilder.ToTable("TB_Autorizadores_Aut");
            modelBuilder.HasKey(p => p.Id_Autorizadores_Aut);
            modelBuilder.Property(c => c.Id_Contrato).IsRequired();
            modelBuilder.Property(c => c.Id_Autorizador).IsRequired();
            modelBuilder.Property(c => c.Autorizo);
            modelBuilder.Property(c => c.Comentario);
            modelBuilder.Property(c => c.Fecha);
            modelBuilder.Property(c => c.EsExtra);
            modelBuilder.Property(c => c.Vuelta);
        }
    }
}
