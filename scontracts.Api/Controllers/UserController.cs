using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace mer.monitor.organization.Controllers
{
    [Authorize]
    [Route("api/organization/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IOptions<Audience> _settings;


        private readonly IMediator _mediator;

        public UserController(IOptions<Audience> settings, IMediator mediator)
        {
            this._settings = settings;
            _mediator = mediator;
        }


        


        /// <summary>
        /// Insertar Usuarios a  tabla Users
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/users
        ///     {
        ///        "username":"string",
        ///        "fullname":"string",
        ///        "password":"string"
        ///     }
        ///
        /// </remarks>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <param name="fullname"></param>
        /// <param name="password"></param>
        /// <returns>ok</returns> 
        /// <response code="200">Estatus ok: </response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("users")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserCreateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        {
            var command = new UserCreateCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Obtiene el usuario 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET organization-api/user/users/{id}
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Un Usuario</returns>
        /// <response code="200">Regresa un Usuario</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>   
        /// <response code="409">Si no hay datos</response>     
        /// 
        [Route("users/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<UserGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            var query = new UserGetQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
          
        }


        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     PUT organization-api/user/users/{id}
        ///     {
        ///        "userid":"int",
        ///        "username":"string",
        ///        "fullname":"string",
        ///        "password":"string"
        ///     }
        /// </remarks>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <param name="fullname"></param>
        /// <param name="password"></param>
        /// <returns>Respuestas</returns>
        /// <response code="200">Regresa el ok</response>
        /// <response code="401">Si no tiene autorización</response>    
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        [Route("userupdate")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserUpdateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request)
        {
            var command = new UserUpdateCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }



        /// <summary>
        /// Obtiene Listado usuarios
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET organization-api/user/users
        ///     
        /// </remarks>
        /// <returns>Lista Usuarios</returns>
        /// <response code="200">Regresa lista de encuestas</response>
        /// <response code="401">Si no tiene autorización</response>  
        ///  <response code="409">no hay datos</response>      
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("users")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseList<UserFindResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindUsers()
        {
            var query = new UserFindQuery(0);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("usertypes")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseList<UserFindResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindUserTypes()
        {
            var query = new UserTypeFindQuery(0);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        /// <summary>
        /// Autenticar usuario del portal administrador
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/authenticate-user
        ///     {
        ///        "username":"string",
        ///        "password":"string"
        ///     }
        ///
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Regresa token que autentica al usuario</returns> 
        /// <response code="200">Estatus ok: Regresa token que autentica al usuario</response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("authenticate-user")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserRefreshResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UserAuth([FromBody] UserAuthRequest request)
        {
            var query = new UserAuthQuery(request, _settings.Value.Secret, _settings.Value.Iss, _settings.Value.Aud);
            var result = await _mediator.Send(query);
            return Ok(result);
        }




        /// <summary>
        /// Autenticar usuario del portal administrador
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/authenticate-user
        ///     {
        ///        "username":"string",
        ///        "password":"string"
        ///     }
        ///
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Regresa token que autentica al usuario</returns> 
        /// <response code="200">Estatus ok: Regresa token que autentica al usuario</response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("refresh-user-token")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserRefreshResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshUserToken([FromBody] RefreshUserTokenRequest request)
        {
            var query = new RefreshUserTokenQuery(request.RefreshToken, request.AccessToken, _settings.Value.Secret, _settings.Value.Iss, _settings.Value.Aud);
            var result = await _mediator.Send(query);
            return Ok(result);
        }




        /// <summary>
        /// Autenticar usuario del portal administrador
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/authenticate-user
        ///     {
        ///        "username":"string",
        ///        "password":"string"
        ///     }
        ///
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Regresa token que autentica al usuario</returns> 
        /// <response code="200">Estatus ok: Regresa token que autentica al usuario</response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("user-bytoken")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserRefreshResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByToken([FromBody] UserByTokenRequest request)
        {
            var query = new UserByTokenQuery(request.AccessToken, _settings.Value.Secret, _settings.Value.Iss, _settings.Value.Aud);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("user-byname")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserGetByNameResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByName([FromBody] UserByNameRequest request)
        {
            var query = new UserByNameQuery(request.username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }

    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }

}
