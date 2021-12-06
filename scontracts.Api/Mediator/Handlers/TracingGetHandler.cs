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
    public class TracingGetHandler : IRequestHandler<TracingGetQuery, ResponseT<TracingGetResponse>>
    {
        public async Task<ResponseT<TracingGetResponse>> Handle(TracingGetQuery request, CancellationToken cancellationToken)
        {

            await Task.Delay(10);
            ResponseT<TracingGetResponse> res = new ResponseT<TracingGetResponse>();

            #region Log
            try
            {
                LogCreateRequest requestLog = new LogCreateRequest
                {
                    UserName = "",
                    Path = "Comments.cshtml",
                    Control = "Tracing",
                    Message = "Obtener Seguimiento de Solicitudes"
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
                SolicitudDTo dto = new SolicitudDTo();
                using (var unitofwork = new UnitOfWork(new DataContext()))
                {
                    dto = unitofwork.TB_ContratosRoutines.getsolicitud(request.Id_Contrato);
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                    new TracingGetResponse
                    {
                        ID_Prioridad = dto.ID_Prioridad,
                        Prioridad = dto.NombrePrioridad,
                        ObjetoNegociacion = dto.ObjetoNegociacion,
                        DescServiciosProductos = dto.DescServiciosProductos,
                        Contraprestacion = dto.Contraprestacion,
                        FormaPago = dto.FormaPago,
                        Vigencia = dto.Vigencia,
                        LugarFechaFirma = dto.LugarFechaFirma,
                        CondicionesEspeciales = dto.CondicionesEspeciales,
                        Moneda = dto.Moneda,
                        ID_FormatoLiberados=dto.ID_FormatoLiberados,
                        EnParoAbogado = dto.EnParoAbogado,
                        EnParoSolicitante = dto.EnParoSolicitante,
                        SeguimientoSolicitud = unitofwork.TB_Contratos_VersionesRoutines.ObtenerSeguimientoSolicitudes(request.Id_Contrato),
                        NombreArchivoMail = unitofwork.TB_Contratos_DocumentacionRoutines.ObtenerNombreArchivoMail(request.Id_Contrato)

                    });
                }

            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new TracingGetResponse());
            }
            return res;
        }
    }
}
