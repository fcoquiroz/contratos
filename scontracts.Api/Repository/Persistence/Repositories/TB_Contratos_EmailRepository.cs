using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Shared.Responses;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Enums;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_Contratos_EmailRepository
    /// </summary>
    public class TB_Contratos_EmailRepository : Repository<TB_Contratos_Email>, ITB_Contratos_EmailRepository
    {
        /// <summary>
        /// TB_Contratos_EmailRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Contratos_EmailRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="ID_Correo"></param>
        /// <param name="Asunto"></param>
        /// <param name="Comentarios"></param>
        /// <param name="EsSolicitante"></param>
        /// <returns></returns>
        public ManagementCommentaryResponse Save(long ID_Contrato, int ID_Correo, string Asunto, string Comentarios, bool EsSolicitante)
        {

            ManagementCommentaryResponse res = new ManagementCommentaryResponse();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                int? idUsuario = 0;
                var contrato = unitofwork.TB_ContratosRoutines.Find(c => c.ID_Contrato == ID_Contrato).ToList().FirstOrDefault();
                idUsuario = contrato.ID_ResponsableJuridico;
                if (!EsSolicitante)
                    idUsuario = contrato.ID_Solicitante;
                #region Contrato Email

                var db = new DataContext();
                string fechavencimiento = string.Empty;
                if (contrato.ID_Estatus != 1300)
                {
                   fechavencimiento = db.TB_Contratos_SeguimientoRoutines.Where(x => x.ID_Contrato == contrato.ID_Contrato).Min(x => x.FechaVencimiento).ToString("dd/MM/yyyy");
                }
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = ID_Contrato,
                    ID_Correo = ID_Correo,
                    Asunto = string.Format("{0}:{1}", Asunto, contrato.Folio),
                    Body = unitofwork.Cfg_CorreosRoutines.Find(o => o.ID_Correo == ID_Correo).Select(o => o.Correo).FirstOrDefault()
                    .Replace("#FSolicitud#", contrato.FechaSolicitud.ToString())
                    .Replace("#Prioridad#", unitofwork.Cat_PrioridadRoutines.Find(o => o.ID_Prioridad == contrato.ID_Prioridad).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#Folio#", contrato.Folio)
                    .Replace("#Empresa#", unitofwork.Cat_UnidadRoutines.Find(o => o.ID_Unidad == contrato.ID_Unidad).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#Contraparte#", unitofwork.Cat_ProveedorRoutines.Find(o => o.ID_Proveedor == contrato.ID_Proveedor).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#ResponsableJuridico#", unitofwork.Cat_UsuarioRoutines.Find(u => u.ID_Usuario == contrato.ID_ResponsableJuridico).Select(o => o.Nombre).FirstOrDefault())
                     .Replace("#FVencimiento#", fechavencimiento)
                    .Replace("#Comentarios#", (string.IsNullOrEmpty(Comentarios) ? string.Empty : Comentarios.Trim())
                    .Replace("#Anexo#", string.Empty)),
                    Destinatarios = unitofwork.Cat_UsuarioRoutines.Find(o => o.ID_Usuario == idUsuario).Select(o => o.Correo).FirstOrDefault(),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };
                if (!Validate(ce))
                {
                    unitofwork.TB_Contratos_EmailRoutines.Add(ce);
                    unitofwork.Commit();
                }

                #endregion
            }

            return res;
        }
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public bool Validate(TB_Contratos_Email ce)
        {
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                var cm = unitofwork.TB_Contratos_EmailRoutines.Find(x => x.ID_Contrato == ce.ID_Contrato &&
                                                                x.ID_Correo == ce.ID_Correo &&
                                                                x.Enviado != true).OrderByDescending(x => x.ID_Contrato_Email).FirstOrDefault();

                if (cm != null)
                    return true;
                else
                    return false;

            }
        }
        /// <summary>
        /// SaveEmailAcceptCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool SaveEmailAcceptCover(AcceptCoverSetCommand command)
        {
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                TB_Contratos_Email data = new TB_Contratos_Email();
                TB_Contratos dataContract = new TB_Contratos();
                dataContract = unitofwork.TB_ContratosRoutines.Find(x => x.ID_Contrato == command.Id_Contrato).FirstOrDefault();

                
                string nombreAut = command.EsExtra == 1 ?
                    unitofwork.Cat_Autorizadores_extraRoutines.Find(x => x.Id_Autorizador_extra == command.ID_Autorizador).FirstOrDefault().Nombre :
                    unitofwork.Cat_AutorizadoresRoutines.Find(x => x.Id_Autorizador == command.ID_Autorizador).FirstOrDefault().Nombre;


                data.ID_Contrato = command.Id_Contrato;
                data.ID_Correo = 44;
                data.Asunto = string.Format("Contrato Autorizado Folio: {0}", dataContract.Folio);
                data.Destinatarios = unitofwork.Cat_UsuarioRoutines.Find(x => x.ID_Usuario == dataContract.ID_Solicitante).FirstOrDefault().Correo + "," 
                    + unitofwork.Cat_UsuarioRoutines.Find(x => x.ID_Usuario == dataContract.ID_ResponsableJuridico).FirstOrDefault().Correo;

                data.Body = unitofwork.Cfg_CorreosRoutines.Find(x => x.ID_Correo == 44).FirstOrDefault().Correo
                    .Replace("#Folio#", dataContract.Folio)
                    .Replace("#Empresa#", unitofwork.Cat_UnidadRoutines.Find(x => x.ID_Unidad == dataContract.ID_Unidad).FirstOrDefault().Nombre)
                    .Replace("#Contraparte#", unitofwork.Cat_ProveedorRoutines.Find(x => x.ID_Proveedor == dataContract.ID_Proveedor).FirstOrDefault().Nombre)
                    .Replace("#NombreAutorizador#", nombreAut);

                data.FechaGeneroCorreo = DateTime.Now;
                data.Enviado = false;

                unitofwork.TB_Contratos_EmailRoutines.Add(data);
                unitofwork.Commit();
            }

            return true;
        }
        /// <summary>
        /// SaveEmailRejectCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool SaveEmailRejectCover(RejectCoverSetCommand command)
        {
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                TB_Contratos_Email data = new TB_Contratos_Email();
                TB_Contratos dataContract = new TB_Contratos();
                dataContract = unitofwork.TB_ContratosRoutines.Find(x => x.ID_Contrato == command.Id_Contrato).FirstOrDefault();

                string nombreAut = command.EsExtra == 1 ?
                    unitofwork.Cat_Autorizadores_extraRoutines.Find(x => x.Id_Autorizador_extra == command.ID_Autorizador).FirstOrDefault().Nombre :
                    unitofwork.Cat_AutorizadoresRoutines.Find(x => x.Id_Autorizador == command.ID_Autorizador).FirstOrDefault().Nombre;

                string site = unitofwork.TB_ParametrosRoutines.Find(x => x.ID_Parametro == 14).FirstOrDefault().Valor;
                data.ID_Contrato = command.Id_Contrato;
                data.ID_Correo = 45;
                data.Asunto = string.Format("Contrato Rechazado Folio: {0}", dataContract.Folio);
                data.Destinatarios = unitofwork.Cat_UsuarioRoutines.Find(x => x.ID_Usuario == dataContract.ID_Solicitante).FirstOrDefault().Correo;
                data.Body = unitofwork.Cfg_CorreosRoutines.Find(x => x.ID_Correo == 45).FirstOrDefault().Correo
                    .Replace("#Folio#", dataContract.Folio)
                    .Replace("#Empresa#", unitofwork.Cat_UnidadRoutines.Find(x => x.ID_Unidad == dataContract.ID_Unidad).FirstOrDefault().Nombre)
                    .Replace("#Contraparte#", unitofwork.Cat_ProveedorRoutines.Find(x => x.ID_Proveedor == dataContract.ID_Proveedor).FirstOrDefault().Nombre)
                    .Replace("#NombreAutorizador#", nombreAut)
                    .Replace("#Motivo#", command.Motivo)
                    .Replace("#UrlS#", site);

                data.FechaGeneroCorreo = DateTime.Now;
                data.Enviado = false;

                unitofwork.TB_Contratos_EmailRoutines.Add(data);
                unitofwork.Commit();
            }

            return true;
        }
        /// <summary>
        /// SaveContratoFirma
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="ID_Correo"></param>
        /// <param name="Asunto"></param>
        /// <param name="Comentarios"></param>
        /// <param name="EsSolicitante"></param>
        /// <param name="listContratosDoc"></param>
        /// <returns></returns>
        public ManagementCommentaryResponse SaveContratoFirma(long ID_Contrato, int ID_Correo, string Asunto, string Comentarios, bool EsSolicitante, List<TBContratosDocumentacionDTO> listContratosDoc)
        {

            ManagementCommentaryResponse res = new ManagementCommentaryResponse();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                int? idUsuario = 0;
                var contrato = unitofwork.TB_ContratosRoutines.Find(c => c.ID_Contrato == ID_Contrato).ToList().FirstOrDefault();
                idUsuario = contrato.ID_Solicitante;

                #region Contrato Email
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = ID_Contrato,
                    ID_Correo = ID_Correo,
                    Asunto = string.Format("{0}:{1}", Asunto, contrato.Folio),
                    Body = unitofwork.Cfg_CorreosRoutines.Find(o => o.ID_Correo == ID_Correo).Select(o => o.Correo).FirstOrDefault()
                    .Replace("#Folio#", contrato.Folio)
                    .Replace("#Empresa#", unitofwork.Cat_UnidadRoutines.Find(o => o.ID_Unidad == contrato.ID_Unidad).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#Contraparte#", unitofwork.Cat_ProveedorRoutines.Find(o => o.ID_Proveedor == contrato.ID_Proveedor).Select(o => o.Nombre).FirstOrDefault()),
                    Attachment = string.Format(@"{0}\{1}", listContratosDoc[0].RutaDocumentos, listContratosDoc[0].NombreArchivo),
                    Destinatarios = unitofwork.Cat_UsuarioRoutines.Find(o => o.ID_Usuario == idUsuario).Select(o => o.Correo).FirstOrDefault(),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };
                if (!Validate(ce))
                {
                    unitofwork.TB_Contratos_EmailRoutines.Add(ce);
                    unitofwork.Commit();
                }

                #endregion
            }

            return res;
        }
        /// <summary>
        /// SaveContratoCaratula
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="BuscarAutorizadoresPorContrato"></param>
        public void SaveContratoCaratula(long ID_Contrato, List<BuscarAutorizadoresPorContratoDTO> BuscarAutorizadoresPorContrato)
        {
            using (var db = new DataContext())
            {

                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                //string rutaDocumentos = string.Format("{0}{1}", db.TB_Parametros.Find(16).Valor,contrato.ID_Contrato);
                string rutaContrato = string.Format("{0}{1}", db.TB_ParametrosRoutines.Find(2).Valor, contrato.ID_Contrato);
                //string fileName = "CaratulaValidacion_" + contrato.ID_Contrato + ".pdf";

                var cv = db.TB_Contratos_VersionesRoutines.Where(m => m.ID_Contrato == contrato.ID_Contrato && m.NombreContrato != null
                && (m.ID_TipoAccion != (int)TipoAccion.SolicitanteEnviaCaratula && m.ID_TipoAccion != (int)TipoAccion.AnexosPorSolicitante && m.ID_TipoAccion != (int)TipoAccion.AbogadoCambiaCaratulaValidacion))
                    .OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault();

                var cvCaratula = db.TB_Contratos_VersionesRoutines.Where(m => m.ID_Contrato == contrato.ID_Contrato && m.NombreContrato != null
                && (m.ID_TipoAccion == (int)TipoAccion.SolicitanteEnviaCaratula || m.ID_TipoAccion == (int)TipoAccion.AbogadoCambiaCaratulaValidacion)).OrderByDescending(m => m.ID_Contrato_Version).FirstOrDefault();

                var Attachment = string.Format(@"{0}\{1}", rutaContrato, cv.NombreContrato);
                var AttachmentCaratula = string.Format(@"{0}\{1}", rutaContrato, cvCaratula.NombreContrato);
                var datosAutorizadores = BuscarAutorizadoresPorContrato;
                var baseURLAceptar = db.TB_ParametrosRoutines.Find(18).Valor; //url para autorizar
                var baseURLRechazo = db.TB_ParametrosRoutines.Find(19).Valor; //url para rechazar
                string urlAcepar = "";
                string urlRechazar = "";

                var vuelta = db.TB_Autorizadores_AutRoutines.Where(x => x.Id_Contrato == contrato.ID_Contrato).OrderByDescending(x => x.Vuelta).FirstOrDefault();

                var consultaN = (from A in db.TB_ContratosRoutines
                                 join U in db.Cat_UnidadRoutines on A.ID_Unidad equals U.ID_Unidad
                                 join C in db.Cat_ProveedorRoutines on A.ID_Proveedor equals C.ID_Proveedor
                                 where A.ID_Contrato == ID_Contrato
                                 select new
                                 {
                                     ID_Contrato = A.ID_Contrato,
                                     Empresa = U.Nombre,
                                     Contraparte = C.Nombre
                                 }).FirstOrDefault();
                foreach (var itemAuto in datosAutorizadores)
                {
                    urlAcepar = baseURLAceptar + itemAuto.Id_Autorizador + "&B=" + ID_Contrato + "&C=" + itemAuto.idUsuario + "&D=" + itemAuto.Extra + "&E=" + vuelta.Vuelta;
                    urlRechazar = baseURLRechazo + itemAuto.Id_Autorizador + "&B=" + ID_Contrato + "&C=" + itemAuto.idUsuario + "&D=" + itemAuto.Extra + "&E=" + vuelta.Vuelta;
                    var ce = new TB_Contratos_Email
                    {
                        ID_Contrato = contrato.ID_Contrato,
                        ID_Correo = 39,
                        Asunto = "El Contrato ha ingresado al proceso de autorización",
                        Destinatarios = itemAuto.Correo,
                        Body = db.Cfg_CorreosRoutines.Find(41).Correo
                        .Replace("#Contrato#", contrato.Folio)
                        .Replace("#empresa#", consultaN.Empresa)
                        .Replace("#contraparte#", consultaN.Contraparte)
                        .Replace("#Url#", urlAcepar)
                        .Replace("#Url2#", urlRechazar),
                        Attachment = Attachment + ";" + AttachmentCaratula,
                        FechaGeneroCorreo = DateTime.Now,
                        Enviado = false
                    };

                    db.TB_Contratos_EmailRoutines.Add(ce);

                    db.SaveChanges();
                }

            }
        }
        /// <summary>
        /// SaveEmailRechazo
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="Comentarios"></param>

        public void SaveEmailRechazo(long ID_Contrato, string Comentarios)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_Correo = 42,
                    Asunto = string.Format("Contrato Rechazado Folio: {0}", contrato.Folio),
                    Destinatarios = db.Cat_UsuarioRoutines.Find(contrato.ID_Solicitante).Correo,
                    Body = db.Cfg_CorreosRoutines.Find(40).Correo
                    .Replace("#Contrato#", contrato.Folio)
        .           Replace("#Comentarios#", Comentarios),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };
                if (!Validate(ce))
                {
                    db.TB_Contratos_EmailRoutines.Add(ce);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// SaveEmailEnvioCaratula
        /// </summary>
        /// <param name="ID_Contrato"></param>
        public void SaveEmailEnvioCaratula(long ID_Contrato)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                #region Mail
                var consultaN = (from A in db.TB_ContratosRoutines
                                 join U in db.Cat_UnidadRoutines on A.ID_Unidad equals U.ID_Unidad
                                 join C in db.Cat_ProveedorRoutines on A.ID_Proveedor equals C.ID_Proveedor
                                 where A.ID_Contrato == contrato.ID_Contrato
                                 select new
                                 {
                                     Folio = A.Folio,
                                     Empresa = U.Nombre,
                                     Contraparte = C.Nombre
                                 }).FirstOrDefault();
                var urlSitio = db.TB_ParametrosRoutines.Find(14).Valor;
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_Correo = 43,
                    Asunto = "Proceso de carátula de validación",
                    Destinatarios = db.Cat_UsuarioRoutines.Find(contrato.ID_Solicitante).Correo,
                    Body = db.Cfg_CorreosRoutines.Find(43).Correo
                    .Replace("#Contrato#", consultaN.Folio)
                    .Replace("#empresa#", consultaN.Empresa)
                    .Replace("#contraparte#", consultaN.Contraparte)
                    .Replace("#urlSItio#", urlSitio),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };
                
                #endregion
                if (!Validate(ce))
                {
                    db.TB_Contratos_EmailRoutines.Add(ce);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// SaveEmailAutLiberado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        public void SaveEmailAutLiberado(long ID_Contrato)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                var consultaN = (from A in db.TB_ContratosRoutines
                                 join U in db.Cat_UnidadRoutines on A.ID_Unidad equals U.ID_Unidad
                                 join C in db.Cat_ProveedorRoutines on A.ID_Proveedor equals C.ID_Proveedor
                                 where A.ID_Contrato == contrato.ID_Contrato
                                 select new
                                 {
                                     Folio = A.Folio,
                                     Empresa = U.Nombre,
                                     Contraparte = C.Nombre
                                 }).FirstOrDefault();
                var urlSitio = db.TB_ParametrosRoutines.Find(14).Valor;
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_Correo = 43,
                    Asunto = "Proceso de carátula de validación",
                    Destinatarios = db.Cat_UsuarioRoutines.Find(contrato.ID_Solicitante).Correo,
                    Body = db.Cfg_CorreosRoutines.Find(43).Correo
                    .Replace("#Contrato#", consultaN.Folio)
                    .Replace("#empresa#", consultaN.Empresa)
                    .Replace("#contraparte#", consultaN.Contraparte)
                    .Replace("#urlSItio#", urlSitio),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };
                if (!Validate(ce))
                {
                    db.TB_Contratos_EmailRoutines.Add(ce);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// SaveEmailAutorizar
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="ID_Correo"></param>
        /// <param name="Asunto"></param>
        /// <param name="Comentarios"></param>
        /// <param name="EsSolicitante"></param>
        /// <param name="Id_Prioridad"></param>
        /// <returns></returns>
        public ManagementCommentaryResponse SaveEmailAutorizar(long ID_Contrato, int ID_Correo, string Asunto, string Comentarios, bool EsSolicitante, int Id_Prioridad)
        {

            ManagementCommentaryResponse res = new ManagementCommentaryResponse();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                int? idUsuario = 0;
                var contrato = unitofwork.TB_ContratosRoutines.Find(c => c.ID_Contrato == ID_Contrato).ToList().FirstOrDefault();
                idUsuario = contrato.ID_ResponsableJuridico;
                if (!EsSolicitante)
                    idUsuario = contrato.ID_Solicitante;
                var db = new DataContext();

                string fechavencimiento = db.TB_Contratos_SeguimientoRoutines.Where(x => x.ID_Contrato == contrato.ID_Contrato).Min(x => x.FechaVencimiento).ToString("dd/MM/yyyy");
                #region Contrato Email
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = ID_Contrato,
                    ID_Correo = ID_Correo,
                    Asunto = Asunto,
                    Body = unitofwork.Cfg_CorreosRoutines.Find(o => o.ID_Correo == ID_Correo).Select(o => o.Correo).FirstOrDefault()
                    .Replace("#FSolicitud#", contrato.FechaSolicitud.ToString())
                    .Replace("#Prioridad#", unitofwork.Cat_PrioridadRoutines.Find(o => o.ID_Prioridad == contrato.ID_Prioridad).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#Folio#", contrato.Folio)
                    .Replace("#Empresa#", unitofwork.Cat_UnidadRoutines.Find(o => o.ID_Unidad == contrato.ID_Unidad).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#Contraparte#", unitofwork.Cat_ProveedorRoutines.Find(o => o.ID_Proveedor == contrato.ID_Proveedor).Select(o => o.Nombre).FirstOrDefault())
                    .Replace("#ResponsableJuridico#", unitofwork.Cat_UsuarioRoutines.Find(u => u.ID_Usuario == contrato.ID_ResponsableJuridico).Select(o => o.Nombre).FirstOrDefault())
                     .Replace("#FVencimiento#", fechavencimiento)
                     .Replace("#Anexo#", (Id_Prioridad == contrato.ID_Prioridad) ? string.Empty : unitofwork.Cfg_CorreosRoutines.Find(o => o.ID_Correo == 4).Select(o => o.Correo).FirstOrDefault()),
                    Destinatarios = unitofwork.Cat_UsuarioRoutines.Find(o => o.ID_Usuario == idUsuario).Select(o => o.Correo).FirstOrDefault(),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };
                if (!Validate(ce))
                {
                    unitofwork.TB_Contratos_EmailRoutines.Add(ce);
                    unitofwork.Commit();
                }

                #endregion
            }

            return res;
        }
        /// <summary>
        /// SaveEmailContratoCancelado
        /// </summary>
        /// <param name="command"></param>
        public void SaveEmailContratoCancelado(ManagementCommentaryCommand command)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(command.ID_Contrato);
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_Correo = 12,
                    Asunto = string.Format("Contrato Cancelado Folio: {0}", contrato.Folio),
                    Destinatarios = db.Cat_UsuarioRoutines.Find(contrato.ID_Solicitante).Correo + GetCorreosSupervisoresContrato(db, contrato.ID_Contrato),
                    Body = db.Cfg_CorreosRoutines.Find(12).Correo
                            .Replace("#Folio#", contrato.Folio)
                            .Replace("#Empresa#", db.Cat_UnidadRoutines.Find(contrato.ID_Unidad).Nombre)
                            .Replace("#Contraparte#", db.Cat_ProveedorRoutines.Find(contrato.ID_Proveedor).Nombre)
                            .Replace("#Comentarios#", command.Comentarios),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false,
                    Attachment = string.Format(@"{0}\{1}", command.ListContratosDoc[0].RutaDocumentos, command.ListContratosDoc[0].NombreArchivo)
                };
                if (!Validate(ce))
                {
                    db.TB_Contratos_EmailRoutines.Add(ce);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// GetCorreosSupervisoresContrato
        /// </summary>
        /// <param name="db"></param>
        /// <param name="IdContrato"></param>
        /// <returns></returns>
        public string GetCorreosSupervisoresContrato(DataContext db, long IdContrato)
        {
            var destinatarios = "";
            try
            {
                var emailsSupervisores = db.TB_Email_Supervisor_ContratoRoutines.Where(x => x.Activo == true && x.ID_Contrato == IdContrato);
                foreach (var t in emailsSupervisores)
                {
                    destinatarios += "," + t.Email;
                }
                return destinatarios;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        /// <summary>
        /// SaveEmailComentarioAbogado
        /// </summary>
        /// <param name="command"></param>
        public void SaveEmailComentarioAbogado(ManagementCommentaryCommand command)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(command.ID_Contrato);
                var ce = new TB_Contratos_Email
                {
                    ID_Contrato = contrato.ID_Contrato,
                    ID_Correo = 24,
                    Asunto = string.Format("Comentarios Folio: {0}", contrato.Folio),
                    Destinatarios = db.Cat_UsuarioRoutines.Find(contrato.ID_Solicitante).Correo,
                    Body = db.Cfg_CorreosRoutines.Find(24).Correo
                            .Replace("#Folio#", contrato.Folio)
                            .Replace("#Empresa#", db.Cat_UnidadRoutines.Find(contrato.ID_Unidad).Nombre)
                            .Replace("#Contraparte#", db.Cat_ProveedorRoutines.Find(contrato.ID_Proveedor).Nombre)
                            .Replace("#Comentarios#", command.Comentarios.Trim()),
                    FechaGeneroCorreo = DateTime.Now,
                    Enviado = false
                };

                if (!Validate(ce))
                {
                    db.TB_Contratos_EmailRoutines.Add(ce);
                    db.SaveChanges();
                }
            }
        }

    }
}
