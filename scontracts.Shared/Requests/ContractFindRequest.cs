using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// ContractFindRequest
    /// </summary>
    public class ContractFindRequest
    {
        /// <summary>
        /// Rol
        /// </summary>
        public int Rol { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// EstatusId
        /// </summary>
        public int EstatusId { get; set; }
    }
}
