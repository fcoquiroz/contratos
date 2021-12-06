using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// ContractFindResponse
    /// </summary>
    public class ContractFindResponse
    {
        /// <summary>
        /// Solicitante
        /// </summary>
        public List<SolicitudesParaSolicitanteDTO> Solicitante { get; set; }
        /// <summary>
        /// Abogado
        /// </summary>
        public List<SolicitudesParaAbogadoDTO>  Abogado { get; set; }
        public string NombreEstatus { get; set; }
    }
}
