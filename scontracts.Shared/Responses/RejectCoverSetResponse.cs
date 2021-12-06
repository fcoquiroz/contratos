using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// RejectCoverSetResponse
    /// </summary>
    public class RejectCoverSetResponse
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }

        public string Mensaje { get; set; }
    }
}
