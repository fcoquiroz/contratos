using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// StatusGetResponse
    /// </summary>
    public class StatusGetResponse
    {
        /// <summary>
        /// listEstatus
        /// </summary>
        public List<EstatusDTO> listEstatus { get; set; }
    }
}
