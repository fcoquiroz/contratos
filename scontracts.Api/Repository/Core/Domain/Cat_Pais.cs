using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Pais
    /// </summary>
    public class Cat_Pais
    {
        /// <summary>
        /// ID_Pais
        /// </summary>
        public int ID_Pais { get; set; }
        /// <summary>
        /// Pais
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Create_Date
        /// </summary>
        public DateTime Create_Date { get; set; }
    }
}
