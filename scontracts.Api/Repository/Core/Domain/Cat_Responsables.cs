using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Responsables
    /// </summary>
    public class Cat_Responsables
    {
        /// <summary>
        /// ID_Responsable
        /// </summary>
        public int ID_Responsable { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Cargo
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// Unidad
        /// </summary>
        public string Unidad { get; set; }
        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// ID_Usuario_Registro
        /// </summary>
        public int ID_Usuario_Registro { get; set; }
        /// <summary>
        /// ID_UnidadUsuario
        /// </summary>
        public int ID_UnidadUsuario { get; set; }
    }
}
