using MediatR;
using scontracts.Api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Context;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Requests;
using scontracts.Shared.Utilities;
using scontracts.Shared.Enums;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// UserAuthHandler
    /// </summary>
    public class UserAuthHandler : CtoTokens, IRequestHandler<UserAuthQuery, ResponseT<UserAuthResponse>>
    {
        /// <summary>
        /// _logger
        /// </summary>
        private readonly ILogger<UserAuthHandler> _logger;
        /// <summary>
        /// _mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// UserAuthHandler
        /// </summary>
        public UserAuthHandler(ILogger<UserAuthHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<UserAuthResponse>> Handle(UserAuthQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            ResponseT<UserAuthResponse> res = new ResponseT<UserAuthResponse>();
            
            try
            {
                using (var unitofwork = new UnitOfWork(new DataContext()))
                {
                    UserAuthResponse dto = null;

                    dto = unitofwork.Cat_UsuarioRoutines.Auth(request.Username, request.Password);

                    if (dto == null)
                    {
                        res.update(StatusCodes.Status404NotFound, ReasonPhrases.GetReasonPhrase(StatusCodes.Status404NotFound), new UserAuthResponse());
                        //unitofwork.Commit();
                    }
                    else
                    {
                        //Generar refresh token
                        RefreshTokenDTO refreshToken = GenerateRefreshToken();
                        refreshToken.UserId = dto.UserId;


                        unitofwork.RefreshTokenRoutines.Add(new RefreshToken
                        {
                            UserId = refreshToken.UserId,
                            Token = refreshToken.Token,
                            ExpiryDate = refreshToken.ExpiryDate
                        });
                        unitofwork.Commit();

                        dto.ListaRoles = new List<EstatusDTO>();
                        if (ContractUtils.ObtenerTipoRol(dto.IdRol) == Rol.Abogado)
                            dto.ListaRoles = unitofwork.TB_ContratosRoutines.ObtenerEstatusParaAbogado(dto.UserId).ToList();
                        if (ContractUtils.ObtenerTipoRol(dto.IdRol) == Rol.Solicitante)
                            dto.ListaRoles = unitofwork.TB_ContratosRoutines.ObtenerEstatusParaSolicitante(dto.UserId).ToList();


                        if (dto.EsLocal)
                        {                    
                            #region Log
                            LogCreateRequest requestLog = new LogCreateRequest { 
                            UserName = dto.Socio,
                            Path = "inicio_aspx",
                            Control = "inicio_aspx",
                            Message = "Inicio de Session"
                            };
                            var command = new LogCreateCommand(requestLog);
                            new ContractContext(new ContractLogginData()).SaveLog(command);
                            #endregion

                            dto.RefreshToken = refreshToken.Token;
                            dto.AccessToken = GenerateAccessToken(request.Secret, dto.UserId, request.Aud, request.Iss);
                                
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), dto);
                        }
                        else
                        {
                            if (unitofwork.Cat_UsuarioRoutines.Validate(request.Username, request.Password))
                            {
                                #region Log
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = dto.Socio,
                                    Path = "inicio_aspx",
                                    Control = "inicio_aspx",
                                    Message = "Inicio de Session"
                                };
                                var command = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(command);
                                #endregion

                                dto.RefreshToken = refreshToken.Token;
                                dto.AccessToken = GenerateAccessToken(request.Secret, dto.UserId, request.Aud, request.Iss);

                                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), dto);
                            }
                            else
                            {
                                // lblMensaje.Text = "Usuario o Contraseña incorrectos. Por favor, vuelva a intentarlo.";
                            }
                        }




                    }
                }
            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new UserAuthResponse());
            }
            return res;
        }
    }
}
