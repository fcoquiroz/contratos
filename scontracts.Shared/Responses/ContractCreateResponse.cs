using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// ID_Contrato
    /// </summary>
    public class ContractCreateResponse
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }

        public string PathRdlc { get; set; }
        public List<CargarSolicitudContratoDTO> DatosReporte { get; set; }
        public string Directory { get; set; }
        public string PathReporte { get; set; }
        public string Mensaje { get; set; }
    }
}
