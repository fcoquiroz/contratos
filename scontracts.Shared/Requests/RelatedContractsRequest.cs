using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    public class RelatedContractsRequest
    {
        /// <summary>
        /// IdUsuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// SolicitanteId
        /// </summary>
        public long IdContratoPadre { get; set; }
    }
}
