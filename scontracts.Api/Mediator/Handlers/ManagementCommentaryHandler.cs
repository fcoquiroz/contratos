using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Persistence;
using RepositorySP.Persistence;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Enums;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// AutorizarSolicitante
    /// </summary>
    public class ManagementCommentaryHandler : Constants, IRequestHandler<ManagementCommentaryCommand, ResponseT<ManagementCommentaryResponse>>
    {
        public async Task<ResponseT<ManagementCommentaryResponse>> Handle(ManagementCommentaryCommand command, CancellationToken cancellationToken)
        {
          
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                #region Log
                try
                {
                    LogCreateRequest requestLog = new LogCreateRequest
                    {
                        UserName = command.ID_UsuarioEnvio.ToString(),
                        Path = "Comments.cshtml",
                        Control = "Contract/managementCommentary",
                        Message = "Movimiento de estatus"
                    };
                    var commands = new LogCreateCommand(requestLog);
                    new ContractContext(new ContractLogginData()).SaveLog(commands);
                }
                catch (Exception ex)
                {
                    ErrorLogFile.LogCritical(ex.Message);
                }
                #endregion
                #region Solicitante
                if (command.AutorizaSolicitante)
                {
                    res = AutorizarSolicitante(command);
                }
                else if (command.EnviaSolicitante)
                {
                    if (!command.StandBy)
                    {
                        if (command.ListAnexosDoc.Count == 0 && command.ListContratosDoc.Count == 0)
                        {
                             res = EnviarComentarios(command);
                        }
                        else
                        {
                            if (command.ListAnexosDoc.Count > 0 && command.ListContratosDoc.Count > 0)
                            {
                                EnviarAnexosContrato(command);
                                res = EnviarInformacion(command);
                            }
                            else
                            {
                                if (command.ListContratosDoc.Count > 0)
                                    res = EnviarInformacion(command);
                                else
                                    res = EnviarAnexosContrato(command);
                            }
                        }
                    }
                    else
                    {
                        res = StandBy(command);
                    }
                   
                }
                #endregion

                #region Abogado
                if (command.AutorizaAbogado)
                {
                    if(!command.AutorizaLiberado)
                    res = await AutorizarAbogado(command);
                    else
                        res = await AutorizarLiberado(command);
                }
                else if (command.EnviaAbogado)
                {
                    res = await EnviarAbogado(command);
                }
                #endregion
                #region Cambio Estatus
                switch (command.ID_Estatus_Cambio)
                {
                    case ((int)EstatusSolicitud.StandBy)://1200
                        {
                            res = StandBy(command);
                        }
                        break;
                    case ((int)EstatusSolicitud.EsperaDocumentacionInformacion)://1100
                        {
                            res = SaveEsperaDocumentacionInformacion(command);
                        }
                        break;
                   
                    case ((int)EstatusSolicitud.EnEsperaDeReplica)://1700
                        {
                            res = SaveEsperaReplica(command);
                        }
                        break;
                    case ((int)EstatusSolicitud.Reactivar)://6000
                        {
                            res = await ReactivacionContrato(command);
                        }
                        break;
                    case ((int)EstatusSolicitud.Cancelado)://1000
                        {
                            res = CancelarContrato(command);
                        }
                        break;
                    case ((int)EstatusSolicitud.RevisionComentariosJuridico)://500
                        {
                            res =await SaveRevisionComentariosJuridico(command);
                        }
                        break;

                    case ((int)EstatusSolicitud.EntregadoParaFirma)://800
                        {
                            res =await SaveEntregadoParaFirma(command);
                        }
                        break;

                    case ((int)EstatusSolicitud.Archivado)://900
                        {
                            res = SaveArchivado(command);
                        }
                        break;

                    case ((int)EstatusSolicitud.EntregadoPorCorreoParaFirma)://1400
                        {
                            if(command.EsLiberado == true)
                            {
                                res = await SaveEntregadoPorCorreoParaFirmaLiberadoAsync(command);
                            }
                            else
                            {
                                res = SaveEntregadoPorCorreoParaFirma(command);
                            }
                        }
                        break;
                    case ((int)EstatusSolicitud.Liberado)://1500
                        {
                            res = SaveLiberado(command);
                        }
                        break;
                    case ((int)EstatusSolicitud.Rechazado)://1300
                        {
                            res = RechazoSolicitud(command);
                        }
                        break;
                }
                #endregion

                if (command.SegundaVuelta)
                    res = await SaveSegundaVuelta(command);

                if (command.CancelarSolicitudContrato)
                    res = CancelarSolicitudContrato(command);

                if (command.EnviaComentarioAbogado)
                    res = ComentariosAbogado(command);

                if (command.ReactivarContratoSolicitante)
                    res = ReactivarPorSolicitante(command);

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }
            return res;
        }
        /// <summary>
        /// AutorizarSolicitante
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> AutorizarSolicitante(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string comentarios = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    comentarios = command.Comentarios;
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    if (command.Anexos == true)
                    {
                        if (command.ListAnexosDoc != null)
                            if (command.ListAnexosDoc.Count > 0)
                            {
                                command.ID_TipoAccion = (int)TipoAccion.AnexosPorSolicitante;
                                command.Comentarios = "";
                                responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command,true);
                            }
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 22, "Solicitante Envía Anexos al Folio", command.Comentarios,true);
                    }
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 8, "Vo.Bo. Contrato Folio", command.Comentarios,true);
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  ID_Contrato = command.ID_Contrato,
                  Mensaje = "El contrato ha sido autorizado"
              });
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }
            return res;
        }
        /// <summary>
        /// EnviarAnexosContrato
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> EnviarAnexosContrato(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string comentarios = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    comentarios = command.Comentarios;
                    command.ID_TipoAccion = (int)TipoAccion.AnexosPorSolicitante;
                    if (command.ListAnexosDoc != null)
                        if (command.ListAnexosDoc.Count > 0)
                        {
                          
                            responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command,true);
                            responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, true,false);
                            responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 22, "Solicitante Envía Anexos al Folio", command.Comentarios,true);

                        }
                        else
                        {
                            responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command,false);
                            responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 24, "Comentarios al Folio", command.Comentarios,true);
                        }
                    
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El anexo se agregó correctamente"
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// EnviarInformacion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> EnviarInformacion(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string comentarios = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    comentarios = command.Comentarios;

                    command.ID_TipoAccion = (int)TipoAccion.SolicitanteEnvioContratoRevision;
                    command.ID_Estatus = (int)EstatusSolicitud.RevisionComentariosJuridico;//500
                    if (command.ListContratosDoc != null)
                        if (command.ListContratosDoc.Count > 0)
                        {
                                responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command,false);
                        }
                        else
                        {
                            responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command,false);

                        }
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 24, "Comentarios al Folio", command.Comentarios,true);

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "La información se envio correctamente"
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// StandBy
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> StandBy(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string comentarios = "";
                int id_estatus = 0;
                bool EsSolicitante = true;
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    comentarios = command.Comentarios;
                    id_estatus = command.ID_Estatus;
                    command.ID_TipoAccion = (int)TipoAccion.StandBy;
                    command.ID_Estatus = (int)EstatusSolicitud.StandBy;
                    command.EnParoAbogado = false;
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                    if (unitofwork.TB_Historial_ParosRoutines.existeHistorialParo(command))
                    {
                        command.ID_Estatus = id_estatus;
                        unitofwork.TB_Historial_ParosRoutines.Save(command);
                        responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                        if (command.EnviaAbogado)
                        {
                            using (var con = new DataContext())
                            {
                                using (var tran = con.Database.BeginTransaction())
                                {
                                    unitofwork.TB_Contratos_SeguimientoRoutines.CancelarMeeting(command.ID_Contrato);

                                    tran.Commit();
                                }
                            }
                            EsSolicitante = false;
                        }
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 27, "Stand By Folio: ", command.Comentarios, EsSolicitante);
                    }
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El paro del contrato se realizó correctamente"
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// AutorizarAbogado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCommentaryResponse>> AutorizarAbogado(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                if (command.ID_Estatus != (int)EstatusSolicitud.PendienteDeAutorizacionB)
                {
                    string comentarios = "", mensaje = "";
                    //bool aplicaCaratula = false;
                    ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                    using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                    {
                        var contrato = unitofwork.TB_ContratosRoutines.ObtenerContrato(command.ID_Contrato);
                        if (contrato.ReqCaratula == 1 && contrato.IdTipoSolicitud != 4)
                        {
                            command.ID_Estatus = (int)EstatusSolicitud.EnEsperaDeCaratulaValidacion;
                            command.ID_TipoAccion = (int)TipoAccion.AbogadoAutorizaContrato;
                            comentarios = string.Empty;

                            command.Comentarios = string.Empty;
                            responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                            responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                            mensaje = "El contrato entró al flujo de carátula de validación.";

                            using (var con = new DataContext())
                            {
                                using (var tran = con.Database.BeginTransaction())
                                {
                                    unitofwork.TB_Contratos_EmailRoutines.SaveEmailEnvioCaratula(command.ID_Contrato);

                                    tran.Commit();
                                }
                            }
                        }
                        else
                        {
                            command.ID_Estatus = (int)EstatusSolicitud.PreparacionOriginalesParaFirma;
                            command.ID_TipoAccion = (int)TipoAccion.AbogadoAutorizaContrato;

                            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                            {
                                await unitofworkSP.ContractRepo.CalcularDiasParaEntregaDocumentos((int)command.ID_Contrato);
                                await unitofworkSP.Commit();
                            }
                            comentarios = string.Empty;

                            command.Comentarios = string.Empty;
                            responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);


                            responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 9, "Contrato Validado", command.Comentarios, false);
                            responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);

                            mensaje = "El contrato ha sido autorizado";
                        }
                    }
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                  new ManagementCommentaryResponse
                  {
                      Mensaje = mensaje
                  });
                }
                else
                {
                    
                    ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                    
                    using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                    {
                        var contrato = unitofwork.TB_ContratosRoutines.ObtenerContrato(command.ID_Contrato);
                        var fc = unitofwork.TB_FolioConsecutivoRoutines.ObtenerFolioConsecutivo();

                        #region Contrato
                        if (contrato.EsLiberado.HasValue && contrato.EsLiberado.Value)
                        {
                            command.Folio = string.Format("L{0}/{1}", (fc.IdConsecutivo + 1), DateTime.Now.Year);
                        }
                        else
                        {
                            command.Folio = string.Format("{0}/{1}", (fc.IdConsecutivo + 1), DateTime.Now.Year);
                            command.ID_Estatus = (int)EstatusSolicitud.ElaboracionRevisionJuridico;
                        }
                        command.ID_Estatus = (int)EstatusSolicitud.ElaboracionRevisionJuridico;

                   


                        responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                        #endregion

                        #region Folio Consecutivo
                        fc.IdConsecutivo = fc.IdConsecutivo + 1;
                        unitofwork.TB_FolioConsecutivoRoutines.UpdateFolioConsecutivo(fc.IdConsecutivo);
                        #endregion
                        int prioridadAnt = contrato.ID_Prioridad;
                        #region Cambio de Prioridad
                        if (command.ID_Prioridad != contrato.ID_Prioridad)
                        {
                            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                            {

                                await unitofworkSP.ContractRepo.SpIMotivoCambioPrioridad((int)command.ID_Contrato, contrato.ID_Prioridad, command.ID_Prioridad, command.ID_UsuarioEnvio);
                                await unitofworkSP.Commit();
                            }
                        }
                        #endregion

                        #region Cambio de Tipo Contrato
                        if (command.ID_TipoContrato != contrato.ID_TipoContrato)
                        {

                            if (!string.IsNullOrEmpty(contrato.Folio))
                            {
                                await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                                {

                                    await unitofworkSP.ContractRepo.SpIMotivoCambioTipoContrato((int)command.ID_Contrato,contrato.ID_TipoContrato, command.ID_Prioridad, command.ID_UsuarioEnvio);
                                    await unitofworkSP.Commit();
                                }
                            }
                        }

                        #endregion
                        #region Fecha Vencimiento
                        await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                        {

                            await unitofworkSP.ContractRepo.CalculaFechaVencimiento((int)command.ID_Contrato);
                            await unitofworkSP.Commit();
                        }
                        #endregion
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.SaveEmailAutorizar(command.ID_Contrato, 3, "Solicitud Contrato Autorizada", command.Comentarios,false,prioridadAnt);
                        
                    }
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                  new ManagementCommentaryResponse
                  {
                      Mensaje = "La solicitud de contrato ha sido autorizada"
                  });
                }
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }
            return res;
        }
        /// <summary>
        ///EnviarAbogado 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCommentaryResponse>> EnviarAbogado(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
              
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                string mensaje = string.Empty;
                int Id_Estatus = 0;

                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    if (!string.IsNullOrEmpty(command.Comentarios.Trim()) && command.ListContratosDoc.Count == 0)
                    {

                        command.ID_TipoAccion = (int)TipoAccion.AbogadoEnvioComentarios;
                        responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 24, "Comentarios Folio", command.Comentarios,false);
                        mensaje = "Los comentarios se enviaron correctamente";
                    }

                    if (command.ListContratosDoc.Count > 0)
                    {
                        Id_Estatus = command.ID_Estatus;
                        command.ID_TipoAccion = (int)TipoAccion.AbogadoEnvioContratoRevision;
                        #region Contrato
                        command.ID_Estatus = (int)EstatusSolicitud.EnRevisionSolicitante;
                        #endregion

                        if (Id_Estatus != (int)EstatusSolicitud.EnRevisionSolicitante)
                        {
                            #region Contrato Seguimiento
                           
                            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                            {

                                await unitofworkSP.ContractRepo.CalculaSeguimientoContrato((int)command.ID_Contrato);
                                await unitofworkSP.Commit();
                            }
                            #endregion
                        }
                        responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                        responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 9, "El Contrato se ha enviado a revisión", command.Comentarios,false);
                        mensaje = "El Contrato se ha enviado a revisión";
                    }
                   

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = mensaje
              });
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }
            return res;
        }
        /// <summary>
        /// SaveEsperaReplica
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> SaveEsperaReplica(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string comentarios = "";
                int id_estatus = 0;
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    comentarios = command.Comentarios;
                    id_estatus = command.ID_Estatus;
                    command.ID_TipoAccion = (int)TipoAccion.EnEsperaDeReplica;
                    command.ID_Estatus = (int)EstatusSolicitud.EnEsperaDeReplica;
                    command.EnParoAbogado = false;
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                    if (unitofwork.TB_Historial_ParosRoutines.existeHistorialParo(command))
                    {
                        command.ID_Estatus = id_estatus;
                        unitofwork.TB_Historial_ParosRoutines.Save(command);
                        responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                        if (command.EnviaAbogado)
                        {
                            using (var con = new DataContext())
                            {
                                using (var tran = con.Database.BeginTransaction())
                                {
                                    unitofwork.TB_Contratos_SeguimientoRoutines.CancelarMeeting(command.ID_Contrato);

                                    tran.Commit();
                                }
                            }
                        }
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 26, "En Espera de Replica Folio: ", command.Comentarios,false);
                    }
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El paro del contrato se realizó correctamente"
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// SaveEsperaDocumentacionInformacion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> SaveEsperaDocumentacionInformacion(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string comentarios = "";
                int id_estatus = 0;
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    comentarios = command.Comentarios;
                    id_estatus = command.ID_Estatus;
                    command.ID_TipoAccion = (int)TipoAccion.EsperaDocumentacionInformacion;
                    command.ID_Estatus = (int)EstatusSolicitud.EsperaDocumentacionInformacion;
                    command.EnParoAbogado = false;
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                    if (unitofwork.TB_Historial_ParosRoutines.existeHistorialParo(command))
                    {
                        command.ID_Estatus = id_estatus;
                        unitofwork.TB_Historial_ParosRoutines.Save(command);
                        responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                        if (command.EnviaAbogado)
                        {
                            using (var con = new DataContext())
                            {
                                using (var tran = con.Database.BeginTransaction())
                                {
                                    unitofwork.TB_Contratos_SeguimientoRoutines.CancelarMeeting(command.ID_Contrato);

                                    tran.Commit();
                                }
                            }
                        }
                        responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 25, "En Espera de Documentación y/o Información Folio: ", command.Comentarios,false);
                    }
                    
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              { 
                  
                  Mensaje = "El paro del contrato se realizó correctamente"
              });
                
            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// ReactivacionContrato
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCommentaryResponse>> ReactivacionContrato(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    var hp = unitofwork.TB_Historial_ParosRoutines.ObtenerHistorialParo(command);

                    if (hp.FechaActivacion == null)
                    {
                        command.ID_Estatus = (int)hp.UltimoEstatus;
                        command.ID_TipoAccion = (int)TipoAccion.Reactivacion;
                        responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false,false);
                        #region Historial Paro
                        unitofwork.TB_Historial_ParosRoutines.Update(command);
                        #endregion

                        #region Contrato Seguimiento Paro
                        await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                        {

                            await unitofworkSP.ContractRepo.CalculaFechaVencimientoParo((int)command.ID_Contrato);
                            await unitofworkSP.Commit();
                        }
                        #endregion
                        #region Contrato Version
                        command.Comentarios = "Reactivación del contrato, después de haber estado en Stand By, En Espera de Replica o En Espera de Documentación y/o Información";
                        responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                        #endregion

                        
                    }
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {

                  Mensaje = "El contrato se ha reactivado correctamente"
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// CancelarContrato
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> CancelarContrato(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {

                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    #region Contrato
                    command.ID_Estatus = (int)EstatusSolicitud.Cancelado;
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion
                    #region Contrato Version
                    command.ID_TipoAccion = (int)TipoAccion.Cancelado;

                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion
                    #region Contrato Mail
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 12, "Contrato Cancelado Folio: ", command.Comentarios, false);

                    using (var con = new DataContext())
                    {
                        using (var tran = con.Database.BeginTransaction())
                        {
                            unitofwork.TB_Contratos_SeguimientoRoutines.CancelarMeeting(command.ID_Contrato);
                            #endregion
                            tran.Commit();
                        }
                    }
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                  new ManagementCommentaryResponse
                  {

                      Mensaje = "El Contrato ha sido cancelado"
                  });

                }
            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// EnviarComentarios
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> EnviarComentarios(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    command.ID_TipoAccion = (int)TipoAccion.SolicitanteEnvioComentarios;
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, true, true);
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 24, "Comentarios al Contrato Folio", command.Comentarios, true);
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "Los comentarios se enviaron correctamente"
              });
            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// SaveSegundaVuelta
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCommentaryResponse>> SaveSegundaVuelta(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);

                    await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                    {

                        await unitofworkSP.ContractRepo.CalculaFechaVencimientoSegundaVuelta((int)command.ID_Contrato,command.DiasSegundaVuelta);
                        await unitofworkSP.Commit();
                    }

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "Los datos se almacenaron correctamente"
              });
            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// SaveRevisionComentariosJuridico
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async  Task<ResponseT<ManagementCommentaryResponse>> SaveRevisionComentariosJuridico(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string estatus = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    command.Comentarios = "Cambio de Estatus: Revisión de Comentarios por Jurídico";
                    estatus = "Revisión de Comentarios por Jurídico";
                    command.ID_TipoAccion = (int)TipoAccion.CambioDeEstatus;
                    command.ID_Estatus = command.ID_Estatus_Cambio;
                    var contrato = unitofwork.TB_ContratosRoutines.ObtenerContrato(command.ID_Contrato);
                    if (contrato.ID_Estatus == (int)EstatusSolicitud.PreparacionOriginalesParaFirma && unitofwork.TB_Contratos_VersionesRoutines.ObtenerTipoAccion(command.ID_Contrato) == (int)TipoAccion.AbogadoAutorizaContrato)
                    {
                        #region Contrato Seguimiento

                        await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                        {
                            await unitofworkSP.ContractRepo.CalculaSeguimientoContrato((int)command.ID_Contrato);
                            await unitofworkSP.Commit();
                        }
                        #endregion
                    }
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);

                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                      

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {

                  Mensaje = "El contrato ha cambiado de estatus: " + estatus 
              }) ;

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// SaveEntregadoParaFirma
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCommentaryResponse>> SaveEntregadoParaFirma(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string  estatus = "";
                int id_estatus = 0;
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    command.Comentarios = "Cambio de Estatus: Entregado Para Firma";
                    id_estatus = command.ID_Estatus;
                    estatus = "Entregado Para Firma";
                    command.ID_TipoAccion = (int)TipoAccion.AbogadoEnvioContratoParaFirma;
                    command.ID_Estatus = command.ID_Estatus_Cambio;

                    #region Contrato Seguimiento
                    await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                    {
                        await unitofworkSP.ContractRepo.CalculaSeguimientoContrato((int)command.ID_Contrato);
                        await unitofworkSP.Commit();
                    }
                    #endregion
                    #region TB_Contratos
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion
                    #region TB_Contratos_Versiones
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion
                    #region Correo Mail
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 10, "Contrato para Firma, Folio: ", command.Comentarios, false);
                    #endregion

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El contrato ha cambiado de estatus: " + estatus
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// SaveArchivado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> SaveArchivado(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string estatus = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    estatus = "Archivado";
                    command.Comentarios = "Cambio de Estatus: Archivado";
                    command.ID_TipoAccion = (int)TipoAccion.Archivado;
                    command.ID_Estatus =command.ID_Estatus_Cambio;
                    #region TB_Contratos
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion
                    #region TB_Contratos_Versiones
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El contrato ha cambiado de estatus: " + estatus
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// SaveEntregadoPorCorreoParaFirma
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> SaveEntregadoPorCorreoParaFirma(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string estatus = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    command.Comentarios = "Cambio de Estatus: Entregado Por Correo Para Firma";
                    estatus = "Entregado Por Correo Para Firma";
                    command.ID_TipoAccion = (int)TipoAccion.EntregadoPorCorreoParaFirma;
                    command.ID_Estatus = command.ID_Estatus_Cambio;

                    
                    #region TB_Contratos
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion
                    #region TB_Contratos_Versiones
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion
                    #region Correo Mail
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 10, "Contrato para Firma, Folio: ", command.Comentarios, false);
                    #endregion

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El contrato ha cambiado de estatus: " + estatus
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }


        /// <summary>
        /// SaveLiberado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> SaveLiberado(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                string estatus = "";
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    estatus = "Liberado";
                    command.Comentarios = "Cambio de Estatus: Liberado";
                    command.ID_TipoAccion = (int)TipoAccion.Liberado;
                    command.ID_Estatus = command.ID_Estatus_Cambio;
                    #region TB_Contratos
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion
                    #region TB_Contratos_Versiones
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion
                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El contrato ha cambiado de estatus: " + estatus
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
        /// <summary>
        /// RechazoSolicitud
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> RechazoSolicitud(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {

                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {

                    #region Contrato
                    command.ID_Estatus = (int)EstatusSolicitud.Rechazado;
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion
                    #region Contrato Version
                    command.ID_TipoAccion = (int)TipoAccion.RechazoSolicitudContrato;
                    
                   responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion
                    #region Contrato Mail
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.Save(command.ID_Contrato, 5, "Rechazo de Solicitud de Contrato", command.Comentarios, false);


                    using (var con = new DataContext())
                    {
                        using (var tran = con.Database.BeginTransaction())
                        {
                            unitofwork.TB_Contratos_SeguimientoRoutines.CancelarMeeting(command.ID_Contrato);

                            tran.Commit();
                        }
                    }
                    #endregion

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {

                  Mensaje = "El Contrato ha sido cancelado"
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }

        /// <summary>
        /// SaveEntregadoPorCorreoParaFirma
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCommentaryResponse>> SaveEntregadoPorCorreoParaFirmaLiberadoAsync(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            try
            {
                ManagementCommentaryResponse responseComentary = new ManagementCommentaryResponse();
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    command.Comentarios = command.Comentarios;
                    command.ID_TipoAccion = (int)TipoAccion.AbogadoEnvioContratoParaFirma;
                    command.ID_Estatus = command.ID_Estatus_Cambio;

                    #region TB_Contratos
                    responseComentary = unitofwork.TB_ContratosRoutines.UpdateStatusContracts(command, false, false);
                    #endregion

                    #region TB_Contratos_Versiones
                    responseComentary = unitofwork.TB_Contratos_VersionesRoutines.Save(command, false);
                    #endregion

                    #region Contrato Seguimiento
                    await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                    {
                        await unitofworkSP.ContractRepo.CalculaSeguimientoContrato((int)command.ID_Contrato);
                        await unitofworkSP.Commit();
                    }
                    #endregion

                    #region Correo Mail
                    responseComentary = unitofwork.TB_Contratos_EmailRoutines.SaveContratoFirma(command.ID_Contrato, 21, "Envío Contrato Para Firma. Folio ", command.Comentarios, false, command.ListContratosDoc);
                    #endregion

                }
                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
              new ManagementCommentaryResponse
              {
                  Mensaje = "El contrato se envió correctamente."
              });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }

            return res;
        }
    
        private async Task<ResponseT<ManagementCommentaryResponse>> AutorizarLiberado(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato = new List<BuscarAutorizadoresPorContratoDTO>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_UsuarioEnvio.ToString(),
                                    Path = "Comments.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Autoriza Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion

                            unitofwork.TB_ContratosRoutines.SaveEstatusContrato(command.ID_Contrato, (int)EstatusSolicitud.EnEsperaDeCaratulaValidacion);
                            unitofwork.TB_Contratos_VersionesRoutines.SaveLiberadoVersion(command.ID_Contrato, command.ID_UsuarioEnvio);

                            #region Contrato Seguimiento
                            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                            {

                                await unitofworkSP.ContractRepo.CalculaSeguimientoContrato((int)command.ID_Contrato);
                                await unitofworkSP.Commit();
                            }
                            #endregion

                            #region Envío correos
                            unitofwork.TB_Contratos_EmailRoutines.SaveContratoCaratula(command.ID_Contrato, ListBuscarAutorizadoresPorContrato);
                            #endregion

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCommentaryResponse
                              {
                                  Mensaje = "El contrato ha entrado al flujo de carátula de validación"
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// CancelarSolicitudContrato
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> CancelarSolicitudContrato(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato = new List<BuscarAutorizadoresPorContratoDTO>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_UsuarioEnvio.ToString(),
                                    Path = "Comments.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Autoriza Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion

                            unitofwork.TB_ContratosRoutines.SaveEstatusContratoCancelado(command.ID_Contrato, (int)EstatusSolicitud.Cancelado, command.Comentarios, command.ID_UsuarioEnvio);
                            unitofwork.TB_Contratos_VersionesRoutines.SaveVersionContratoCancelado(command);
                            unitofwork.TB_Contratos_EmailRoutines.SaveEmailContratoCancelado(command);
                            unitofwork.TB_Contratos_SeguimientoRoutines.CancelarMeeting(command.ID_Contrato);

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCommentaryResponse
                              {
                                  Mensaje = "El Contrato ha sido cancelado"
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> ComentariosAbogado(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato = new List<BuscarAutorizadoresPorContratoDTO>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_UsuarioEnvio.ToString(),
                                    Path = "Comments.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Autoriza Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion
                            unitofwork.TB_Contratos_VersionesRoutines.SaveVersionComentarioAbogado(command);
                            unitofwork.TB_ContratosRoutines.SaveEstatusComentarioAbogado(command.ID_Contrato);
                            unitofwork.TB_Contratos_EmailRoutines.SaveEmailComentarioAbogado(command);

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCommentaryResponse
                              {
                                  Mensaje = "Los comentarios se enviaron correctamente"
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// ReactivarPorSolicitante
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCommentaryResponse> ReactivarPorSolicitante(ManagementCommentaryCommand command)
        {
            ResponseT<ManagementCommentaryResponse> res = new ResponseT<ManagementCommentaryResponse>();
            List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato = new List<BuscarAutorizadoresPorContratoDTO>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_UsuarioEnvio.ToString(),
                                    Path = "Comments.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Autoriza Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion
                            unitofwork.TB_ContratosRoutines.SaveReactivarContratoSolicitante(command.ID_Contrato);
                            unitofwork.TB_Historial_ParosRoutines.UpdateFechaParoSolicitante(command.ID_Contrato,command.ID_UsuarioEnvio);
                            unitofwork.TB_Contratos_VersionesRoutines.SaveVersionReactivarContratoSol(command);
                            
                            

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCommentaryResponse
                              {
                                  Mensaje = "El contrato se ha reactivado correctamente"
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCommentaryResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
                        }
                    }
                }
            }
            return res;
        }
    }
}
