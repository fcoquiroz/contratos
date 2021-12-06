using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Comercial
    /// </summary>
    public class Cat_Comercial
    {
        /// <summary>
        /// ID_Comercial
        /// </summary>
        public int ID_Comercial { get; set; }
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
        public DateTime CreateDate { get; set; }
    }
}
