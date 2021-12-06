using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// StatusGetRequest
    /// </summary>
    public class StatusGetRequest
    {
        /// <summary>
        /// Rol
        /// </summary>
        public int Rol { get; set; }

        public int ID_Usuario { get; set; }
    }
}
