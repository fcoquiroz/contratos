using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// SolicitudesParaSolicitanteDTO
    /// </summary>
    public class SolicitudesParaSolicitanteDTO
    {
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// FechaUltimoMov
        /// </summary>
        public DateTime? FechaUltimoMov { get; set; }
        /// <summary>
        /// Contraparte
        /// </summary>
        public String Contraparte { get; set; }
        /// <summary>
        /// Id_Contrato
        /// </summary>
        public long Id_Contrato { get; set; }

        /// <summary>
        /// Id_ContratoPadre
        /// </summary>
        public long? Id_ContratoPadre { get; set; }

        /// <summary>
        /// Id_FormatoLiberado
        /// </summary>
        public int? Id_FormatoLiberado { get; set; }

        /// <summary>
        /// DetalleParaSolicitanteDTO
        /// </summary>
        public DetalleParaSolicitanteDTO DetalleS { get; set; }
        
    }
}
