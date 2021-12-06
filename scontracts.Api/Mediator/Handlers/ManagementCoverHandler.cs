

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
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
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// ManagementCoverHandler
    /// </summary>
    public class ManagementCoverHandler : Constants, IRequestHandler<ManagementCoverCommand, ResponseT<ManagementCoverResponse>>
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ManagementCoverResponse>> Handle(ManagementCoverCommand command, CancellationToken cancellationToken)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
            switch (command.Accion)
            {
                case "Guardar":
                    res = GuardarCaratulaValidacion(command);
                    break;
                case "Enviar":
                    res = EnviarCaratulaValidacion(command);
                    break;
                case "GuardarAutorizador":
                    res = GuardarAutorizador(command);
                    break;
                case "EditarAutorizador":
                    res =await EditarAutorizador(command);
                    break;
                case "EliminarAutorizador":
                    res = EliminarAutorizador(command);
                    break;
                case "AutorizarCaratula":
                    res =await AutorizarCaratula(command);
                    break;
                case "RechazarCaratula":
                    res = await RechazarCaratula(command);
                    break;
                default:
                    break;
            }
            return res;
        }
        /// <summary>
        /// GuardarCaratulaValidacion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCoverResponse> GuardarCaratulaValidacion(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            List<CoverDataGetDTO> ObtenerCamposCaratula = new List<CoverDataGetDTO>();
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "CreateCaratula.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Solicitante Guarda Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion

                            //using (var  con = new DataContext())
                            //{
                            //    using (var tran = con.Database.BeginTransaction())
                            //    {
                            List<CoverDetalleDataGetDTO> existeContrato = new List<CoverDetalleDataGetDTO>();
                            existeContrato = unitofwork.TB_Detalle_CaratulaRoutines.ObtenerDetalleCaratula(command.ID_Contrato);

                            var existe = "";

                            //if (existeContrato == null)
                            //{
                            //    existe = "";
                            //}
                            //else
                            //{
                            //    existe = existeContrato.Count;
                            //}


                            if (existeContrato.Count() == 0)
                            {
                                unitofwork.TB_Detalle_CaratulaRoutines.GuardarDetalleCaratula(command);
                                unitofwork.Cat_ProductoRoutines.InsertXProducto(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXInversion(command.Inversion, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXCapacidad(command.Capacidad, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXPena(command.Pena, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.Moneda(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertClientesProductoPais(command.ID_Contrato);
                            }
                            else
                            {
                                unitofwork.TB_Detalle_CaratulaRoutines.GuardarExisteDetalleCaratula(command);
                                unitofwork.Cat_ProductoRoutines.InsertXProducto(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXInversion(command.Inversion, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXCapacidad(command.Capacidad, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXPena(command.Pena, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.Moneda(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertClientesProductoPais(command.ID_Contrato);
                            }


                            //tran.Commit();
                            tran.Commit();
                            //    }
                            //}


                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                             new ManagementCoverResponse
                             {
                                 Mensaje = "Los datos fueron guardados correctamente"
                             });
                        }

                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse());
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// EnviarCaratulaValidacion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCoverResponse> EnviarCaratulaValidacion(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            List<CoverDataGetDTO> ObtenerCamposCaratula = new List<CoverDataGetDTO>();
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "CreateCaratula.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Solicitante Envia Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion

                            //using (var  con = new DataContext())
                            //{
                            //    using (var tran = con.Database.BeginTransaction())
                            //    {
                            List<CoverDetalleDataGetDTO> existeContrato = new List<CoverDetalleDataGetDTO>();
                            existeContrato = unitofwork.TB_Detalle_CaratulaRoutines.ObtenerDetalleCaratula(command.ID_Contrato);

                            var existe = "";

                            //if (existeContrato == null)
                            //{
                            //    existe = "";
                            //}
                            //else
                            //{
                            //    existe = existeContrato.Count;
                            //}


                            if (existeContrato.Count() == 0)
                            {
                                unitofwork.TB_Detalle_CaratulaRoutines.GuardarDetalleCaratula(command);
                                unitofwork.Cat_ProductoRoutines.InsertXProducto(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXInversion(command.Inversion, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXCapacidad(command.Capacidad, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXPena(command.Pena, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.Moneda(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertClientesProductoPais(command.ID_Contrato);
                            }
                            else
                            {
                                unitofwork.TB_Detalle_CaratulaRoutines.GuardarExisteDetalleCaratula(command);
                                unitofwork.Cat_ProductoRoutines.InsertXProducto(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXInversion(command.Inversion, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXCapacidad(command.Capacidad, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertXPena(command.Pena, command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.Moneda(command.ID_Contrato);
                                unitofwork.TB_Detalle_CaratulaRoutines.InsertClientesProductoPais(command.ID_Contrato);
                            }

                            unitofwork.TB_Autorizadores_ContratoRoutines.GuardarAutorizadoresContrato(command.ID_Contrato);
                            //tran.Commit();
                            tran.Commit();
                            //    }
                            //}


                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                             new ManagementCoverResponse
                             {
                                 Mensaje = "La carátula ahora pasa del lado del abogado para su autorización o rechazo"
                             });
                        }

                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// GuardarAutorizador
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCoverResponse> GuardarAutorizador(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {
                            List<CoverDataGetDTO> ObtenerCamposCaratula = new List<CoverDataGetDTO>();
                            #region Log
                            try
                            {
                                LogCreateRequest requestLog = new LogCreateRequest
                                {
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "AuthorizeCaratula.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Guarda Autorizador"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion
                            unitofwork.Cat_Autorizadores_extraRoutines.GuardarAutorizadoresExtra(command);
                            unitofwork.TB_Autorizadores_ContratoRoutines.GuardarAutorizadoresContratoCorreo(command);
                            unitofwork.TB_MultiProductoRoutines.GuardarAutorizadoresMultiProducto(command);

                            
                            tran.Commit();
                                                       res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                             new ManagementCoverResponse
                             {
                                 Mensaje = "Se guardo correctamente el autorizador extra"
                             });
                        }

                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse());
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// EditarAutorizador
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCoverResponse>> EditarAutorizador(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
            List<BuscarAutorizadoresPorContratoDTO> busquedaAutorizador = new List<BuscarAutorizadoresPorContratoDTO>();
            string mensaje = "";
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
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "AuthorizeCaratula.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Edita Autorizador"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion
                            busquedaAutorizador = await BuscarAutorizadoresPorContrato(command.ID_Contrato);
                            var coinciden = busquedaAutorizador.Where(x => x.IDProducto == command.ID_Producto && x.IDTipoAut == command.ID_TipoAutorizador).ToList();
                            var existe = false;

                            if (coinciden.Count() != 0)
                            {
                                if (coinciden.Where(x => x.Extra == 0).Count() == 0)
                                {
                                    //si el registro que tiene los mismos datos no es el que se está editando, da false
                                    existe = coinciden.Where(x => x.Extra == 1 && x.Id_Autorizador == command.idAutorizador).Count() == 0;
                                }
                                else
                                {
                                    existe = true;
                                }
                            }

                            if (!existe)
                            {
                                unitofwork.Cat_Autorizadores_extraRoutines.EditarAutorizadores(command);
                                mensaje = "El Autorizador se editó correctamente";
                            }
                            else
                            {

                                mensaje = "Ya existe un autorizador con el mismo tipo de autorizador para el mismo producto";
                            }


                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCoverResponse
                              {
                                  Mensaje = mensaje
                              });
                        }

                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse());
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// EliminarAutorizador
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private ResponseT<ManagementCoverResponse> EliminarAutorizador(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
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
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "AuthorizeCaratula.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Elimina Autorizador"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion

                            unitofwork.TB_Autorizadores_ContratoRoutines.EliminarAutorizadoresContrato(command);

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCoverResponse
                              {
                                  Mensaje = "El Autorizador se eliminó correctamente"
                              });
                        }

                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse());
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// AutorizarCaratula
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCoverResponse>> AutorizarCaratula(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
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
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "AuthorizeCaratula.cshtml",
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
                            unitofwork.TB_Contratos_VersionesRoutines.SaveCaratulaVersion(command.ID_Contrato, command.ID_Usuario);
                            unitofwork.TB_Autorizadores_AutRoutines.GenerateAutorizacion((int)command.ID_Contrato);

                            #region Envío correos
                            ListBuscarAutorizadoresPorContrato = await BuscarAutorizadoresPorContrato(command.ID_Contrato);

                            unitofwork.TB_Contratos_EmailRoutines.SaveContratoCaratula(command.ID_Contrato,ListBuscarAutorizadoresPorContrato);
                            #endregion
                            #region Cambio de estatus y vigencia

                            unitofwork.TB_ContratosRoutines.SaveEstatusContrato(command.ID_Contrato, (int)EstatusSolicitud.CaratulaRevisionAutorizadores);

                            #region Contrato Seguimiento
                            await CalculaSeguimientoContrato(command.ID_Contrato);
                            #endregion

                            #endregion

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCoverResponse
                              {
                                  Mensaje = "La carátula fue autorizada por el Abogado, y se envió correo a los autorizadores"
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse());
                        }
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// RechazarCaratula
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<ResponseT<ManagementCoverResponse>> RechazarCaratula(ManagementCoverCommand command)
        {
            ResponseT<ManagementCoverResponse> res = new ResponseT<ManagementCoverResponse>();
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
                                    UserName = command.ID_Usuario.ToString(),
                                    Path = "AuthorizeCaratula.cshtml",
                                    Control = "Contract/managementCover",
                                    Message = "Abogado Rechaza Caratula"
                                };
                                var commands = new LogCreateCommand(requestLog);
                                new ContractContext(new ContractLogginData()).SaveLog(commands);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogFile.LogCritical(ex.Message);
                            }
                            #endregion
                            unitofwork.TB_Contratos_VersionesRoutines.SaveRechazoCaratula(command.ID_Contrato, command.ID_Usuario,command.Comentarios);
                            

                           
                            #region Cambio de estatus y vigencia

                            unitofwork.TB_ContratosRoutines.SaveEstatusContrato(command.ID_Contrato, (int)EstatusSolicitud.EnEsperaDeCaratulaValidacion);

                            #region Contrato Seguimiento
                            await CalculaSeguimientoContrato(command.ID_Contrato);
                            #endregion

                            #endregion


                            #region Envío correos

                            unitofwork.TB_Contratos_EmailRoutines.SaveEmailRechazo(command.ID_Contrato,command.Comentarios);
                           
                            #endregion

                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new ManagementCoverResponse
                              {
                                  Mensaje = "La carátula se rechazó"
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new ManagementCoverResponse());
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// BuscarAutorizadoresPorContrato
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        private async Task<List<BuscarAutorizadoresPorContratoDTO>> BuscarAutorizadoresPorContrato(int ID_Contrato)
        {
            List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato = new List<BuscarAutorizadoresPorContratoDTO>();
            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
            {
                return ListBuscarAutorizadoresPorContrato = await unitofworkSP.ContractRepo.BuscarAutorizadoresPorContrato(ID_Contrato);
            }

        }
        /// <summary>
        /// CalculaSeguimientoContrato
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        public async Task CalculaSeguimientoContrato(long ID_Contrato)
        {
            await using (var unitofworkSP = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
            {
                await unitofworkSP.ContractRepo.CalculaSeguimientoContrato((int)ID_Contrato);
                await unitofworkSP.Commit();
            }
        }

    }
}
