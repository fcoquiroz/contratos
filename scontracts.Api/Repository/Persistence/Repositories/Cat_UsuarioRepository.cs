using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Shared.DTO;
using System.Security.Cryptography; 
using scontracts.Shared.Responses;
using scontracts.Shared.Enums;
using scontracts.Shared.Utilities;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// Cat_UsuarioRepository
    /// </summary>
    public class Cat_UsuarioRepository : Repository<Cat_Usuario>, ICat_UsuarioRepository
    {
        /// <summary>
        /// Cat_UsuarioRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_UsuarioRepository(DataContext _context) : base(_context) { }


        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        /// <summary>
        /// Sirve para guardar el refresh token del usuario autenticado
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void SaveRefreshToken(RefreshTokenDTO entity)
        {

            //var command = UserConfiguration.
            //        RefreshTokenInsert_Parameters(_dataContext.Command(UserConfiguration.
            //        spRefreshTokenInsert), entity);

            //await command.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// GetUserByName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Cat_Usuario GetUserByName(string userName)
        {

            Cat_Usuario res = new Cat_Usuario();
            var ress = (from qry in consisContext.Cat_UsuarioRoutines

                        select new Cat_Usuario
                        {
                            ID_Usuario = qry.ID_Usuario
                            ,
                            Correo = qry.Correo,
                            Nombre = qry.Nombre

                        }
                   ).ToList().FirstOrDefault();
            res.ID_Usuario = ress.ID_Usuario;
            res.Nombre = ress.Nombre;
            res.Correo = ress.Correo;

            return res;
        }
        /// <summary>
        /// Auth
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAuthResponse Auth(string username, string password)
        {
            //var command = UserConfiguration.
            //      Auth_Parameters(_dataContext.Command(UserConfiguration.
            //      spUserAuth), username, password);


            //await using (var reader = await command.ExecuteReaderAsync())
            //    while (reader.Read())
            //        return UserConfiguration.Fill_Auth(reader);
            UserAuthResponse res = new UserAuthResponse();
            if (!string.IsNullOrEmpty(username.Trim()) && !string.IsNullOrEmpty(password.Trim()))
            {

                var pass = ContractUtils.Encode(password.Trim());

                res = (from u in consisContext.Cat_UsuarioRoutines
                       join r in consisContext.Cat_RolRoutines on u.ID_Rol equals r.ID_Rol
                       join i in consisContext.cat_IdiomaUsuarioRoutines on u.ID_Idioma equals i.ID_Idioma
                       from cuu in consisContext.Cat_Unidad_UsuarioRoutines
                       .Where(x => x.ID_UnidadUsuario == u.ID_UnidadUsuario).DefaultIfEmpty()
                       where u.Socio == username.Trim()
                       && ((u.Local) ? u.Contrasena == pass : 1 == 1)
                       && u.Activo == true
                       select new UserAuthResponse
                       {
                           UserId = u.ID_Usuario,
                           Username = u.Nombre,
                           Socio = u.Socio,
                           Password = pass,
                           IdRol = (u.ID_Rol == (int)Rol.Abogado_Altas) ? (int)Rol.Abogado : u.ID_Rol,
                           RoleDesc = r.Nombre,
                           EsLocal = u.Local,
                           Dias = r.Dias,
                           ID_UnidadUsuario = cuu.ID_UnidadUsuario,
                           ID_Idioma = i.ID_Idioma,
                           IdiomaNom = i.Nomenclatura
                       }).FirstOrDefault();


            }
            // { UserId = 1, Fullname = "Angel", RoleDesc = "Administrador" };
            return res;
        }

     
        /// <summary>
        /// Sirve para validar el refresh token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public RefreshTokenDTO ValidateRefreshToken(string token)
        {
            //var command = UserConfiguration.
            //     ValidateRefreshToken_Parameters(_dataContext.Command(UserConfiguration.
            //     spRefreshTokenValidate), token);


            //await using (var reader = await command.ExecuteReaderAsync())
            //    while (reader.Read())
            //        return UserConfiguration.Fill_ValidateRefreshToken(reader);


            return default;

        }


        /// <summary>
        /// GetUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDTO GetUser(int userId)
        {
            //var command = UserConfiguration.
            //       Get_Parameters(_dataContext.Command(UserConfiguration.
            //       spUserGet), userId);

            //await using (var reader = await command.ExecuteReaderAsync())
            //    if (reader.HasRows)
            //        return UserConfiguration.Fill_GetUser(reader);
            //return default;
            return default;
        }
        public bool Validate(string usuario, string pwd)
        {
            bool authenticated = false;


            foreach (var d in consisContext.Cat_LDAPRoutines.ToList())
            {
                try
                {
                    LdapAuthentication adAuth = new LdapAuthentication(d.LDAP);
                    if (adAuth.IsAuthenticated(d.Dominio, usuario, pwd))
                    {
                        authenticated = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    //Nothing
                }
            }


            return authenticated;
        }
        public List<UsuarioDTO> ObtenerUsuarios()
        {
            
            var tipA = consisContext.Cat_UsuarioRoutines.Where(x => x.Activo == true).OrderBy(x => x.Nombre).ToList();
            List<UsuarioDTO> listUsuario = new List<UsuarioDTO>();
            foreach (var item3 in tipA)
            {
                var objTipoA = new UsuarioDTO
                {
                   ID_Usuario = item3.ID_Usuario,
                   Nombre = item3.Nombre,
                   Correo = item3.Correo,
                   Activo = item3.Activo
                };
                listUsuario.Add(objTipoA);
            }

            return listUsuario;
        }

    }
}
