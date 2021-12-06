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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    public class ReleasedDocsHandler : IRequestHandler<ReleasedDocsQuery, ResponseT<ReleasedDocsResponse>>
    {
        /// <summary>
        /// ReleasedDocsHandler
        /// </summary>
        public ReleasedDocsHandler()
        {

        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ReleasedDocsResponse>> Handle(ReleasedDocsQuery request, CancellationToken cancellationToken)
        {

            await Task.Delay(10);
            ResponseT<ReleasedDocsResponse> res = new ResponseT<ReleasedDocsResponse>();
            ReleasedDocsResponse dto = new ReleasedDocsResponse();

            #region Log
            try
            {
                LogCreateRequest requestLog = new LogCreateRequest
                {
                    UserName = request.IdUsuario.ToString(),
                    Path = "ReleasedDocument.cshtml",
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

            try
            {
                using (var unitofwork = new UnitOfWork(new DataContext()))
                {
                    dto.listFormatosLiberados = unitofwork.Cat_FormatoLiberadosRoutines.ObtenerContratosLiberados(request.IdUnidadUsuario);

                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                        new ReleasedDocsResponse
                        {
                            listFormatosLiberados = dto.listFormatosLiberados
                        });
                }
            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ReleasedDocsResponse());
            }
            return res;
        }

    }
}
