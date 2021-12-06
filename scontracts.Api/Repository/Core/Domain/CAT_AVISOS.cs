using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    ///CAT_AVISOS
    /// </summary>
    public class CAT_AVISOS
    {
        /// <summary>
        /// Id_Aviso
        /// </summary>
        public int Id_Aviso { get; set; }
        /// <summary>
        /// Titulo
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
