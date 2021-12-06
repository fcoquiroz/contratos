using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Persistence;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;

namespace scontracts.Api.Controllers
{
    /// <summary>
    /// AuthController 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// _settings
        /// </summary>
        private IOptions<Audience> _settings;

        /// <summary>
        /// _mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// _configuration
        /// </summary>
        private readonly IConfiguration _configuration;

      


        /// <summary>
        /// AuthController Constructor
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="mediator"></param>
        public AuthController(IOptions<Audience> settings, IMediator mediator, IConfiguration configuration)
        {
            this._settings = settings;
            this._mediator = mediator;
            this._configuration = configuration;
        
        }


        /// <summary>
        /// authenticate-app
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/auth/authenticate
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>response</returns> 
        /// <response code="200">ContractResponse</response>
        /// <response code="401">Si no tiene autorización</response>     
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Errresor interno del servidor</response>     
        /// 
        [Route("authenticate-app")]
        [HttpPost]
        public IActionResult Post([FromBody] UserAuthRequest request)
        {
            if (request.Username == "cto" && request.Password == "scto" && request.Secret== this._configuration.GetSection("ApiKey").Value)
            {

                var now = DateTime.UtcNow;

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
                };

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Secret));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = _settings.Value.Iss,
                    ValidateAudience = true,
                    ValidAudience = _settings.Value.Aud,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,

                };

                var jwt = new JwtSecurityToken(
                    issuer: _settings.Value.Iss,
                    audience: _settings.Value.Aud,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(1)),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var responseJson = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)TimeSpan.FromMinutes(1).TotalSeconds
                };

                return Ok(responseJson);
            }
            else
            {
                return Ok("");
            }
        }



        /// <summary>
        /// Autenticar usuario 
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
        /// <param name="request"></param>
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
            using (var db = new DataContext())
            {
                if (request.Username.Contains("@"))
                {
                    var usuario = db.Cat_UsuarioRoutines.Where(x => x.Correo.Trim().ToLower() == request.Username.Trim().ToLower()).FirstOrDefault();
                    request.Username = usuario.Socio;
                }
            }

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
        /// <param name="request"></param>
        /// <returns>Regresa token que autentica al usuario</returns> 
        /// <response code="200">Estatus ok: Regresa token que autentica al usuario</response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Authorize(AuthenticationSchemes = Constants.ctoScheme)]
        [Route("refresh-user-token")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserRefreshResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshUserToken([FromBody] UserRefreshTokenRequest request)
        {
            var query = new UserRefreshTokenQuery(request.RefreshToken, request.AccessToken, _settings.Value.Secret, _settings.Value.Iss, _settings.Value.Aud);
            var result = await _mediator.Send(query);
            return Ok(result);
        }




        /// <summary>
        /// Autenticar usuario del portal administrador
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/user-bytoken
        ///     {
        ///        "username":"string",
        ///        "password":"string"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Regresa token que autentica al usuario</returns> 
        /// <response code="200">Estatus ok: Regresa token que autentica al usuario</response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Authorize(AuthenticationSchemes = Constants.ctoScheme)]
        [Route("user-bytoken")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserRefreshResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByToken([FromBody] UserByTokenRequest request)
        {
            var query = new UserByTokenQuery(request.AccessToken, _settings.Value.Secret, _settings.Value.Iss, _settings.Value.Aud);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Autenticar usuario del portal administrador
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /user/user-byname
        ///     {
        ///        "username":"string",
        ///        "password":"string"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Regresa token que autentica al usuario</returns> 
        /// <response code="200">Estatus ok: Regresa token que autentica al usuario</response>
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        [Authorize(AuthenticationSchemes = Constants.ctoScheme)]
        [Route("user-byname")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<UserGetByNameResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByName([FromBody] UserByNameRequest request)
        {
            var query = new UserByNameQuery(request.username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("Log")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<LogCreateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Log([FromBody] LogCreateRequest request)
        {
            var query = new LogCreateCommand(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }

    /// <summary>
    /// Audience class
    /// </summary>
    public class Audience
    {
        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Iss
        /// </summary>
        public string Iss { get; set; }

        /// <summary>
        /// Aud
        /// </summary>
        public string Aud { get; set; }
    }
}
