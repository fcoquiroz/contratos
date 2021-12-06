using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    public class TemplateDocsRequest
    {
        /// <summary>
        /// IdUsuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// IdDocumento
        /// </summary>
        public int IdDocumento { get; set; }

        /// <summary>
        /// IdContrato
        /// </summary>
        public long IdContrato { get; set; }
    }
}
