using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_Usuario
    /// </summary>
    public class Cat_Usuario
    {
        /// <summary>
        /// ID_Usuario
        /// </summary>
        public int ID_Usuario { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// ID_UnidadUsuario
        /// </summary>
        public int? ID_UnidadUsuario { get; set; }
        /// <summary>
        /// Puesto
        /// </summary>
        public string Puesto { get; set; }
        /// <summary>
        /// ID_Rol
        /// </summary>
        public int ID_Rol { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// TelefonoExt
        /// </summary>
        public string TelefonoExt { get; set; }
        /// <summary>
        /// Socio
        /// </summary>
        public string Socio { get; set; }
        /// <summary>
        /// Contrasena
        /// </summary>
        public string Contrasena { get; set; }
        /// <summary>
        /// FechaRegistro
        /// </summary>
        public DateTime? FechaRegistro { get; set; }
        /// <summary>
        /// FechaCambioPwd
        /// </summary>
        public DateTime? FechaCambioPwd { get; set; }
        /// <summary>
        /// FechaUltimoIngreso
        /// </summary>
        public DateTime? FechaUltimoIngreso { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool? Activo { get; set; }
        /// <summary>
        /// Local
        /// </summary>
        public bool Local { get; set; }
        /// <summary>
        /// FechaInactiva
        /// </summary>
        public DateTime? FechaInactiva { get; set; }
        /// <summary>
        /// EnvioEmail
        /// </summary>
        public bool? EnvioEmail { get; set; }
        /// <summary>
        /// FechaEnvioCorreo
        /// </summary>
        public DateTime? FechaEnvioCorreo { get; set; }
        /// <summary>
        /// ID_Rol
        /// </summary>
        public int ID_Idioma { get; set; }
    }
}
