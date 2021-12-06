using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_TipoContrato
    /// </summary>
    public class Cat_TipoContrato
    {
        /// <summary>
        /// ID_TipoContrato
        /// </summary>
        public int ID_TipoContrato { get; set; }
        /// <summary>
        /// TipoContrato
        /// </summary>
        public string TipoContrato { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// </summary>
        public int ID_TipoSolicitud { get; set; }
    }
}
