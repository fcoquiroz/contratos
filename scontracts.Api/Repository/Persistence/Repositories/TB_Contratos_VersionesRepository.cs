using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Api.Mediator.Commands;
using App.Contratos.DAL.Enums;
using scontracts.Shared.Responses;
using Microsoft.EntityFrameworkCore.Query.Internal;
using scontracts.Shared.Requests;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using scontracts.Shared.DTO;
using scontracts.Shared.Enums;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_Contratos_VersionesRepository
    /// </summary>
    public class TB_Contratos_VersionesRepository : Repository<TB_Contratos_Versiones>, ITB_Contratos_VersionesRepository
    {
        /// <summary>
        /// TB_Contratos_VersionesRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Contratos_VersionesRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// ObtenerContratoVersion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ContractCreateRequest ObtenerContratoVersion(ContractCreateCommand command)
        {
            ContractCreateRequest c_v = new ContractCreateRequest();

            if (command.ExisteArchivo)
            {
                c_v.Version = consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == command.ID_Contrato).Count() + 1;
                c_v.ContenttType = command.ContenttType;
                c_v.Extension = command.Extension;
                c_v.NombreContrato = command.NombreContrato;

            }
            else
            {
                c_v = (from qry in consisContext.TB_Contratos_VersionesRoutines
                       where qry.ID_Contrato == command.ID_Contrato && qry.NombreContrato != null && qry.ID_TipoAccion == (int)TipoAccion.Borrador
                       orderby qry.ID_Contrato_Version
                       select new ContractCreateRequest
                       {

                           NombreContrato = qry.NombreContrato,
                           Extension = qry.Extension,
                           ContenttType = qry.ContenttType,
                           Version = 1,
                       }
                           ).FirstOrDefault();


            }

            return c_v;

        }
        /// <summary>
        /// ObtenerSeguimientoSolicitudes
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        public List<SeguimientoSolicitudDTO> ObtenerSeguimientoSolicitudes(long id_contrato)
        {
          
            var a = (from ct in consisContext.TB_ContratosRoutines
                     join ce in consisContext.Cat_EstatusRoutines on ct.ID_Estatus equals ce.ID_Estatus
                     where ct.ID_Contrato == id_contrato
                     select new { Folio = ct.Folio, Estatus = ce.Estatus, Id_Estatus = ce.ID_Estatus, DiasSegundaVuelta = ct.DiasSegundaVuelta, EsLiberado = ct.EsLiberado, ReqCaratula = ct.ReqCaratula, IdTipoSolicitud = ct.IdTipoSolicitud }).First();
            



            var cf = (from cfgp in consisContext.Cfg_PrioridadComplejidadSegundaRoutines select new { ValorX = cfgp.ValorX, ValorY = cfgp.ValorY, ValorZ = cfgp.ValorZ }).FirstOrDefault();
            List<SeguimientoSolicitudDTO> h = (
                from cv in consisContext.TB_Contratos_VersionesRoutines
                join ta in consisContext.Cat_TipoAccionRoutines on cv.ID_TipoAccion equals ta.ID_TipoAccion
                join cu in consisContext.Cat_UsuarioRoutines on cv.ID_UsuarioEnvio equals cu.ID_Usuario
                where cv.ID_Contrato == id_contrato
                && cv.ID_TipoAccion != (int)TipoAccion.Borrador
                orderby cv.FechaCreacion descending
                select new SeguimientoSolicitudDTO
                {
                    ID_Contrato_Version = cv.ID_Contrato_Version,
                    TipoAccion = ta.TipoAccion,
                    Comentarios = (string.IsNullOrEmpty(cv.Comentarios)) ? string.Empty : cv.Comentarios,
                    NombreUsuario = cu.Nombre,
                    FechaCreacion = cv.FechaCreacion,
                    NombreContrato = (string.IsNullOrEmpty(cv.NombreContrato)) ? string.Empty : cv.NombreContrato,
                    Folio = a.Folio != null ? a.Folio : "",
                    DescEstatus = a.Estatus != null ? a.Estatus : "",
                    Id_Estatus = a.Id_Estatus,
                    DiasSegundaVuelta = a.DiasSegundaVuelta,
                    ValorX = cf.ValorX,
                    ValorY = cf.ValorY,
                    ValorZ = cf.ValorZ,
                    EsLiberado = a.EsLiberado == null ? false : true,
                    NumAgrupados = cv.Agrupar,
                    ReqCaratula = a.ReqCaratula == null ? false : true,
                    IdTipoSolicitud = a.IdTipoSolicitud
                    
                }).ToList();

            return h;
        }
        /// <summary>
        /// AcceptCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public AcceptCoverSetResponse AcceptCover(AcceptCoverSetCommand command)
        {
            AcceptCoverSetResponse res = new AcceptCoverSetResponse();


            var comentarios = "El autorizador " + command.NombreAutorizador + " realizó la autorización";

            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                TB_Contratos_Versiones dto = new TB_Contratos_Versiones
                {
                    ID_Contrato = command.Id_Contrato,
                    FechaCreacion = DateTime.Now,
                    ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                    ID_TipoAccion = (int)TipoAccion.AutorizadorAutorizar,
                    Comentarios = comentarios

                };
                unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                unitofwork.Commit();
            }
            return res;
        }
        /// <summary>
        /// RejectCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public void RejectCover(RejectCoverSetCommand command)
        {
            RejectCoverSetResponse res = new RejectCoverSetResponse();
            var comentarios = "El autorizador " + command.NombreAutorizador + " ha rechazado la solicitud por el siguiente motivo: ";

            comentarios = comentarios + command.Motivo;
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                TB_Contratos_Versiones dto = new TB_Contratos_Versiones
                {
                    ID_Contrato = command.Id_Contrato,
                    FechaCreacion = DateTime.Now,
                    ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                    ID_TipoAccion = (int)TipoAccion.AutorizadorRechaza,
                    Comentarios = comentarios

                };


                unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                unitofwork.Commit();



            }
        }

        public ManagementCommentaryResponse Save(ManagementCommentaryCommand command, bool blnAnexo)
        {
            ManagementCommentaryResponse res = new ManagementCommentaryResponse();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                if (command.ListContratosDoc != null && command.ListContratosDoc.Count > 0 && !blnAnexo)
                {
                    foreach (var docFile in command.ListContratosDoc)
                    {
                        TB_Contratos_Versiones dto = new TB_Contratos_Versiones
                        {
                            ID_Contrato = command.ID_Contrato,
                            FechaCreacion = DateTime.Now,
                            ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                            ID_TipoAccion = command.ID_TipoAccion, //0 /// aqui se pone si es borrador o es envio este valor lo mandaran al consumir el api
                            Comentarios = command.Comentarios, //solo se llega lleno cuando es envio
                            Version = (unitofwork.TB_Contratos_VersionesRoutines.Find(o => o.ID_Contrato == command.ID_Contrato).Count() + 1),
                            NombreContrato = docFile.NombreArchivo,
                            Extension = docFile.Extension,
                            ContenttType = docFile.ContenttType,

                        };
                        unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                        unitofwork.Commit();
                    }

                }
                else if (command.ListAnexosDoc != null && command.ListAnexosDoc.Count > 0 && blnAnexo)
                {
                    foreach (var docFile in command.ListAnexosDoc)
                    {

                        TB_Contratos_Versiones dto = new TB_Contratos_Versiones
                        {
                            ID_Contrato = command.ID_Contrato,
                            FechaCreacion = DateTime.Now,
                            ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                            ID_TipoAccion = command.ID_TipoAccion, //0 /// aqui se pone si es borrador o es envio este valor lo mandaran al consumir el api
                            Comentarios = command.Comentarios, //solo se llega lleno cuando es envio
                            Version = command.Version,
                            NombreContrato = docFile.NombreArchivo,
                            Extension = docFile.Extension,
                            ContenttType = docFile.ContenttType,
                            Agrupar = docFile.Agrupar
                        };
                        unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                        unitofwork.Commit();
                    }
                }
                else if (command.EsLiberado)
                {
                    TB_Contratos_Versiones dto = new TB_Contratos_Versiones
                    {
                        ID_Contrato = command.ID_Contrato,
                        FechaCreacion = DateTime.Now,
                        ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                        ID_TipoAccion = (int)TipoAccion.AbogadoEsperaCaratulaValidacion,
                        Comentarios = command.Comentarios,
                    };
                    unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                    unitofwork.Commit();
                }
                else if (!blnAnexo)
                {
                    TB_Contratos_Versiones dto = new TB_Contratos_Versiones
                    {
                        ID_Contrato = command.ID_Contrato,
                        FechaCreacion = DateTime.Now,
                        ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                        ID_TipoAccion = command.ID_TipoAccion, 
                        Comentarios = command.Comentarios, 
                    };
                    unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                    unitofwork.Commit();
                }
                return res;
            }
        }
        /// <summary>
        /// ObtenerContratoVersiones
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        public int ObtenerTipoAccion(long ID_Contrato)
        {
            int c_v = 0;
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                c_v = unitofwork.TB_Contratos_VersionesRoutines.Find(x => x.ID_Contrato == ID_Contrato).OrderBy(x => x.ID_Contrato_Version).FirstOrDefault().ID_TipoAccion;

            }
            return c_v;
        }
        /// <summary>
        /// SaveCaratulaVersion
        /// </summary>
        /// <param name="ID_contrato"></param>
        /// <param name="ID_Usuario"></param>
        public void SaveCaratulaVersion(long ID_contrato, int ID_Usuario)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(ID_contrato);
                db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_UsuarioEnvio = ID_Usuario,
                    ID_TipoAccion = (int)TipoAccion.AbogadoAutoriza,
                    Comentarios = "El Contrato ha ingresado al proceso de autorización",
                    FechaCreacion = DateTime.Now
                });
                db.SaveChanges();
            }

        }
        /// <summary>
        /// SaveRechazoCaratula
        /// </summary>
        /// <param name="ID_contrato"></param>
        /// <param name="ID_Usuario"></param>
        /// <param name="Comentarios"></param>
        public void SaveRechazoCaratula(long ID_contrato, int ID_Usuario, string Comentarios)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(ID_contrato);
                db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_UsuarioEnvio = ID_Usuario,
                    ID_TipoAccion = (int)TipoAccion.AbogadoRechaza,
                    Comentarios = Comentarios,
                    FechaCreacion = DateTime.Now
                });
                db.SaveChanges();
            }

        }
        /// <summary>
        /// SaveLiberadoVersion
        /// </summary>
        /// <param name="ID_contrato"></param>
        /// <param name="ID_Usuario"></param>
        public void SaveLiberadoVersion(long ID_contrato, int ID_Usuario)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(ID_contrato);
                db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_UsuarioEnvio = ID_Usuario,
                    ID_TipoAccion = (int)TipoAccion.AbogadoAutorizaContrato,
                    Comentarios = string.Empty,
                    FechaCreacion = DateTime.Now
                });
                db.SaveChanges();
            }

        }
        /// <summary>
        /// NombreContratoPrincipalRelacionado
        /// Obtiene el nombre del contrato de la solicitud de contrato principal
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        public string ObtenerNombreContratoPrincipalRelacionado(long ID_Contrato)
        {
            string nombreContrato = "";
            using (var db = new DataContext())
            {
                var lastRegister = db.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == ID_Contrato && x.NombreContrato != null).OrderByDescending(x => x.ID_Contrato_Version).First();
                nombreContrato = lastRegister.NombreContrato;
            }
            return nombreContrato;
        }
        /// <summary>
        /// SaveVersionContratoCancelado
        /// </summary>
        /// <param name="command"></param>
        public void SaveVersionContratoCancelado(ManagementCommentaryCommand command)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(command.ID_Contrato);
                db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_UsuarioEnvio =command.ID_UsuarioEnvio,
                    ID_TipoAccion = (int)TipoAccion.Cancelado,
                    Comentarios =command.Comentarios,
                    FechaCreacion = DateTime.Now,
                    EvidenciaCancelacion = command.ListContratosDoc[0].NombreArchivo,
                    Extension = command.ListContratosDoc[0].Extension,
                    ContenttType = command.ListContratosDoc[0].ContenttType,
                });
                db.SaveChanges();
            }

        }
        /// <summary>
        /// SaveVersionComentarioAbogado
        /// </summary>
        /// <param name="command"></param>
        public void SaveVersionComentarioAbogado(ManagementCommentaryCommand command)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(command.ID_Contrato);

                if (contrato.ID_Estatus == (int)EstatusSolicitud.EsperaDocumentacionInformacion || contrato.ID_Estatus == (int)EstatusSolicitud.StandBy || contrato.ID_Estatus == (int)EstatusSolicitud.EnEsperaDeReplica)
                {

                    if (!string.IsNullOrEmpty(command.Comentarios.Trim()) && command.ListContratosDoc != null && command.ListContratosDoc.Count > 0)
                    {


                        db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                        {
                            ID_Contrato = contrato.ID_Contrato,
                            ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                            ID_TipoAccion = (int)TipoAccion.AbogadoEnvioComentarios,
                            NombreContrato = command.ListContratosDoc[0].NombreArchivo,
                            Version = (db.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == contrato.ID_Contrato).Count() + 1),
                            Extension = command.ListContratosDoc[0].Extension,
                            ContenttType = command.ListContratosDoc[0].ContenttType,
                            Comentarios = command.Comentarios.Trim(),
                            FechaCreacion = DateTime.Now
                        });
                    }
                    else
                    {
                        db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                        {
                            ID_Contrato = contrato.ID_Contrato,
                            ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                            ID_TipoAccion = (int)TipoAccion.AbogadoEnvioComentarios,
                            Comentarios = command.Comentarios,
                            FechaCreacion = DateTime.Now,
                        });
                    }
                }
                else
                {
                    db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                    {
                        ID_Contrato = contrato.ID_Contrato,
                        ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                        ID_TipoAccion = (int)TipoAccion.AbogadoEnvioComentarios,
                        Comentarios = command.Comentarios,
                        FechaCreacion = DateTime.Now,
                    });

                }
                    
                db.SaveChanges();
            }

        }
        /// <summary>
        /// SaveVersionReactivarContratoSol
        /// </summary>
        /// <param name="command"></param>
        public void SaveVersionReactivarContratoSol(ManagementCommentaryCommand command)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(command.ID_Contrato);
                db.TB_Contratos_VersionesRoutines.Add(new TB_Contratos_Versiones
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                    ID_TipoAccion = (int)TipoAccion.Reactivacion,
                    Comentarios = "Reactivación del contrato, después de haber estado en Stand By, En Espera de Replica o En Espera de Documentación y/o Información",
                    FechaCreacion = DateTime.Now
                });
                db.SaveChanges();
            }

        }
    }
}
