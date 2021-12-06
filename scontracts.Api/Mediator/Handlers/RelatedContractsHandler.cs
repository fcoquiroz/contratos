using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Persistence;
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
    public class RelatedContractsHandler : IRequestHandler<RelatedContractsQuery, ResponseT<ParentContractsResponse>>
    {
        /// <summary>
        /// RelatedContractsHandler
        /// </summary>
        public RelatedContractsHandler()
        {

        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ParentContractsResponse>> Handle(RelatedContractsQuery request, CancellationToken cancellationToken)
        {

            await Task.Delay(10);
            ResponseT<ParentContractsResponse> res = new ResponseT<ParentContractsResponse>();
            SolicitudDTo dto = new SolicitudDTo();
            List<SolicitudesPadreDTO> contratos = new List<SolicitudesPadreDTO>();
            string nombreContrato = "";
            #region Log
            try
            {
                LogCreateRequest requestLog = new LogCreateRequest
                {
                    UserName = request.IdUsuario.ToString(),
                    Path = "Relation.cshtml",
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
                    dto = unitofwork.TB_ContratosRoutines.ObtenerContratoPadre(request.IdContratoPadre);
                    contratos = unitofwork.TB_ContratosRoutines.ObtenerContratosRelacionados(request.IdContratoPadre);
                    nombreContrato = unitofwork.TB_Contratos_VersionesRoutines.ObtenerNombreContratoPrincipalRelacionado(request.IdContratoPadre);
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                        new ParentContractsResponse
                        {
                            FolioPadre = dto.FolioPadre,
                            EstatusPadre = dto.Estatus,
                            TipoDocPadre = dto.NombreDocumento,
                            FechaSolicitudPadre = dto.FechaSolicitud,
                            ContrapartePadre = dto.Contraparte,
                            SolicitudesPadre = contratos,
                            NombreContratoPadre = nombreContrato
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
