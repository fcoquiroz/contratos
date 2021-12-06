using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// ID_Prioridad
    /// </summary>
    public class Cat_Prioridad
    {
        /// <summary>
        /// ID_Prioridad
        /// </summary>
        public int ID_Prioridad { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Dias
        /// </summary>
        public int Dias { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
