using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Documentacion
    /// </summary>
    public class Cat_Documentacion
    {
        /// <summary>
        /// ID_Documentacion
        /// </summary>
        public int ID_Documentacion { get; set; }
        /// <summary>
        /// Documento
        /// </summary>
        public string Documento { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
