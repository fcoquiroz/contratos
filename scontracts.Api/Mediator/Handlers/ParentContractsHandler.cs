using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Persistence;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using scontracts.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    public class ParentContractsHandler : IRequestHandler<ParentContractsQuery, ResponseT<ParentContractsResponse>>
    {

        /// <summary>
        /// ParentContractsHandler
        /// </summary>
        public ParentContractsHandler()
        {

        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ParentContractsResponse>> Handle(ParentContractsQuery request, CancellationToken cancellationToken)
        {

            await Task.Delay(10);
            ResponseT<ParentContractsResponse> res = new ResponseT<ParentContractsResponse>();
            try
            {
                using (var unitofwork = new UnitOfWork(new DataContext()))
                {
                    #region Log
                    try
                    {
                        LogCreateRequest requestLog = new LogCreateRequest
                        {
                            UserName = request.IdUsuario.ToString(),
                            Path = "CreateParent.cshtml",
                            Control = "contracts",
                            Message = "Obtener solicitudes padre"
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
                        new ParentContractsResponse
                        {
                            SolicitudesPadre = unitofwork.TB_ContratosRoutines.ObtenerSolicitudesPadre
                            (request.IdEmpresa, request.IdContraparte, request.IdUnidadUsuario)
                        });
                }
            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ParentContractsResponse());
            }
            return res;
        }

    }
}
