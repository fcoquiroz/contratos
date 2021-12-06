using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Documentacion
    /// </summary>
    public class TB_Contratos_Documentacion
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
        public int? ID_Usuario { get; set; }
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
        /// FechaCreacion
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
    }
}
