using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    public class TB_Relacion_ProductoPaisResponsables
    {
        /// <summary>
        /// Id_Relacion
        /// </summary>
        public int Id_Relacion { get; set; }
        /// <summary>
        /// Id_Producto
        /// </summary>
        public int? Id_Producto { get; set; }
        /// <summary>
        /// ID_Pais
        /// </summary>
        public int? ID_Pais { get; set; }
        /// <summary>
        /// ID_Responsable
        /// </summary>
        public int? ID_Responsable { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool? Activo { get; set; }
    }
}
