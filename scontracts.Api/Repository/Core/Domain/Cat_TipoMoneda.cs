using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_TipoMoneda
    /// </summary>
    public class Cat_TipoMoneda
    {
        /// <summary>
        /// ID_Moneda
        /// </summary>
        public int ID_Moneda { get; set; }
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
