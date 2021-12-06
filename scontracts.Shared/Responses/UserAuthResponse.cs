using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// UserAuthResponse
    /// </summary>
    public class UserAuthResponse : UserDTO
    {

        /// <summary>
        /// UserAuthResponse
        /// </summary>
        public UserAuthResponse()
        { }

        /// <summary>
        /// UserAuthResponse
        /// </summary>
        /// <param name="user"></param>
        public UserAuthResponse(UserDTO user)
        {
            this.UserId = user.UserId;
            this.Username = user.Username;
            this.Socio = user.Socio;
            this.Fullname = user.Fullname;
            this.IdRol = user.IdRol;
            this.Password = user.Password;
            this.RoleDesc = user.RoleDesc;
            this.EsLocal = user.EsLocal;
            this.Dias = user.Dias;
            this.ID_UnidadUsuario = user.ID_UnidadUsuario;
            this.ID_Idioma = user.ID_Idioma;
            IdiomaNom = user.IdiomaNom;
            this.ListaRoles = user.ListaRoles;
            if (this.ListaRoles == null)
                this.ListaRoles = new List<EstatusDTO>();


        }

        /// <summary>
        /// AccessToken
        /// </summary>
        public object AccessToken { get; set; }

        /// <summary>
        /// RefreshToken
        /// </summary>
        public object RefreshToken { get; set; }

    }
}
