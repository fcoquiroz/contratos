using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    public class TipoAutorizadorDTO
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
