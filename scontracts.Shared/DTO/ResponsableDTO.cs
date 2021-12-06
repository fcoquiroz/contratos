using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// ResponsableDTO
    /// </summary>
    public class ResponsableDTO
    {
        /// <summary>
        /// ResponsableId
        /// </summary>
        public int ResponsableId { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Cargo
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// UnidadUsuarioId
        /// </summary>
        public int UnidadUsuarioId { get; set; }
        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// UsuarioRegistroId
        /// </summary>
        public int UsuarioRegistroId { get; set; }

    }
}
