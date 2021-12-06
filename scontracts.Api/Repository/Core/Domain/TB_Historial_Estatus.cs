using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// TB_Historial_Estatus
    /// </summary>
    public class TB_Historial_Estatus
    {
        /// <summary>
        /// Id_HistorialEstatus
        /// </summary>
        public long Id_HistorialEstatus { get; set; }
        /// <summary>
        /// IdContrato
        /// </summary>
        public long IdContrato { get; set; }
        /// <summary>
        /// IdEstatus
        /// </summary>
        public int IdEstatus { get; set; }
        /// <summary>
        /// Comentario
        /// </summary>
        public string Comentario { get; set; }
        /// <summary>
        /// FechaAplicado
        /// </summary>
        public DateTime FechaAplicado { get; set; }
        /// <summary>
        /// UsuarioAplico
        /// </summary>
        public string UsuarioAplico { get; set; }
    }
}
