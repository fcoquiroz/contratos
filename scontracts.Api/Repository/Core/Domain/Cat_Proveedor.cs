using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Proveedor
    /// </summary>
    public class Cat_Proveedor
    {
        /// <summary>
        /// ID_Proveedor
        /// </summary>
        public int ID_Proveedor { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }
}
