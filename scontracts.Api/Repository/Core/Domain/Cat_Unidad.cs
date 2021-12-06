using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Unidad
    /// </summary>
    public class Cat_Unidad
    {
        /// <summary>
        /// ID_Unidad
        /// </summary>
        public int ID_Unidad { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
