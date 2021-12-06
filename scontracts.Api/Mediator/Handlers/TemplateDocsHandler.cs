using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Persistence;
using RepositorySP.Persistence;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    public class TemplateDocsHandler : IRequestHandler<TemplateDocsQuery, ResponseT<TemplateDocsResponse>>
    {
        /// <summary>
        /// TemplateDocsHandler
        /// </summary>
        public TemplateDocsHandler()
        {

        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<TemplateDocsResponse>> Handle(TemplateDocsQuery request, CancellationToken cancellationToken)
        {

            await Task.Delay(10);
            ResponseT<TemplateDocsResponse> res = new ResponseT<TemplateDocsResponse>();
            List<CampoContratoLiberadoDTO> campo = new List<CampoContratoLiberadoDTO>();

            #region Log
            try
            {
                LogCreateRequest requestLog = new LogCreateRequest
                {
                    UserName = request.IdUsuario.ToString(),
                    Path = "CreateReleasedDoc.cshtml",
                    Control = "contracts",
                    Message = "Obtener campos de documento liberado"
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
                await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                {
                    campo = await unitofworkSP.ContractRepo.GetCamposDocumento(request.IdContrato, request.IdDocumento);

                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                        new TemplateDocsResponse
                        {
                            ListDetalleDoc = campo
                        });
                }

            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new TemplateDocsResponse());
            }
            return res;
        }

    }
}
