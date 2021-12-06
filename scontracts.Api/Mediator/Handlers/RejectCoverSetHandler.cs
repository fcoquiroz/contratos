using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Persistence;
using RepositorySP.Persistence;
using scontracts.Api.Helpers;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Enums;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    public class RejectCoverSetHandler : Constants, IRequestHandler<RejectCoverSetCommand, ResponseT<RejectCoverSetResponse>>
    {
        public async Task<ResponseT<RejectCoverSetResponse>> Handle(RejectCoverSetCommand command, CancellationToken cancellationToken)
        {
            ResponseT<RejectCoverSetResponse> res = new ResponseT<RejectCoverSetResponse>();
            RejectCoverSetResponse response = new RejectCoverSetResponse();

            /* //Guardado del log
             try
             {
                 new ContractContext(new ContractLogginData()).SaveLog(command);
             }
             catch (Exception ex)
             {
                 ErrorLogFile.LogCritical(ex.Message);
             }*/

            //Guardar solicitud
            try
            {


                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    CoverDTO AutorizadorData = null;
                    AutorizadorData = command.EsExtra == 0 ? unitofwork.Cat_AutorizadoresRoutines.AutorizadorData(command.ID_Autorizador, (int)command.Id_Contrato) :
                                                             unitofwork.Cat_Autorizadores_extraRoutines.AutorizadorExtraData(command.ID_Autorizador, (int)command.Id_Contrato);
                    bool isExtra = command.EsExtra == 1;
                    //CoverDTO AutorizadorData = unitofwork.Cat_AutorizadoresRoutines.AutorizadorData(command.ID_Autorizador, (int)command.Id_Contrato);
                    CoverDTO AutorizadoresAutData = unitofwork.TB_Autorizadores_AutRoutines.AutorizadoresAutData((int)command.Id_Contrato, command.Vuelta, command.ID_Autorizador, isExtra);
                    AutorizadoresAutData.ExisteRechazo = unitofwork.TB_Autorizadores_AutRoutines.AutorizadoresAutExisteRechazo((int)command.Id_Contrato, command.Vuelta);

                    command.ExisteAutorizadores_Aut = false;
                    if (AutorizadoresAutData != null)
                        command.ExisteAutorizadores_Aut = true;

                    command.NombreAutorizador = AutorizadorData.NombreAutorizador;
                    command.TipoAutorizador = AutorizadorData.TipoAutorizador;

                    #region Código para Tipo de Autorizador comentado.
                    /*switch (command.TipoAutorizador)
                    {
                        case (int)TipoAutorizador.AutorizadorBC:
                            if (command.ExisteAutorizadores_Aut && AutorizadoresAutData.B_Business == 1)
                                AutorizadoresAutData.ExisteAutorizacion = true;
                            break;
                        case (int)TipoAutorizador.AutorizadorComercial:
                            if (command.ExisteAutorizadores_Aut && AutorizadoresAutData.B_Comercial == 1)
                                AutorizadoresAutData.ExisteAutorizacion = true;
                            break;
                        case (int)TipoAutorizador.AutorizadorTecnico:
                            if (command.ExisteAutorizadores_Aut && AutorizadoresAutData.B_Tecnico_Operativo == 1)
                                AutorizadoresAutData.ExisteAutorizacion = true;
                            break;
                    }*/
                    #endregion

                    if (AutorizadoresAutData.Autorizo == null)
                    {
                        if (AutorizadoresAutData.ExisteRechazo == false)
                        {
                            AutorizadoresAutData = unitofwork.TB_Autorizadores_AutRoutines.AutorizadoresAutSaveReject(command);
                            bool emailConfirmation = unitofwork.TB_Contratos_EmailRoutines.SaveEmailRejectCover(command);
                            unitofwork.TB_Contratos_VersionesRoutines.RejectCover(command);

                            try
                            {
                                await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                                {

                                    await unitofworkSP.ContractRepo.ActualizarTabContrato_Parameters((int)command.Id_Contrato, (int)EstatusSolicitud.EnEsperaDeCaratulaValidacion);
                                    await unitofworkSP.Commit();
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }

                            response.Mensaje = "Se ha rechazado correctamente por: " + command.NombreAutorizador;
                        }
                        else
                        {
                            response.Mensaje = "Esta Caratula ya fue Rechazada.";
                        }
                    }
                    else
                    {
                        response.Mensaje = (AutorizadoresAutData.Autorizo == true ? "Esta Caratula ya fue Autorizada" : "Esta Caratula ya fue Rechazada");
                    }

                    #region Condiciones anteriores comentadas.
                    /*if (!command.ExisteAutorizadores_Aut || !AutorizadoresAutData.ExisteAutorizacion)
                    {
                        unitofwork.TB_Contratos_VersionesRoutines.RejectCover(command);

                        try
                        {
                            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                            {

                                await unitofworkSP.ContractRepo.ActualizarTabContrato_Parameters((int)command.Id_Contrato, (int)EstatusSolicitud.EnRevisionSolicitante);
                                await unitofworkSP.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLogFile.LogCritical(ex.Message);
                        }

                        response.Mensaje = "Se ha rechazado correctamente por: " + command.NombreAutorizador;

                    
                    }
                    else
                    {
                        response.Mensaje = "Esta Caratula ya fue Autorizada";
                    }*/
                    #endregion

                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                    new RejectCoverSetResponse
                    {
                        ID_Contrato = command.Id_Contrato,
                        Mensaje = response.Mensaje
                    });
                }

            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new RejectCoverSetResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }
            return res;
        }
    }
}
