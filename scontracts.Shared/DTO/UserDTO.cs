using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// UserDTO
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Fullname
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Socio
        /// </summary>
        public string Socio { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// IdRol
        /// </summary>
        public int IdRol { get; set; }
        
        /// <summary>
        /// RoleDesc
        /// </summary>
        public string RoleDesc { get; set; }
        /// <summary>
        /// EsLocal
        /// </summary>
        public bool EsLocal { get; set; }

        /// <summary>
        /// Dias
        /// </summary>
        public int Dias { get; set; }

        /// <summary>
        /// ID_UnidadUsuario
        /// </summary>
        public int ID_UnidadUsuario { get; set; }

        public List<EstatusDTO> ListaRoles { get; set; }

        /// <summary>
        /// ID_Idioma
        /// </summary>
        public int ID_Idioma { get; set; }
        /// <summary>
        /// IdiomaNom
        /// </summary>
        public string IdiomaNom { get; set; }
    }
}
