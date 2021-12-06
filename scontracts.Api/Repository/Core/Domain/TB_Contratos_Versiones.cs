using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Versiones
    /// </summary>
    public class TB_Contratos_Versiones
    {
        /// <summary>
        /// ID_Contrato_Version
        /// </summary>
        public long ID_Contrato_Version { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_UsuarioEnvio
        /// </summary>
        public int ID_UsuarioEnvio { get; set; }
        /// <summary>
        /// ID_TipoAccion
        /// </summary>
        public int ID_TipoAccion { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public int? Version { get; set; }
        /// <summary>
        /// NombreContrato
        /// </summary>
        public string NombreContrato { get; set; }
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// ContenttType
        /// </summary>
        public string ContenttType { get; set; }
        /// <summary>
        /// Comentarios
        /// </summary>
        public string Comentarios { get; set; }
        /// <summary>
        /// FechaCreacion
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// EvidenciaCancelacion
        /// </summary>
        public string EvidenciaCancelacion { get; set; }
        /// <summary>
        /// Agrupar
        /// </summary>
        public int? Agrupar { get; set; }
    }
}
