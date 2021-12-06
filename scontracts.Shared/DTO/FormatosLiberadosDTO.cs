using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class FormatosLiberadosDTO
    {
        /// <summary>
        /// IdDocumento
        /// </summary>
        public int IdDocumento { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// IdTipoSolicitud
        /// </summary>
        public int? IdTipoSolicitud { get; set; }

        /// <summary>
        /// IdTipoDocumento
        /// </summary>
        public int? IdTipoDocumento { get; set; }
    }
}
