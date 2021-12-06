using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Contratos_Finales
    /// </summary>
    public class TB_Contratos_Finales
    {
        /// <summary>
        /// ID_ContratoFinal
        /// </summary>
        public long ID_ContratoFinal { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_HistorialContrato
        /// </summary>
        public long ID_HistorialContrato { get; set; }
        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Historico
        /// </summary>
        public bool Historico { get; set; }
        /// <summary>
        /// FechaAdjunto
        /// </summary>
        public DateTime FechaAdjunto { get; set; }
    }
}
