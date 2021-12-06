using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// AcceptCoverSetRequest
    /// </summary>
    public class AcceptCoverSetRequest
    {
        /// <summary>
        /// Id_Contrato
        /// </summary>
        public long ParametroCont { get; set; }
        /// <summary>
        /// ID_UsuarioEnvio
        /// </summary>
        public int ParametroUsr { get; set; }
        /// <summary>
        /// ID_UsuarioEnvio
        /// </summary>
        public int ParametroAut { get; set; }
        /// <summary>
        /// EsExtra Autorizador.
        /// </summary>
        public int ParametroExtra { get; set; }
        /// <summary>
        /// Vuelta validación.
        /// </summary>
        public int ParametroVuelta { get; set; }

        public string NombreAutorizador { get; set; }
        public int TipoAutorizador { get; set; }
        public bool ExisteAutorizadores_Aut { get; set; }

    }
}
