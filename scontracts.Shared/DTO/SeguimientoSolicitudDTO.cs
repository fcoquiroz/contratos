using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// SeguimientoSolicitudDTO
    /// </summary>
    public class SeguimientoSolicitudDTO
    {
        /// <summary>
        /// ID_Contrato_Version
        /// </summary>
        public long ID_Contrato_Version { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_UsuarioEnvio
        /// </summary>
        public int ID_UsuarioEnvio { get; set; }
        /// <summary>
        /// ID_TipoAccion
        /// </summary>
        public int ID_TipoAccion { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public int? Version { get; set; }
        /// <summary>
        /// NombreContrato
        /// </summary>
        public string NombreContrato { get; set; }
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// ContenttType
        /// </summary>
        public string ContenttType { get; set; }
        /// <summary>
        /// Comentarios
        /// </summary>
        public string Comentarios { get; set; }
        /// <summary>
        /// FechaCreacion
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// TipoAccion
        /// </summary>
        public string TipoAccion { get; set; }
        /// <summary>
        /// NombreUsuario
        /// </summary>
        public string NombreUsuario { get; set; }
        /// <summary>
        /// DescEstatus
        /// </summary>
        public string DescEstatus { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// Id_Estatus
        /// </summary>
        public int Id_Estatus { get; set; }
        /// <summary>
        /// DiasSegundaVuelta
        /// </summary>
        public int? DiasSegundaVuelta { get; set; }
        /// <summary>
        /// ValorX
        /// </summary>
        public int? ValorX { get; set; }
        /// <summary>
        /// ValorY
        /// </summary>
        public int? ValorY { get; set; }
        /// <summary>
        /// ValorZ
        /// </summary>
        public int? ValorZ { get; set; }

        /// <summary>
        /// EsLiberado
        /// </summary>
        public bool? EsLiberado { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? NumAgrupados { get; set; }

        /// <summary>
        /// ReqCaratula
        /// </summary>
        public bool? ReqCaratula { get; set; }

        /// <summary>
        /// IdTipoSolicitud
        /// </summary>
        public int? IdTipoSolicitud { get; set; }
       
    }
       
}
