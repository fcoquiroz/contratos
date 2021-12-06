using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// TBContratosDocumentacionDTO
    /// </summary>
    public class TBContratosDocumentacionDTO
    {
        /// <summary>
        /// ID_Archivo
        /// </summary>
        public long ID_Archivo { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_Documentacion
        /// </summary>
        public int ID_Documentacion { get; set; }
        /// <summary>
        /// ID_Usuario
        /// </summary>
        public int ID_Usuario { get; set; }
        /// <summary>
        /// NombreArchivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// ContenttType
        /// </summary>
        public string ContenttType { get; set; }
        /// <summary>
        /// Base64
        /// </summary>
        public string Base64 { get; set; }
        public int? Agrupar { get; set; }

        public string RutaDocumentos { get; set; }
    }
}
