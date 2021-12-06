using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Historial_TipoContrato
    /// </summary>
    public class TB_Historial_TipoContrato
    {
        /// <summary>
        /// IdHistorialTipoContrato
        /// </summary>
        public int IdHistorialTipoContrato { get; set; }
        /// <summary>
        /// IdContrato
        /// </summary>
        public long IdContrato { get; set; }
        /// <summary>
        /// IdTipoContratoAnterior
        /// </summary>
        public int IdTipoContratoAnterior { get; set; }
        /// <summary>
        /// IdTipoContratoNueva
        /// </summary>
        public int IdTipoContratoNueva { get; set; }
        /// <summary>
        /// UsuarioAplico
        /// </summary>
        public string UsuarioAplico { get; set; }
        /// <summary>
        /// FechaAplicacion
        /// </summary>
        public DateTime FechaAplicacion { get; set; }
    }
}
