using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Permisos
    /// </summary>
    public class Cat_Permisos
    {
        /// <summary>
        /// ID_Permiso
        /// </summary>
        public long ID_Permiso { get; set; }
        /// <summary>
        /// ID_Pantalla
        /// </summary>
        public int ID_Pantalla { get; set; }
        /// <summary>
        /// ID_Modulo
        /// </summary>
        public int ID_Modulo { get; set; }
        /// <summary>
        /// ID_Rol
        /// </summary>
        public int ID_Rol { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
