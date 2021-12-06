using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Shared.DTO;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using FluentValidation.Validators;
using System.Text.RegularExpressions;
using scontracts.Shared.Enums;
using scontracts.Api.Mediator.Commands;
using App.Contratos.DAL.Enums;
using scontracts.Shared.Responses;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_ContratosRepository
    /// </summary>
    public class TB_ContratosRepository : Repository<TB_Contratos>, ITB_ContratosRepository
    {
        /// <summary>
        /// TB_ContratosRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_ContratosRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        /// <summary>
        /// ObtenerEstatusParaAbogado - Sirve para mostrar los estatus en la consulta principal correspondientes al perfil de abogado.
        /// </summary>
        /// <returns></returns>
        public List<EstatusDTO> ObtenerEstatusParaAbogado(int abogadoId)
        {
            return (from qry in consisContext.TB_ContratosRoutines.Where(o => o.ID_ResponsableJuridico == abogadoId)
                    join est in consisContext.Cat_EstatusRoutines on qry.ID_Estatus equals est.ID_Estatus
                    //group est by new { est.ID_Estatus, est.Estatus }
                    //into estgroup 

                    select new EstatusDTO
                    {
                        EstatusId = est.ID_Estatus,
                        Descripcion = est.Estatus
                    }

                    ).ToList();
        }

        public List<EstatusDTO> ObtenerEstatusAdmin(int userId)
        {
            return (from qry in consisContext.TB_ContratosRoutines.Where(o => o.ID_ResponsableJuridico == userId)
                    join est in consisContext.Cat_EstatusRoutines on qry.ID_Estatus equals est.ID_Estatus
                    //group est by new { est.ID_Estatus, est.Estatus }
                    //into estgroup 

                    select new EstatusDTO
                    {
                        EstatusId = est.ID_Estatus,
                        Descripcion = est.Estatus
                    }

                    ).ToList();
        }

        /// <summary>
        /// ObtenerEstatusParaSolicitante - Sirve para mostrar los estatus en la consulta principal correspondientes al perfil de abogado.
        /// </summary>
        /// <param name="solicitanteId"></param>
        /// <returns></returns>
        public List<EstatusDTO> ObtenerEstatusParaSolicitante(int solicitanteId)
        {
            return (from qry in consisContext.TB_ContratosRoutines.Where(o => o.ID_Solicitante == solicitanteId)
                    join est in consisContext.Cat_EstatusRoutines on qry.ID_Estatus equals est.ID_Estatus
                    //group est by new { est.ID_Estatus, est.Estatus }
                    //into estgroup 
           
                    select new EstatusDTO
                    {
                        EstatusId = est.ID_Estatus,
                        Descripcion = est.Estatus
                    }

                    ).ToList();

        }


        /// <summary>
        /// ObtenerEstatusParaSolicitante - Sirve para mostrar los estatus en la consulta principal correspondientes al perfil de solicitante.
        /// </summary>
        /// <returns></returns>
        public List<SolicitudesParaSolicitanteDTO> ObtenerSolicitudesParaSolicitante(int estatusId, int userId)
        {
            List<SolicitudesParaSolicitanteDTO> SolicitudesParaSolicitante = new List<SolicitudesParaSolicitanteDTO>();
            if (estatusId != (int)EstatusSolicitud.Borrador)
            {
                SolicitudesParaSolicitante = (from qry in consisContext.TB_ContratosRoutines.Where(o =>
                         o.ID_Estatus == estatusId && o.ID_Solicitante == userId)
                                              join unidad in consisContext.Cat_UnidadRoutines
                                                   on qry.ID_Unidad equals unidad.ID_Unidad
                                              join proveedor in consisContext.Cat_ProveedorRoutines
                                              on qry.ID_Proveedor equals proveedor.ID_Proveedor
                                              ///.Where(r => r.ID_Proveedor == qry.ID_Proveedor).DefaultIfEmpty()
                                              join documento in consisContext.Cat_TipoDocumentoRoutines
                                              on qry.ID_TipoDocumento equals documento.ID_TipoDocumento
                                              ///.Where(r => r.ID_TipoDocumento == qry.ID_TipoDocumento).DefaultIfEmpty()
                                              join estatus in consisContext.Cat_EstatusRoutines
                                                    on qry.ID_Estatus equals estatus.ID_Estatus
                                              join s in consisContext.Cat_UsuarioRoutines on qry.ID_Solicitante equals s.ID_Usuario
                                              from ur in consisContext.Cat_UsuarioRoutines
                                              .Where(r => r.ID_Usuario == qry.ID_ResponsableJuridico).DefaultIfEmpty()
                                              from contraparte in consisContext.Cat_TipoSolicitudRoutines.Where(r => r.IdTipoSolicitud == qry.IdTipoSolicitud).DefaultIfEmpty()
                                              select new SolicitudesParaSolicitanteDTO
                                              {

                                                  Folio = qry.Folio,
                                                  Id_Contrato = qry.ID_Contrato,
                                                  FechaUltimoMov = consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion != null ? consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion : null,
                                                  Contraparte = proveedor.Nombre.ToString().Trim(),
                                                  Id_ContratoPadre = qry.ID_ContratoPadre,
                                                  Id_FormatoLiberado = qry.ID_FormatoLiberado,
                                                  DetalleS = new DetalleParaSolicitanteDTO
                                                  {

                                                      Empresa = unidad.Nombre.ToString().Trim(),
                                                      TipoContraparte = contraparte.Descripcion,
                                                      Responsable = ur.Nombre,
                                                      Estatus = estatus.Estatus.ToString().Trim(),
                                                      FechaVencimiento = consisContext.TB_Contratos_SeguimientoRoutines.Where(r => r.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Seguimiento).FirstOrDefault().FechaVencimiento,
                                                      Solicitante = s.Nombre,
                                                      TipoDocumento = documento.Nombre.ToString().Trim(),
                                                      FechaParo = consisContext.TB_Historial_ParosRoutines.Where(x => x.IdContrato == qry.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault().FechaParo
                                                  }

                                              }).ToList();
            }
            else
            {
                SolicitudesParaSolicitante = (from qry in consisContext.TB_ContratosRoutines.Where(o =>
                     o.ID_Estatus == estatusId && o.ID_Solicitante == userId)
                                              from unidad in consisContext.Cat_UnidadRoutines
                                              .Where(r => r.ID_Unidad == qry.ID_Unidad).DefaultIfEmpty()
                                              from proveedor in consisContext.Cat_ProveedorRoutines
                                              .Where(r => r.ID_Proveedor == qry.ID_Proveedor).DefaultIfEmpty()
                                              from documento in consisContext.Cat_TipoDocumentoRoutines
                                              .Where(r => r.ID_TipoDocumento == qry.ID_TipoDocumento).DefaultIfEmpty()
                                              join estatus in consisContext.Cat_EstatusRoutines
                                              on qry.ID_Estatus equals estatus.ID_Estatus
                                              join s in consisContext.Cat_UsuarioRoutines on qry.ID_Solicitante equals s.ID_Usuario
                                              from ur in consisContext.Cat_UsuarioRoutines
                                              .Where(r => r.ID_Usuario == qry.ID_ResponsableJuridico).DefaultIfEmpty()
                                              from contraparte in consisContext.Cat_TipoSolicitudRoutines.Where(r => r.IdTipoSolicitud == qry.IdTipoSolicitud).DefaultIfEmpty()
                                              select new SolicitudesParaSolicitanteDTO
                                              {

                                                  Folio = qry.Folio,
                                                  Id_Contrato = qry.ID_Contrato,
                                                  FechaUltimoMov = consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion != null ? consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion: null,
                                                  Contraparte = string.IsNullOrEmpty(proveedor.Nombre) ? "" : proveedor.Nombre.ToString().Trim(),
                                                  Id_FormatoLiberado = qry.ID_FormatoLiberado,
                                                  DetalleS = new DetalleParaSolicitanteDTO
                                                  {

                                                      Empresa = string.IsNullOrEmpty(unidad.Nombre) ? "" : unidad.Nombre.ToString().Trim(),
                                                      TipoContraparte = string.IsNullOrEmpty(contraparte.Descripcion) ? "" : contraparte.Descripcion,
                                                      Responsable = string.IsNullOrEmpty(ur.Nombre) ? "" : ur.Nombre,
                                                      Estatus = string.IsNullOrEmpty(estatus.Estatus) ? "" : estatus.Estatus.ToString().Trim(),
                                                      FechaVencimiento = qry.FechaVencimientoContrato,
                                                      Solicitante = s.Nombre,
                                                      TipoDocumento = string.IsNullOrEmpty(documento.Nombre) ? "" : documento.Nombre.ToString().Trim(),
                                                      FechaParo = consisContext.TB_Historial_ParosRoutines.Where(x => x.IdContrato == qry.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault().FechaParo
                                                  }

                                              }).ToList();
            }

            return (from x in SolicitudesParaSolicitante orderby x.FechaUltimoMov descending select x).ToList();
        }


        /// <summary>
        /// ObtenerEstatusParaSolicitante - Sirve para mostrar los estatus en la consulta principal correspondientes al perfil de abogado.
        /// </summary>
        /// <returns></returns>
        public List<SolicitudesParaAbogadoDTO> ObtenerSolicitudesParaAbogado(int estatusId, int userId)
        {
            List<SolicitudesParaAbogadoDTO> SolicitudesParaAbogado = (from qry in consisContext.TB_ContratosRoutines.Where(o =>
             o.ID_Estatus == estatusId && o.ID_ResponsableJuridico == userId)
                    join unidad in consisContext.Cat_UnidadRoutines
                         on qry.ID_Unidad equals unidad.ID_Unidad
                    join proveedor in consisContext.Cat_ProveedorRoutines
                         on qry.ID_Proveedor equals proveedor.ID_Proveedor
                    join documento in consisContext.Cat_TipoDocumentoRoutines
                         on qry.ID_TipoDocumento equals documento.ID_TipoDocumento
                    join estatus in consisContext.Cat_EstatusRoutines
                          on qry.ID_Estatus equals estatus.ID_Estatus
                    join s in consisContext.Cat_UsuarioRoutines on qry.ID_Solicitante equals s.ID_Usuario
                    from ur in consisContext.Cat_UsuarioRoutines
                    .Where(r => r.ID_Usuario == qry.ID_ResponsableJuridico).DefaultIfEmpty()
                    from contraparte in consisContext.Cat_TipoSolicitudRoutines.Where(r => r.IdTipoSolicitud == qry.IdTipoSolicitud).DefaultIfEmpty()
                     select new SolicitudesParaAbogadoDTO
                     {
                        Folio = qry.Folio,
                        Id_Contrato = qry.ID_Contrato,
                        FechaUltimoMov =(qry.ID_Estatus == (int)EstatusSolicitud.PendienteDeAutorizacionA || qry.ID_Estatus == (int)EstatusSolicitud.PendienteDeAutorizacionB) ? qry.FechaSolicitud == null ? null:qry.FechaSolicitud : (qry.ID_Estatus == (int)EstatusSolicitud.ElaboracionRevisionJuridico) ? qry.FechaAceptacion == null ? null : qry.FechaAceptacion  : consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion == null ? null : (qry.ID_Estatus == (int)EstatusSolicitud.ElaboracionRevisionJuridico) ? qry.FechaAceptacion == null ? null : qry.FechaAceptacion : consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion,// qry.FechaEnvioFirma,
                        Contraparte = proveedor.Nombre.ToString().Trim(),
                        Id_ContratoPadre = qry.ID_ContratoPadre,
                        DetalleA = new DetalleParaAbogadoDTO
                        {
                            Empresa = unidad.Nombre.ToString().Trim(),
                            TipoContraparte = contraparte.Descripcion,
                            Responsable = ur.Nombre,
                            Estatus = estatus.Estatus.ToString().Trim(),
                            FechaVencimiento = consisContext.TB_Contratos_SeguimientoRoutines.Where(r => r.ID_Contrato == qry.ID_Contrato).OrderByDescending(x=>x.ID_Contrato_Seguimiento).FirstOrDefault().FechaVencimiento,
                            Solicitante = s.Nombre,
                            TipoDocumento = documento.Nombre.ToString().Trim(),
                            FechaParo = consisContext.TB_Historial_ParosRoutines.Where(x => x.IdContrato == qry.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault().FechaParo
                        }

                    }).ToList();


            return (from x in SolicitudesParaAbogado orderby x.FechaUltimoMov descending select x).ToList();
        }/// <summary>
        
        /// ObtenerEstatusParaSolicitante - Sirve para mostrar los estatus en la consulta principal correspondientes al perfil de abogado.
         /// </summary>
         /// <returns></returns>
        public List<SolicitudesParaAbogadoDTO> ObtenerSolicitudesAdmin(int estatusId, int userId)
        {
            List<SolicitudesParaAbogadoDTO> SolicitudesParaAbogado = (from qry in consisContext.TB_ContratosRoutines.Where(o =>
             o.ID_Estatus == estatusId && o.ID_ResponsableJuridico == userId)
                                                                      join unidad in consisContext.Cat_UnidadRoutines
                                                                           on qry.ID_Unidad equals unidad.ID_Unidad
                                                                      join proveedor in consisContext.Cat_ProveedorRoutines
                                                                           on qry.ID_Proveedor equals proveedor.ID_Proveedor
                                                                      join documento in consisContext.Cat_TipoDocumentoRoutines
                                                                           on qry.ID_TipoDocumento equals documento.ID_TipoDocumento
                                                                      join estatus in consisContext.Cat_EstatusRoutines
                                                                            on qry.ID_Estatus equals estatus.ID_Estatus
                                                                      join s in consisContext.Cat_UsuarioRoutines on qry.ID_Solicitante equals s.ID_Usuario
                                                                      from ur in consisContext.Cat_UsuarioRoutines
                                                                      .Where(r => r.ID_Usuario == qry.ID_ResponsableJuridico).DefaultIfEmpty()
                                                                      from contraparte in consisContext.Cat_TipoSolicitudRoutines.Where(r => r.IdTipoSolicitud == qry.IdTipoSolicitud).DefaultIfEmpty()
                                                                      select new SolicitudesParaAbogadoDTO
                                                                      {
                                                                          Folio = qry.Folio,
                                                                          Id_Contrato = qry.ID_Contrato,
                                                                          FechaUltimoMov = (qry.ID_Estatus == (int)EstatusSolicitud.PendienteDeAutorizacionA || qry.ID_Estatus == (int)EstatusSolicitud.PendienteDeAutorizacionB) ? qry.FechaSolicitud == null ? null : qry.FechaSolicitud : (qry.ID_Estatus == (int)EstatusSolicitud.ElaboracionRevisionJuridico) ? qry.FechaAceptacion == null ? null : qry.FechaAceptacion : consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion == null ? null : (qry.ID_Estatus == (int)EstatusSolicitud.ElaboracionRevisionJuridico) ? qry.FechaAceptacion == null ? null : qry.FechaAceptacion : consisContext.TB_Contratos_VersionesRoutines.Where(x => x.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Version).FirstOrDefault().FechaCreacion,// qry.FechaEnvioFirma,
                                                                          Contraparte = proveedor.Nombre.ToString().Trim(),
                                                                          Id_ContratoPadre = qry.ID_ContratoPadre,
                                                                          DetalleA = new DetalleParaAbogadoDTO
                                                                          {
                                                                              Empresa = unidad.Nombre.ToString().Trim(),
                                                                              TipoContraparte = contraparte.Descripcion,
                                                                              Responsable = ur.Nombre,
                                                                              Estatus = estatus.Estatus.ToString().Trim(),
                                                                              FechaVencimiento = consisContext.TB_Contratos_SeguimientoRoutines.Where(r => r.ID_Contrato == qry.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Seguimiento).FirstOrDefault().FechaVencimiento,
                                                                              Solicitante = s.Nombre,
                                                                              TipoDocumento = documento.Nombre.ToString().Trim(),
                                                                              FechaParo = consisContext.TB_Historial_ParosRoutines.Where(x => x.IdContrato == qry.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault().FechaParo
                                                                          }

                                                                      }).ToList();


            return (from x in SolicitudesParaAbogado orderby x.FechaUltimoMov descending select x).ToList();
        }

        /// <summary>
        /// ObtenerSolicitud - Sirve para mostrar los datos de la solicitud
        /// </summary>
        /// <returns></returns>
        public SolicitudDTo getsolicitud(long idContrato)
        {
            SolicitudDTo prueba = new SolicitudDTo();
             prueba = (from qry in consisContext.TB_ContratosRoutines.Where(o => o.ID_Contrato == idContrato)
                                       //join prioridad in consisContext.Cat_PrioridadRoutines
                                       //     on qry.ID_Prioridad equals prioridad.ID_Prioridad
                                   from prioridad in consisContext.Cat_PrioridadRoutines
                                                        .Where(r => r.ID_Prioridad == qry.ID_Prioridad).DefaultIfEmpty()
                                       //join idioma in consisContext.cat_IdiomaRoutines
                                       //     on qry.idIdioma equals idioma.idIdioma
                                   from idioma in consisContext.cat_IdiomaRoutines
                                                        .Where(r => r.idIdioma == qry.idIdioma).DefaultIfEmpty()
                                   from unidad in consisContext.Cat_UnidadRoutines
                                                        .Where(r => r.ID_Unidad == qry.ID_Unidad).DefaultIfEmpty()
                                   from proveedor in consisContext.Cat_ProveedorRoutines
                                                             .Where(r => r.ID_Proveedor == qry.ID_Proveedor).DefaultIfEmpty()
                                   from documento in consisContext.Cat_TipoDocumentoRoutines
                                                             .Where(r => r.ID_TipoDocumento == qry.ID_TipoDocumento).DefaultIfEmpty()
                                       //join responsable in consisContext.Cat_ResponsablesRoutines
                                       //     on qry.ID_Responsable equals responsable.ID_Responsable
                                   from responsable in consisContext.Cat_ResponsablesRoutines
                                                      .Where(r => r.ID_Responsable == qry.ID_Responsable).DefaultIfEmpty()
                                   from moneda in consisContext.Cat_TipoMonedaRoutines
                                         .Where(r => r.ID_Moneda == qry.ID_Moneda).DefaultIfEmpty()
                                   join unidadUsuario in consisContext.Cat_Unidad_UsuarioRoutines
                                        on qry.ID_UnidadUsuario equals unidadUsuario.ID_UnidadUsuario
                                   //join detalles in consisContext.TB_Contratos_DetalleRoutines
                                   //    on qry.ID_Contrato equals detalles.ID_Contrato
                                   from detalles in consisContext.TB_Contratos_DetalleRoutines
                                                  .Where(r => r.ID_Contrato == qry.ID_Contrato).DefaultIfEmpty()
                                   from solicitante in consisContext.Cat_UsuarioRoutines
                                        .Where(r => r.ID_Usuario == qry.ID_Solicitante)

                       select new SolicitudDTo
                       {
                           ID_Prioridad = qry.ID_Prioridad,
                           NombrePrioridad = string.IsNullOrEmpty(prioridad.Nombre) ? "" : prioridad.Nombre.ToString().Trim(),
                           idIdioma = idioma.idIdioma,
                           NombreIdioma = string.IsNullOrEmpty(idioma.Idioma) ? "" : idioma.Idioma.ToString().Trim(),
                           ElaboracionContrato = qry.ElaboracionContrato,
                           ID_TipoDocumento = documento.ID_TipoDocumento,
                           NombreDocumento = string.IsNullOrEmpty(documento.Nombre) ? "" : documento.Nombre.ToString().Trim(),
                           ID_Unidad = unidad.ID_Unidad,
                           NombreUnidad = string.IsNullOrEmpty(unidad.Nombre) ? "" : unidad.Nombre.ToString().Trim(),
                           ID_Proveedor = proveedor.ID_Proveedor,
                           Contraparte = string.IsNullOrEmpty(proveedor.Nombre) ? "" : proveedor.Nombre.ToString().Trim(),
                           ID_Responsable = responsable.ID_Responsable,
                           NombreResponsable = string.IsNullOrEmpty(responsable.Nombre) ? "" : responsable.Nombre.ToString().Trim(),
                           CargoResponsable = string.IsNullOrEmpty(responsable.Cargo) ? "" : responsable.Cargo.ToString().Trim(),
                           ID_UnidadUsuario = unidadUsuario.ID_UnidadUsuario,
                           TelefonoResponsable = string.IsNullOrEmpty(responsable.Telefono) ? "" : responsable.Telefono.ToString().Trim(),
                           UnidadResponsable = unidadUsuario.Nombre.ToString().Trim(),
                           ObjetoNegociacion = string.IsNullOrEmpty(detalles.ObjetoNegociacion) ? "" : detalles.ObjetoNegociacion.ToString().Trim(),
                           DescServiciosProductos = string.IsNullOrEmpty(detalles.DescServiciosProductos) ? "" : detalles.DescServiciosProductos.ToString().Trim(),
                           Contraprestacion = string.IsNullOrEmpty(detalles.Contraprestacion) ? "" : detalles.Contraprestacion.ToString().Trim(),
                           FormaPago = string.IsNullOrEmpty(detalles.FormaPago) ? "" : detalles.FormaPago.ToString().Trim(),
                           Vigencia = string.IsNullOrEmpty(detalles.Vigencia) ? "" : detalles.Vigencia.ToString().Trim(),
                           LugarFechaFirma = string.IsNullOrEmpty(detalles.LugarFechaFirma) ? "" : detalles.LugarFechaFirma.ToString().Trim(),
                           CondicionesEspeciales = string.IsNullOrEmpty(detalles.CondicionesEspeciales) ? "" : detalles.CondicionesEspeciales.ToString().Trim(),
                           FolioPadre = consisContext.TB_ContratosRoutines.Where(x => x.ID_Contrato == qry.ID_ContratoPadre).FirstOrDefault().Folio,
                           IDPais = qry.IDPais,
                           IdTipoSolicitud = qry.IdTipoSolicitud,
                           NombreSolicitante = solicitante.Nombre.ToString().Trim(),
                           CargoSolicitante = solicitante.Puesto.ToString().Trim(),
                           TelefonoSolicitante = solicitante.TelefonoExt.ToString().Trim(),
                           UnidadSolicitante = unidadUsuario.Nombre.ToString().Trim(),
                           TipoContrato = qry.ID_TipoContrato,
                           ID_ContratoPadre = qry.ID_ContratoPadre,
                           ID_Moneda = moneda.ID_Moneda,
                           Moneda = moneda.Nombre,
                           ID_FormatoLiberados = qry.ID_FormatoLiberado,
                           EnParoAbogado = qry.EnParoAbogado,
                           EnParoSolicitante = qry.EnParoSolicitante
                           
                       }).FirstOrDefault();


            return prueba;

        }
        /// <summary>
        /// ObtenerContratoDocumentacion - Sirve para mostrar la lista de documentos de un contrato
        /// </summary>
        /// <returns></returns>
        public List<TBContratosDocumentacionDTO> ObtenerContratoDocumentacion(long idContrato)
        {
            return (from qry in consisContext.TB_Contratos_DocumentacionRoutines.Where(o =>
             o.ID_Contrato == idContrato)
                   
                    select new TBContratosDocumentacionDTO
                    {
                        ID_Contrato = qry.ID_Contrato,
                        NombreArchivo = qry.NombreArchivo,
                        ContenttType = qry.ContenttType,
                        Extension = qry.Extension,
                        ID_Archivo = qry.ID_Archivo,
                        ID_Documentacion = qry.ID_Documentacion
                    }).ToList();
        }
        ///// <summary>
        ///// AcceptCover
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //public AcceptCoverSetResponse AcceptCover(AcceptCoverSetCommand command)
        //{
        //    AcceptCoverSetResponse res = new AcceptCoverSetResponse();


        //    TB_Contratos banderasActivas = (from qry in consisContext.TB_ContratosRoutines.Where(o => o.ID_Contrato == command.Id_Contrato)
        //                                select new TB_Contratos
        //                                {
        //                                    ID_Estatus = qry.ID_Estatus

        //                                }).FirstOrDefault();



        //    using (var context = new DataContext())
        //    {
        //        var entity = context.TB_ContratosRoutines.FirstOrDefault(item => item.ID_Contrato == command.Id_Contrato);
        //        if (entity != null)
        //        {
        //            // Answer for question #2

        //            // Make changes on entity
        //            entity.ID_Estatus = (int)EstatusSolicititante.PreparacionOriginalesParaFirma;

        //            // Update entity in DbSet
        //            context.TB_ContratosRoutines.Update(entity);

        //            // Save changes in database
        //            context.SaveChanges();
        //        }
        //    }
        //    //using (var unitofwork = new UnitOfWork(new DataContext()))
        //    //    {
        //    //        TB_Contratos cto = unitofwork.TB_ContratosRoutines.Single(o => o.ID_Contrato == command.Id_Contrato);
        //    //        cto.ID_Estatus = (int)EstatusSolicititante.PreparacionOriginalesParaFirma; ;
        //    //        unitofwork.TB_ContratosRoutines.Attach(cto);
        //    //        unitofwork.Commit();
        //    //        res.AutorizadoPorTodos = true;
        //    //    }

        //    return res;
        //}
        /// <summary>
        /// AcceptCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ManagementCommentaryResponse UpdateStatusContracts(ManagementCommentaryCommand command, bool blnAnexo, bool enviaComentario)
        {
            ManagementCommentaryResponse res = new ManagementCommentaryResponse();
            TB_Contratos EnParoSolicitante = (from qry in consisContext.TB_ContratosRoutines.Where(o => o.ID_Contrato == command.ID_Contrato)
                                              select new TB_Contratos
                                              {
                                                  EnParoSolicitante = qry.EnParoSolicitante

                                              }).FirstOrDefault();

            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                TB_Contratos cto = unitofwork.TB_ContratosRoutines.Single(o => o.ID_Contrato == command.ID_Contrato);

                #region Anexos
                if (command.Anexos || (command.EnviaSolicitante && blnAnexo)) 
                {
                    #region Contrato
                    if (cto.ID_Estatus == (int)EstatusSolicitud.EsperaDocumentacionInformacion || cto.ID_Estatus == (int)EstatusSolicitud.StandBy || cto.ID_Estatus == (int)EstatusSolicitud.EnEsperaDeReplica)
                    {
                        if (EnParoSolicitante != null)
                        {
                            if (command.EnParoSolicitante.Value)
                                cto.EnParoAbogado = false;
                            else
                                cto.EnParoAbogado = true;
                        }
                        else
                            cto.EnParoAbogado = true;
                    }
                    #endregion
                }
                #endregion

                #region Solititante 
                if (command.AutorizaSolicitante || (command.EnviaSolicitante && !blnAnexo))
                {
                    if (enviaComentario)
                    {
                        #region Contrato
                        if (cto.ID_Estatus == (int)EstatusSolicitud.EsperaDocumentacionInformacion || cto.ID_Estatus == (int)EstatusSolicitud.StandBy || cto.ID_Estatus == (int)EstatusSolicitud.EnEsperaDeReplica)
                        {
                            if (cto.EnParoSolicitante != null)
                            {
                                if (cto.EnParoSolicitante.Value)
                                    cto.EnParoAbogado = false;
                                else
                                    cto.EnParoAbogado = true;
                            }
                            else
                                cto.EnParoAbogado = true;
                        }
                        #endregion
                    }
                    else
                    {
                        cto.ID_Estatus = command.ID_Estatus;
                    }

                    if (command.StandBy)
                    {
                        cto.EnParoSolicitante = true;
                        cto.EnParoAbogado = false;
                    }
                    else
                    {
                        cto.DiasSegundaVuelta = null;
                    }

                    if (command.EnviaSolicitante)
                    {
                        cto.Vuelta = 2;
                        cto.DiasSegundaVuelta = null;
                    };

                }
                #endregion
                #region Abogado
                else if (command.AutorizaAbogado || command.EnviaAbogado)
                {

                    if (command.EnviaAbogado)
                    {
                        if (!string.IsNullOrEmpty(command.Comentarios.Trim()) && command.ListContratosDoc.Count == 0)
                        {
                            if (cto.ID_Estatus == (int)EstatusSolicitud.EsperaDocumentacionInformacion || cto.ID_Estatus == (int)EstatusSolicitud.StandBy || cto.ID_Estatus == (int)EstatusSolicitud.EnEsperaDeReplica)
                            {
                                cto.EnParoAbogado = false;
                            }
                        }

                        #region Adjuntar Contrato
                        if (command.ListContratosDoc.Count > 0)
                        {
                            #region Contrato
                            cto.ID_Estatus = command.ID_Estatus;
                            #endregion
                        }
                        #endregion
                    }
                    else if (cto.ID_Estatus == (int)EstatusSolicitud.PendienteDeAutorizacionB)
                    {
                        cto.Folio = command.Folio;
                        cto.ID_Estatus = command.ID_Estatus;
                        cto.FechaAceptacion = DateTime.Now;
                        cto.Vuelta = 1;
                        cto.ID_TipoContrato = command.ID_TipoContrato;
                        cto.ReqCaratula = command.RequiereCaratula;
                        cto.ID_Prioridad = command.ID_Prioridad;
                    }
                    else
                    {
                        cto.ID_Estatus = command.ID_Estatus;
                    }
                }
                #endregion
                #region Cambio de Estatus
                else if (command.ID_Estatus_Cambio == (int)EstatusSolicitud.Cancelado || command.ID_Estatus_Cambio == (int)EstatusSolicitud.Rechazado)
                {
                    cto.ID_Estatus = command.ID_Estatus;
                    cto.MotivoRechazoCancelacion = command.Comentarios;
                    cto.FechaRechazoCancelacion = DateTime.Now;
                    cto.ID_UsuarioRechazo = command.ID_UsuarioEnvio;
                }
                else if (command.ID_Estatus_Cambio == (int)EstatusSolicitud.EntregadoParaFirma || command.ID_Estatus_Cambio == (int)EstatusSolicitud.EntregadoPorCorreoParaFirma)
                {
                    cto.ID_Estatus = command.ID_Estatus;
                    cto.FechaEnvioFirma = DateTime.Now;
                }
                else if (!enviaComentario && !command.SegundaVuelta && !blnAnexo)
                {
                    cto.ID_Estatus = command.ID_Estatus;
                    if (command.ID_Estatus_Cambio != (int)EstatusSolicitud.Archivado)
                        if (command.ID_Estatus_Cambio != (int)EstatusSolicitud.Liberado)
                            cto.EnParoAbogado = command.EnParoAbogado;
                }

                if (command.SegundaVuelta)
                    cto.DiasSegundaVuelta = command.DiasSegundaVuelta;
                #endregion


                unitofwork.TB_ContratosRoutines.Attach(cto);
                unitofwork.Commit();
                return res;
            }
        }
        /// <summary>
        /// ObtenerContrato
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        public TB_Contratos ObtenerContrato(long ID_Contrato)
        {
            TB_Contratos c = new TB_Contratos();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                c = unitofwork.TB_ContratosRoutines.Find(x => x.ID_Contrato == ID_Contrato).FirstOrDefault();

            }
            return c;
        }


        /// <summary>
        /// ObtenerSolicitudesPadre - Sirve para obtener la lista de contratos que pueden ser seleccionados como contrato padre.
        /// </summary>
        /// <returns></returns>
        public List<SolicitudesPadreDTO> ObtenerSolicitudesPadre(int idEmpresa, int idContraparte, int idUnidadUsuario)
        {
            List<SolicitudesPadreDTO> SolicitudesPadre = (from qry in consisContext.TB_ContratosRoutines.Where(o =>                                                             
                                                            o.ID_Estatus != (int)EstatusSolicitud.Cancelado
                                                            && o.ID_Estatus != (int)EstatusSolicitud.Borrador
                                                            && o.ID_Estatus != (int)EstatusSolicitud.Eliminado
                                                            && o.ID_Estatus != (int)EstatusSolicitud.Rechazado
                                                            && o.ID_Unidad == idEmpresa
                                                            && o.ID_Proveedor == idContraparte
                                                          //&& o.ID_UnidadUsuario == idUnidadUsuario - SE REMOVIÓ POR SOLICITUD DEL USUARIO | RESTRICCIÓN DE UNIDAD DE NEGOCIO
                                                          )
                                                          from proveedor in consisContext.Cat_ProveedorRoutines
                                                            .Where(r => r.ID_Proveedor == qry.ID_Proveedor).DefaultIfEmpty()
                                                          from unidad in consisContext.Cat_UnidadRoutines
                                                            .Where(r => r.ID_Unidad == qry.ID_Unidad).DefaultIfEmpty()
                                                          from contraparte in consisContext.Cat_TipoSolicitudRoutines
                                                            .Where(r => r.IdTipoSolicitud == qry.IdTipoSolicitud).DefaultIfEmpty()
                                                          from ur in consisContext.Cat_UsuarioRoutines
                                                            .Where(r => r.ID_Usuario == qry.ID_ResponsableJuridico).DefaultIfEmpty()
                                                          join estatus in consisContext.Cat_EstatusRoutines
                                                            on qry.ID_Estatus equals estatus.ID_Estatus
                                                          select new SolicitudesPadreDTO
                                                          {
                                                              IdContrato = qry.ID_Contrato,
                                                              Folio = qry.Folio,
                                                              FechaSolicitud = (DateTime)qry.FechaSolicitud,
                                                              Contraparte = proveedor.Nombre,
                                                              Empresa = unidad.Nombre,
                                                              DetalleSolicitudPadre = new DetalleSolicitudPadreDTO
                                                              {
                                                                  TipoContraparte = contraparte.Descripcion,
                                                                  Responsable = ur.Nombre,
                                                                  Estatus = estatus.Estatus
                                                              }
                                                          }).ToList();




            return (from x in SolicitudesPadre orderby x.FechaSolicitud descending select x).ToList();
        }

        /// <summary>
        /// ObtenerContratosRelacionados - Lista de contratos relacionados.
        /// </summary>
        /// <returns></returns>
        public List<SolicitudesPadreDTO> ObtenerContratosRelacionados(long idContratoPadre)
        {
            List<SolicitudesPadreDTO> ContratosRelacionados = (from qry in consisContext.TB_ContratosRoutines.Where(o =>
                                                            o.ID_ContratoPadre == idContratoPadre)
                                                               from proveedor in consisContext.Cat_ProveedorRoutines
                                                                 .Where(r => r.ID_Proveedor == qry.ID_Proveedor).DefaultIfEmpty()
                                                               from unidad in consisContext.Cat_UnidadRoutines
                                                                 .Where(r => r.ID_Unidad == qry.ID_Unidad).DefaultIfEmpty()
                                                               from contraparte in consisContext.Cat_TipoSolicitudRoutines
                                                                 .Where(r => r.IdTipoSolicitud == qry.IdTipoSolicitud).DefaultIfEmpty()
                                                               from responsable in consisContext.Cat_ResponsablesRoutines
                                                                 .Where(r => r.ID_Responsable == qry.ID_Responsable).DefaultIfEmpty()
                                                               join estatus in consisContext.Cat_EstatusRoutines
                                                                 on qry.ID_Estatus equals estatus.ID_Estatus
                                                               select new SolicitudesPadreDTO
                                                               {
                                                                   IdContrato = qry.ID_Contrato,
                                                                   Folio = qry.Folio,
                                                                   FechaSolicitud = (DateTime)qry.FechaSolicitud,
                                                                   Contraparte = proveedor.Nombre,
                                                                   Empresa = unidad.Nombre,
                                                                   DetalleSolicitudPadre = new DetalleSolicitudPadreDTO
                                                                   {
                                                                       TipoContraparte = contraparte.Descripcion,
                                                                       Responsable = responsable.Nombre,
                                                                       Estatus = estatus.Estatus
                                                                   }
                                                               }).ToList();




            return (from x in ContratosRelacionados orderby x.FechaSolicitud descending select x).ToList();
        }

        /// <summary>
        /// ObtenerContratosRelacionados - Lista de contratos relacionados.
        /// </summary>
        /// <returns></returns>
        public SolicitudDTo ObtenerContratoPadre(long idContratoPadre)
        {
            SolicitudDTo ContratoPadre = (from qry in consisContext.TB_ContratosRoutines.Where(o =>
                                                            o.ID_Contrato == idContratoPadre)
                                                               from proveedor in consisContext.Cat_ProveedorRoutines
                                                                 .Where(r => r.ID_Proveedor == qry.ID_Proveedor).DefaultIfEmpty()
                                                               from unidad in consisContext.Cat_UnidadRoutines
                                                                 .Where(r => r.ID_Unidad == qry.ID_Unidad).DefaultIfEmpty()
                                                               from contrato in consisContext.Cat_TipoContratoRoutines
                                                                 .Where(r => r.ID_TipoContrato == qry.ID_TipoContrato).DefaultIfEmpty()
                                                               from ur in consisContext.Cat_UsuarioRoutines
                                                                 .Where(r => r.ID_Usuario == qry.ID_ResponsableJuridico).DefaultIfEmpty()
                                                               join documento in consisContext.Cat_TipoDocumentoRoutines
                                                                on qry.ID_TipoDocumento equals documento.ID_TipoDocumento
                                                               join estatus in consisContext.Cat_EstatusRoutines
                                                                on qry.ID_Estatus equals estatus.ID_Estatus
                                          select new SolicitudDTo
                                                               {
                                                                   FolioPadre = qry.Folio,
                                                                   FechaSolicitud = (DateTime)qry.FechaSolicitud,
                                                                   NombreDocumento = documento.Nombre,
                                                                   Contraparte = proveedor.Nombre,
                                                                   Estatus = estatus.Estatus
                                                }).FirstOrDefault();




            return ContratoPadre;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="EstatusSolicitud"></param>
        public void SaveEstatusContrato(long ID_Contrato, int EstatusSolicitud)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                contrato.ID_Estatus = EstatusSolicitud;
                db.Entry(contrato).CurrentValues.SetValues(contrato);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="ID_Pais"></param>
        /// <param name="IdTipoSolicitud"></param>
        public void ObtenerPaisTipoSolicitud(long ID_Contrato, ref int? ID_Pais, ref int? IdTipoSolicitud)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                ID_Pais = contrato.IDPais;
                IdTipoSolicitud = contrato.IdTipoSolicitud;
            }
        }
        /// <summary>
        /// SaveEstatusContratoCancelado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="EstatusSolicitud"></param>
        /// <param name="motivo"></param>
        /// <param name="id_usuario_envio"></param>
        public void SaveEstatusContratoCancelado(long ID_Contrato, int EstatusSolicitud, string motivo, int id_usuario_envio)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                contrato.ID_Estatus = EstatusSolicitud;
                contrato.MotivoRechazoCancelacion = motivo;
                contrato.FechaRechazoCancelacion = DateTime.Now;
                contrato.ID_UsuarioRechazo = id_usuario_envio;
                db.Entry(contrato).CurrentValues.SetValues(contrato);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// SaveEstatusComentarioAbogado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        public void SaveEstatusComentarioAbogado(long ID_Contrato)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);

                if (contrato.ID_Estatus == (int)EstatusSolicitud.EsperaDocumentacionInformacion || contrato.ID_Estatus == (int)EstatusSolicitud.StandBy || contrato.ID_Estatus == (int)EstatusSolicitud.EnEsperaDeReplica)
                {
                    #region Contrato
                    contrato.EnParoAbogado = false;
                    db.Entry(contrato).CurrentValues.SetValues(contrato);
                    db.SaveChanges();
                    #endregion
                }
            }
        }
        /// <summary>
        /// SaveContratoParoSolicitante
        /// </summary>
        /// <param name="ID_Contrato"></param>
        public void SaveReactivarContratoSolicitante(long ID_Contrato)
        {
            using (var db = new DataContext())
            {
                //var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);

                TB_Contratos contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                TB_Historial_Paros hp = db.TB_Historial_ParosRoutines.Where(x => x.IdContrato == contrato.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault();

                #region Contrato
                contrato.ID_Estatus = (int)hp.UltimoEstatus;
                contrato.EnParoSolicitante = null;

                db.Entry(contrato).CurrentValues.SetValues(contrato);
                db.SaveChanges();
                #endregion
            }
        }
    }
}
                           
