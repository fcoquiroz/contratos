using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// ID_Contrato_Historial
    /// </summary>
    public class TB_Contratos_Historial
    {
        /// <summary>
        /// ID_Contrato_Historial
        /// </summary>
        public long ID_Contrato_Historial { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_UsuarioCambio
        /// </summary>
        public int ID_UsuarioCambio { get; set; }
        /// <summary>
        /// FechaCambio
        /// </summary>
        public DateTime FechaCambio { get; set; }
        /// <summary>
        /// SolicitanteAnterior
        /// </summary>
        public string SolicitanteAnterior { get; set; }
        /// <summary>
        /// SolicitanteNuevo
        /// </summary>
        public string SolicitanteNuevo { get; set; }
        /// <summary>
        /// JuridicoAnterior
        /// </summary>
        public string JuridicoAnterior { get; set; }
        /// <summary>
        /// JuridicoNuevo
        /// </summary>
        public string JuridicoNuevo { get; set; }
    }
}
