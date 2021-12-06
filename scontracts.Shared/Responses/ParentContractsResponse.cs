using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    public class ParentContractsResponse
    {
        /// <summary>
        /// FolioPadre
        /// </summary>
        public string FolioPadre { get; set; }

        /// <summary>
        /// EstatusPadre
        /// </summary>
        public string EstatusPadre { get; set; }

        /// <summary>
        /// TipoDocPadre
        /// </summary>
        public string TipoDocPadre { get; set; }

        /// <summary>
        /// FechaSolicitudPadre
        /// </summary>
        public DateTime FechaSolicitudPadre { get; set; }

        /// <summary>
        /// ContrapartePadre
        /// </summary>
        public string ContrapartePadre { get; set; }

        /// <summary>
        /// Solicitudes Padre
        /// </summary>
        public List<SolicitudesPadreDTO> SolicitudesPadre { get; set; }
        /// <summary>
        /// NombreContratoPadre
        /// </summary>
        public string NombreContratoPadre { get; set; }
    }
}
