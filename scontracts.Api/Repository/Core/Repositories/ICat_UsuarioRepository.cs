using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ICat_UsuarioRepository
    /// </summary>
    public interface ICat_UsuarioRepository : IRepository<Cat_Usuario>
    {

        /// <summary>
        /// GetUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserDTO GetUser(int userId);


        /// <summary>
        /// Sirve para guardar el refresh token del usuario autenticado
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void SaveRefreshToken(RefreshTokenDTO entity);



        /// <summary>
        /// Sirve para validar el refresh token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        RefreshTokenDTO ValidateRefreshToken(string token);

        /// <summary>
        /// GetUserByName
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Cat_Usuario GetUserByName(string username);



        /// <summary>
        /// Se utiliza para validar las credenciales del usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Regresa la identidad del cliente</returns>
        UserAuthResponse Auth(string username, string password);
        /// <summary>
        /// Validate - Se utiliza para validar el usuario de LDAP
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        bool Validate(string usuario, string pwd);
        /// <summary>
        /// ObtenerUsuarios
        /// </summary>
        /// <returns></returns>
        List<UsuarioDTO> ObtenerUsuarios();

    }
}
