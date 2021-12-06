using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// UserGetByNameResponse
    /// </summary>
    public class UserGetByNameResponse : UserDTO
    {
        /// <summary>
        /// UserGetByNameResponse
        /// </summary>
        public UserGetByNameResponse()
        { }
        /// <summary>
        /// UserGetByNameResponse
        /// </summary>
        /// <param name="user"></param>
        public UserGetByNameResponse(UserDTO user)
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
        }

    }
}
