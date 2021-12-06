using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// UserRefreshResponse
    /// </summary>
    public class UserRefreshResponse : UserDTO
    {
        /// <summary>
        /// UserRefreshResponse
        /// </summary>
        public UserRefreshResponse()
        { }
        /// <summary>
        /// UserRefreshResponse
        /// </summary>
        /// <param name="user"></param>
        public UserRefreshResponse(UserDTO user)
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
            this.ListaRoles = user.ListaRoles;

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
