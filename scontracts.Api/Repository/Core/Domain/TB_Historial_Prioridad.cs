using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Historial_Prioridad
    /// </summary>
    public class TB_Historial_Prioridad
    {
        /// <summary>
        /// IdHistorialPrioridad
        /// </summary>
        public int IdHistorialPrioridad { get; set; }
        /// <summary>
        /// IdContrato
        /// </summary>
        public long IdContrato { get; set; }
        /// <summary>
        /// IdPrioridadAnterior
        /// </summary>
        public int IdPrioridadAnterior { get; set; }
        /// <summary>
        /// IdPrioridadNueva
        /// </summary>
        public int IdPrioridadNueva { get; set; }
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
