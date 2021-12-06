using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// AcceptCoverSetResponse
    /// </summary>
    public class AcceptCoverSetResponse
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// AutorizadoPorTodos
        /// </summary>
        public bool AutorizadoPorTodos { get; set; }
        /// <summary>
        /// NombreAutorizador
        /// </summary>
        public string NombreAutorizador { get; set; }
        /// <summary>
        /// TipoAutorizador
        /// </summary>
        public int TipoAutorizador { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string Mensaje { get; set; }
    }
}
