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
using scontracts.Shared.Requests;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Helpers;

namespace xpl.sow.organization.Mediator.Handlers
{
    /// <summary>
    /// SolicitudGetHandler
    /// </summary>
    public class SolicitudGetHandler : IRequestHandler<SolicitudGetQuery, ResponseT<SolicitudGetResponse>>
    {

        /// <summary>
        /// SolicitudGetHandler
        /// </summary>
        public SolicitudGetHandler()
        {

        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<SolicitudGetResponse>> Handle(SolicitudGetQuery request, CancellationToken cancellationToken)
        {

            ResponseT<SolicitudGetResponse> res = new ResponseT<SolicitudGetResponse>();

            SolicitudDTo dto = new SolicitudDTo();
            List<TBContratosDocumentacionDTO> documentos = new List<TBContratosDocumentacionDTO>();
            List<ProductosDTO> multiproductos = new List<ProductosDTO>();
            List<EmailSupervisorContratoDTO> emailSupervisor = new List<EmailSupervisorContratoDTO>();
            #region Log
            try
            {

                LogCreateRequest requestLog = new LogCreateRequest
                {
                    UserName = "",
                    Path = "Create.cshtml",
                    Control = "request",
                    Message = "Obtener Solicitud de Contrato"
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
                    dto = unitofwork.TB_ContratosRoutines.getsolicitud(request.IdContrato);
                    documentos = unitofwork.TB_ContratosRoutines.ObtenerContratoDocumentacion(request.IdContrato);
                    multiproductos = unitofwork.TB_MultiProductoRoutines.ObtenerMultiProductos(request.IdContrato);
                    emailSupervisor = unitofwork.TB_Email_Supervisor_ContratoRoutines.ObtenerEmailSupervisorContrato(request.IdContrato);
                }

                if (dto != null)
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), new SolicitudGetResponse
                    {
                        ID_Prioridad = dto.ID_Prioridad,
                        NombrePrioridad = dto.NombrePrioridad,
                        idIdioma = dto.idIdioma,
                        NombreIdioma = dto.NombreIdioma,
                        ElaboracionContrato = dto.ElaboracionContrato,
                        ID_TipoDocumento = dto.ID_TipoDocumento,
                        NombreDocumento = dto.NombreDocumento,
                        ID_Unidad = dto.ID_Unidad,
                        NombreUnidad = dto.NombreUnidad,
                        ID_Proveedor = dto.ID_Proveedor,
                        Contraparte = dto.Contraparte,
                        ID_Responsable = dto.ID_Responsable,
                        NombreResponsable = dto.NombreResponsable,
                        CargoResponsable = dto.CargoResponsable,
                        ID_UnidadUsuario = dto.ID_UnidadUsuario,
                        TelefonoResponsable = dto.TelefonoResponsable,
                        UnidadResponsable = dto.UnidadResponsable,
                        ObjetoNegociacion = dto.ObjetoNegociacion,
                        DescServiciosProductos = dto.DescServiciosProductos,
                        Contraprestacion = dto.Contraprestacion,
                        FormaPago = dto.FormaPago,
                        Vigencia = dto.Vigencia,
                        LugarFechaFirma = dto.LugarFechaFirma,
                        CondicionesEspeciales = dto.CondicionesEspeciales,
                        ListContratosDocumentos = documentos,
                        ListMultiProductos = multiproductos,
                        IDPais = dto.IDPais,
                        IdTipoSolicitud = dto.IdTipoSolicitud,
                        FolioPadre = dto.FolioPadre,
                        ListaEmailSupervisorContrato = emailSupervisor,
                        NombreSolicitante = dto.NombreSolicitante,
                        CargoSolicitante = dto.CargoSolicitante,
                        TelefonoSolicitante = dto.TelefonoSolicitante,
                        UnidadSolicitante = dto.UnidadSolicitante,
                        TipoContrato = dto.TipoContrato,
                        ID_Moneda = dto.ID_Moneda,
                        ID_ContratoPadre = dto.ID_ContratoPadre
                    });
                else { 
                    res.update(StatusCodes.Status404NotFound, ReasonPhrases.GetReasonPhrase(StatusCodes.Status404NotFound), new SolicitudGetResponse());
               }               

            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new SolicitudGetResponse());
            }
            return res;
        }
    }

}