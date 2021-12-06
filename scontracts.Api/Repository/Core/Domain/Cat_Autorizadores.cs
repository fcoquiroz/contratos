using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Autorizadores
    /// </summary>
    public class Cat_Autorizadores
    {
        /// <summary>
        /// Id_Autorizador
        /// </summary>
        public int Id_Autorizador { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool? Activo { get; set; }
        /// <summary>
        /// TipoAutorizador
        /// </summary>
        public int TipoAutorizador { get; set; }
        /// <summary>
        /// TipoCaratula
        /// </summary>
        public int? TipoCaratula { get; set; }
        /// <summary>
        /// ID_Usuario
        /// </summary>
        public int? ID_usuario { get; set; }

    }
}
