using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class SolicitudesPadreDTO
    {
        /// <summary>
        /// Id contrato
        /// </summary>
        public long IdContrato { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// FechaUltimoMov
        /// </summary>
        public DateTime FechaSolicitud { get; set; }
        /// <summary>
        /// Contraparte
        /// </summary>
        public string Contraparte { get; set; }
        /// <summary>
        /// Id_Contrato
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// Detalle solicitudes padre DTO
        /// </summary>
        public DetalleSolicitudPadreDTO DetalleSolicitudPadre { get; set; }
    }
}
