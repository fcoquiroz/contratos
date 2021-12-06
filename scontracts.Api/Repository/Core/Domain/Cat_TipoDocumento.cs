using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_TipoDocumento
    /// </summary>
    public class Cat_TipoDocumento
    {
        /// <summary>
        /// ID_TipoDocumento
        /// </summary>
        public int ID_TipoDocumento { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Liberado
        /// </summary>
        public bool Liberado { get; set; }
    }
}
