using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cfg_Correos
    /// </summary>
    public class Cfg_Correos
    {
        /// <summary>
        /// ID_Correo
        /// </summary>
        public int ID_Correo { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// ID_Estatus
        /// </summary>
        public int? ID_Estatus { get; set; }
    }
}
