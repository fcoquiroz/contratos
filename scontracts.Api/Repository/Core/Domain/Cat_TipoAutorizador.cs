using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_TipoAutorizador
    /// </summary>
    public class Cat_TipoAutorizador
    {
        /// <summary>
        /// Id_TipoAutorizador
        /// </summary>
        public int Id_TipoAutorizador { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
    }
}
