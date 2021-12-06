using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// TracingGetResponse
    /// </summary>
    public class TracingGetResponse
    {
        #region Contrato Detalle
        ///TB_Contratos_Detalle
        /// <summary>
        /// ObjetoNegociacion
        /// </summary>
        public string ObjetoNegociacion { get; set; }
        /// <summary>
        /// DescServiciosProductos
        /// </summary>
        public string DescServiciosProductos { get; set; }
        /// <summary>
        /// Contraprestacion
        /// </summary>
        public string Contraprestacion { get; set; }
        /// <summary>
        /// FormaPago
        /// </summary>
        public string FormaPago { get; set; }
        /// <summary>
        /// Vigencia
        /// </summary>
        public string Vigencia { get; set; }
        /// <summary>
        /// LugarFechaFirma
        /// </summary>
        public string LugarFechaFirma { get; set; }
        /// <summary>
        /// CondicionesEspeciales
        /// </summary>
        public string CondicionesEspeciales { get; set; }
        /// <summary>
        /// Moneda
        /// </summary>
        public string Moneda { get; set; }
        /// <summary>
        /// ID_Prioridad
        /// </summary>
        public int? ID_Prioridad { get; set; }
        /// <summary>
        /// Prioridad
        /// </summary>
        public string Prioridad { get; set; }
        /// <summary>
        /// ID_FormatoLiberados
        /// </summary>
        public int? ID_FormatoLiberados { get; set; }
        /// <summary>
        /// EnParoSolicitante
        /// </summary>
        public bool? EnParoSolicitante { get; set; }
        /// <summary>
        /// EnParoAbogado
        /// </summary>
        public bool? EnParoAbogado { get; set; }
        #endregion
        /// <summary>
        /// SeguimientoSolicitud
        /// </summary>
        public List<SeguimientoSolicitudDTO> SeguimientoSolicitud { get; set; }
        /// <summary>
        /// NombreArchivoMail
        /// </summary>
        public string NombreArchivoMail { get; set; }
    }
}
