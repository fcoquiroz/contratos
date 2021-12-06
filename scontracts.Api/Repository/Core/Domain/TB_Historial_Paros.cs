using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Id_HistorialParos
    /// </summary>
    public class TB_Historial_Paros
    {
        /// <summary>
        /// Id_HistorialParos
        /// </summary>
        public long Id_HistorialParos { get; set; }
        /// <summary>
        /// IdContrato
        /// </summary>
        public long IdContrato { get; set; }
        /// <summary>
        /// FechaParo
        /// </summary>
        public DateTime? FechaParo { get; set; }
        /// <summary>
        /// FechaActivacion
        /// </summary>
        public DateTime? FechaActivacion { get; set; }
        /// <summary>
        /// Comentario
        /// </summary>
        public string Comentario { get; set; }
        /// <summary>
        /// UsuarioAplicoParo
        /// </summary>
        public string UsuarioAplicoParo { get; set; }
        /// <summary>
        /// UsuarioAplicoActivacion
        /// </summary>
        public string UsuarioAplicoActivacion { get; set; }
        /// <summary>
        /// UltimoEstatus
        /// </summary>
        public int UltimoEstatus { get; set; }
    }
}
