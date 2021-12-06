using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// DetalleParaAbogadoDTO
    /// </summary>
    public class DetalleParaAbogadoDTO
    {
        /// <summary>
        /// Empresa
        /// </summary>
        public String Empresa { get; set; }
        /// <summary>
        /// <summary>
        /// TipoContrato
        /// </summary>
        public String TipoContraparte { get; set; }
        /// <summary>
        /// Responsable
        /// </summary>
        public String Responsable { get; set; }
        /// <summary>
        /// Estatus
        /// </summary>
        public String Estatus { get; set; }
        /// <summary>
        /// Solicitante
        /// </summary>
        public String Solicitante { get; set; }
        /// <summary>
        /// FechaVencimiento
        /// </summary>
        public System.DateTime? FechaVencimiento { get; set; }
        /// <summary>
        /// TipoDocumento
        /// </summary>
        public String TipoDocumento { get; set; }
        /// <summary>
        /// FechaParo
        /// </summary>
        public System.DateTime? FechaParo { get; set; }
    }
}
