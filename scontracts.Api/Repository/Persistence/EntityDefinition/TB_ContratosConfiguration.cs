using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Core.Domain;
namespace Repository.Persistence.EntityDefinition
{
    /// <summary>
    /// TB_ContratosConfiguration
    /// </summary>
    public class TB_ContratosConfiguration : EntityTypeConfiguration<TB_Contratos>
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public override void Map(EntityTypeBuilder<TB_Contratos> modelBuilder)
        {
            modelBuilder.ToTable("TB_Contratos");
            modelBuilder.HasKey(p => p.ID_Contrato);
            modelBuilder.Property(c => c.Folio).HasMaxLength(12);
            modelBuilder.Property(c => c.FechaSolicitud).IsRequired();
            modelBuilder.Property(c => c.ID_Solicitante).IsRequired();
            modelBuilder.Property(c => c.ID_UnidadUsuario);
            modelBuilder.Property(c => c.ID_Responsable).IsRequired();
            modelBuilder.Property(c => c.ID_Prioridad).IsRequired();
            modelBuilder.Property(c => c.ID_TipoDocumento).IsRequired();
            modelBuilder.Property(c => c.ID_Unidad).IsRequired();
            modelBuilder.Property(c => c.ID_Proveedor).IsRequired();
            modelBuilder.Property(c => c.ID_Moneda).IsRequired();
            modelBuilder.Property(c => c.ID_ResponsableJuridico);
            modelBuilder.Property(c => c.ID_TipoContrato);
            modelBuilder.Property(c => c.ID_Estatus).IsRequired();
            modelBuilder.Property(c => c.FechaAceptacion);
            modelBuilder.Property(c => c.ElaboracionContrato).IsRequired();
            modelBuilder.Property(c => c.FechaEnvioFirma);
            modelBuilder.Property(c => c.ID_UsuarioRechazo);
            modelBuilder.Property(c => c.MotivoRechazoCancelacion).HasMaxLength(2000);
            modelBuilder.Property(c => c.FechaRechazoCancelacion);
            modelBuilder.Property(c => c.Vuelta);
            modelBuilder.Property(c => c.DiasSegundaVuelta);
            modelBuilder.Property(c => c.EnParoAbogado);
            modelBuilder.Property(c => c.FechaVencimientoContrato);
            modelBuilder.Property(c => c.ContratoAdjunto);
            modelBuilder.Property(c => c.ID_TipoSolicitud);
            modelBuilder.Property(c => c.idIdioma);
            modelBuilder.Property(c => c.TieneDocumentacion);
            modelBuilder.Property(c => c.ValidoJuridico);
            modelBuilder.Property(c => c.EnParoSolicitante);
            modelBuilder.Property(c => c.IdTipoSolicitud);
            modelBuilder.Property(c => c.ReqCaratula);
            modelBuilder.Property(c => c.IDProducto);
            modelBuilder.Property(c => c.EsLiberado).HasDefaultValue(null);
            modelBuilder.Property(c => c.IDPais);
            modelBuilder.Property(c => c.IDAutorizador);
            modelBuilder.Property(c => c.ID_FormatoLiberado);
            modelBuilder.Property(c => c.ID_ContratoPadre);

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
