using MediatR;
using Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.Responses;
using scontracts.Shared.DTO;
using scontracts.Shared.Enums;
using scontracts.Shared.Utilities;
using scontracts.Shared.Requests;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;

namespace xpl.sow.organization.Mediator.Handlers
{
    /// <summary>
    /// ContractFindHandler
    /// </summary>
    public class ContractFindHandler : IRequestHandler<ContractFindQuery, ResponseT<ContractFindResponse>>
    {

        /// <summary>
        /// ContractFindHandler
        /// </summary>
        public ContractFindHandler()
        {

        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ContractFindResponse>> Handle(ContractFindQuery request, CancellationToken cancellationToken)
        {

            await Task.Delay(10);
            ResponseT<ContractFindResponse> res = new ResponseT<ContractFindResponse>();
            try
            {
                Rol rol = ContractUtils.ObtenerTipoRol(request.Rol);

                using (var unitofwork = new UnitOfWork(new DataContext()))
                {
                    if (rol == Rol.Gerente || rol == Rol.Administrador || rol == Rol.Adm_Abg)
                    {
                        #region Log
                        try
                        {
                            LogCreateRequest requestLog = new LogCreateRequest
                            {
                                UserName = request.UserId.ToString(),
                                Path = "DetailsA.cshtml",
                                Control = "contracts",
                                Message = "Obtener Solicitudes Para Abogado"
                            };
                            var commands = new LogCreateCommand(requestLog);
                            new ContractContext(new ContractLogginData()).SaveLog(commands);
                        }
                        catch (Exception ex)
                        {
                            ErrorLogFile.LogCritical(ex.Message);
                        }
                        #endregion
                        res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                            new ContractFindResponse
                            {
                                Abogado = unitofwork.TB_ContratosRoutines.ObtenerSolicitudesAdmin
                                (request.EstatusId, request.UserId)
                            });
                    }
                    else if (rol == Rol.Abogado)
                    {
                        #region Log
                        try
                        {
                            LogCreateRequest requestLog = new LogCreateRequest
                            {
                                UserName = request.UserId.ToString(),
                                Path = "DetailsA.cshtml",
                                Control = "contracts",
                                Message = "Obtener Solicitudes Para Abogado"
                            };
                            var commands = new LogCreateCommand(requestLog);
                            new ContractContext(new ContractLogginData()).SaveLog(commands);
                        }
                        catch (Exception ex)
                        {
                            ErrorLogFile.LogCritical(ex.Message);
                        }
                        #endregion
                        res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                            new ContractFindResponse
                            {
                                Abogado = unitofwork.TB_ContratosRoutines.ObtenerSolicitudesParaAbogado
                                (request.EstatusId, request.UserId)
                            });
                    }
                    else if (rol == Rol.Solicitante)
                    {
                        #region Log
                        try
                        {
                            LogCreateRequest requestLog = new LogCreateRequest
                            {
                                UserName = request.UserId.ToString(),
                                Path = "DetailsA.cshtml",
                                Control = "contracts",
                                Message = "Obtener Solicitudes Para Solicitante"
                            };
                            var commands = new LogCreateCommand(requestLog);
                            new ContractContext(new ContractLogginData()).SaveLog(commands);
                        }
                        catch (Exception ex)
                        {
                            ErrorLogFile.LogCritical(ex.Message);
                        }
                        #endregion
                        res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                           new ContractFindResponse
                           {
                               Solicitante = unitofwork.TB_ContratosRoutines.ObtenerSolicitudesParaSolicitante
                               (request.EstatusId, request.UserId)
                           });
                    }
                }
            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ContractFindResponse());
            }
            return res;
        }
    }

}