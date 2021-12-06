using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    public class FileDeleteResponse
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// Nombre_Archivo
        /// </summary>
        public string Nombre_Archivo { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string Mensaje { get; set; }
    }
}
