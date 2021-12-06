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
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Helpers;

namespace xpl.sow.organization.Mediator.Handlers
{
    /// <summary>
    /// StatusGetHandler
    /// </summary>
    public class StatusGetHandler : IRequestHandler<StatusGetQuery, ResponseT<StatusGetResponse>>
    {

        /// <summary>
        /// StatusGetHandler
        /// </summary>
        public StatusGetHandler()
        {

        }

      
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<StatusGetResponse>> Handle(StatusGetQuery request, CancellationToken cancellationToken)
        {

            //ResponseList<StatusGetResponse> res = new ResponseList<StatusGetResponse>();
            //List<StatusGetResponse> list = new List<StatusGetResponse>();
            //List<EstatusDTO> dto = new List<EstatusDTO>();
             ResponseT<StatusGetResponse> res = new ResponseT<StatusGetResponse>();
            StatusGetResponse dto = new StatusGetResponse();
            try
            {

                Rol rol = ContractUtils.ObtenerTipoRol(request.Rol);

                using (var unitofwork = new UnitOfWork(new DataContext()))

                    if ( rol == Rol.Administrador || rol == Rol.Gerente || rol == Rol.Adm_Abg)
                    {
                        #region Log
                        try
                        {
                            LogCreateRequest requestLog = new LogCreateRequest
                            {
                                UserName = "",
                                Path = "IndexA.cshtml",
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

                        //list = new List<StatusGetResponse>();
                        dto.listEstatus = unitofwork.TB_ContratosRoutines.ObtenerEstatusAdmin(request.ID_Usuario).ToList();
                    }
                else if(rol == Rol.Abogado)
                    {
                        #region Log
                        try
                        {
                            LogCreateRequest requestLog = new LogCreateRequest
                            {
                                UserName = "",
                                Path = "IndexA.cshtml",
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

                        //list = new List<StatusGetResponse>();
                       dto.listEstatus = unitofwork.TB_ContratosRoutines.ObtenerEstatusParaAbogado(request.ID_Usuario).ToList();
                    }else if(ContractUtils.ObtenerTipoRol(request.Rol)==Rol.Solicitante) {

                        #region Log
                        try
                        {
                            LogCreateRequest requestLog = new LogCreateRequest
                            {
                                UserName = "",
                                Path = "IndexS.cshtml",
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

                        //list = new List<StatusGetResponse>();
                        dto.listEstatus = unitofwork.TB_ContratosRoutines.ObtenerEstatusParaSolicitante(request.ID_Usuario).ToList();
                    }


                await Task.Delay(10);
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), dto);

            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new StatusGetResponse());
            }
            return res;
        }
    }

}