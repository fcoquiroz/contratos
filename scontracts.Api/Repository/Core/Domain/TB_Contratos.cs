using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos
    /// </summary>
    public class TB_Contratos
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// FechaSolicitud
        /// </summary>
        public DateTime? FechaSolicitud { get; set; }
        /// <summary>
        /// ID_Solicitante
        /// </summary>
        public int ID_Solicitante { get; set; }
        /// <summary>
        /// ID_UnidadUsuario
        /// </summary>
        public int ID_UnidadUsuario { get; set; }
        /// <summary>
        /// ID_Responsable
        /// </summary>
        public int ID_Responsable { get; set; }
        /// <summary>
        /// ID_Prioridad
        /// </summary>
        public int ID_Prioridad { get; set; }
        /// <summary>
        /// ID_TipoDocumento
        /// </summary>
        public int ID_TipoDocumento { get; set; }
        /// <summary>
        /// ID_Unidad
        /// </summary>
        public int ID_Unidad { get; set; }
        /// <summary>
        /// ID_Proveedor
        /// </summary>
        public int ID_Proveedor { get; set; }
        /// <summary>
        /// ID_Moneda
        /// </summary>
        public int ID_Moneda { get; set; }
        /// <summary>
        /// ID_ResponsableJuridico
        /// </summary>
        public int? ID_ResponsableJuridico { get; set; }
        /// <summary>
        /// ID_TipoContrato
        /// </summary>
        public int? ID_TipoContrato { get; set; }
        /// <summary>
        /// ID_Estatus
        /// </summary>
        public int ID_Estatus { get; set; }
        /// <summary>
        /// FechaAceptacion
        /// </summary>
        public DateTime? FechaAceptacion { get; set; }
        /// <summary>
        /// ElaboracionContrato
        /// </summary>
        public bool ElaboracionContrato { get; set; }
        /// <summary>
        /// FechaEnvioFirma
        /// </summary>
        public DateTime? FechaEnvioFirma { get; set; }
        /// <summary>
        /// ID_UsuarioRechazo
        /// </summary>
        public int? ID_UsuarioRechazo { get; set; }
        /// <summary>
        /// MotivoRechazoCancelacion
        /// </summary>
        public string MotivoRechazoCancelacion { get; set; }
        /// <summary>
        /// FechaRechazoCancelacion
        /// </summary>
        public DateTime? FechaRechazoCancelacion { get; set; }
        /// <summary>
        /// Vuelta
        /// </summary>
        public int? Vuelta { get; set; }
        /// <summary>
        /// DiasSegundaVuelta
        /// </summary>
        public int? DiasSegundaVuelta { get; set; }
        /// <summary>
        /// EnParoAbogado
        /// </summary>
        public bool? EnParoAbogado { get; set; }
        /// <summary>
        /// FechaVencimientoContrato
        /// </summary>
        public DateTime? FechaVencimientoContrato { get; set; }
        /// <summary>
        /// ContratoAdjunto
        /// </summary>
        public bool? ContratoAdjunto { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// </summary>
        public int? ID_TipoSolicitud { get; set; }
        /// <summary>
        /// idIdioma
        /// </summary>
        public int? idIdioma { get; set; }
        /// <summary>
        /// TieneDocumentacion
        /// </summary>
        public bool? TieneDocumentacion { get; set; }
        /// <summary>
        /// ValidoJuridico
        /// </summary>
        public bool? ValidoJuridico { get; set; }
        /// <summary>
        /// EnParoSolicitante
        /// </summary>
        public bool? EnParoSolicitante { get; set; }
        /// <summary>
        /// IdTipoSolicitud
        /// </summary>
        public int? IdTipoSolicitud { get; set; }
        /// <summary>
        /// ReqCaratula
        /// </summary>
        public int? ReqCaratula { get; set; }
        /// <summary>
        /// IDProducto
        /// </summary>
        public int? IDProducto { get; set; }
        /// <summary>
        /// IDPais
        /// </summary>
        public int? IDPais { get; set; }
        /// <summary>
        /// IDAutorizador 
        /// </summary>
        public int? IDAutorizador { get; set; }
        /// <summary>
        /// EsLiberado
        /// </summary>
        public Nullable<bool> EsLiberado { get; set; }
        /// <summary>
        /// ID_FormatoLiberado
        /// </summary>
        public int? ID_FormatoLiberado { get; set; }
        /// <summary>
        /// ID_ContratoPadre
        /// </summary>
        public long? ID_ContratoPadre { get; set; }
    }
}
