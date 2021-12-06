using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Pantallas
    /// </summary>
    public class Cat_Pantallas
    {
        /// <summary>
        /// ID_Pantalla
        /// </summary>
        public int ID_Pantalla { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// ID_Modulo
        /// </summary>
        public int ID_Modulo { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public int Orden { get; set; }
    }
}
