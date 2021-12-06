using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cfg_ContratoUsuario
    /// </summary>
    public class Cfg_ContratoUsuario
    {
        /// <summary>
        /// ID_ContratoUsuario
        /// </summary>
        public long ID_ContratoUsuario { get; set; }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_Usuario
        /// </summary>
        public int ID_Usuario { get; set; }
        /// <summary>
        /// ID_UsuarioAlta
        /// </summary>
        public int ID_UsuarioAlta { get; set; }
        /// <summary>
        /// FechaAlta
        /// </summary>
        public DateTime FechaAlta { get; set; }
    }
}
