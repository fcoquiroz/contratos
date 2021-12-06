using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_ModulosMenuporRol
    /// </summary>
    public class Cat_ModulosMenuporRol
    {
        /// <summary>
        /// ID_Menu
        /// </summary>
        public int ID_Menu { get; set; }
        /// <summary>
        /// ID_Rol
        /// </summary>
        public int ID_Rol { get; set; }
        /// <summary>
        /// ID_Modulo
        /// </summary>
        public int ID_Modulo { get; set; }
        /// <summary>
        /// ID_Pantalla
        /// </summary>
        public int ID_Pantalla { get; set; }
        /// <summary>
        /// Seleccionado
        /// </summary>
        public long Seleccionado { get; set; }
    }
}
