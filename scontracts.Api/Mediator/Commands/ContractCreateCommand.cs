using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using scontracts.Shared.Requests;
using Repository.Core.Domain;
using scontracts.Shared.DTO;

namespace scontracts.Api.Mediator.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class ContractCreateCommand : ContractCreateRequest, IRequest<ResponseT<ContractCreateResponse>>
    {
        /// <summary>
        /// ContractCreateCommand
        /// 
        /// </summary>
        public ContractCreateCommand(ContractCreateRequest request)
        {
            this.ID_Contrato = request.ID_Contrato;
            this.PrioridadId = request.PrioridadId;
            this.IdiomaId = request.IdiomaId;
            this.EsMismoResponsable = request.EsMismoResponsable;
            this.Responsable = request.Responsable;
            this.TipoDocumento = request.TipoDocumento;
            this.EnElaboracion = request.EnElaboracion;
            this.UnidadId = request.UnidadId;
            this.Objeto = request.Objeto;
            this.Descripcion = request.Descripcion;
            this.Contraprestacion = request.Contraprestacion;
            this.FechaPago = request.FechaPago;
            this.Vigencia = request.Vigencia;
            this.MonedaId = request.MonedaId;
            this.LugarFechaFirma = request.LugarFechaFirma;
            this.Condiciones = request.Condiciones;
            this.SolicitanteId = request.SolicitanteId;
            this.ID_TipoAccion = request.ID_TipoAccion;
            this.ID_UsuarioEnvio = request.SolicitanteId;
            this.ListContratosDoc = request.ListContratosDoc;
            this.ID_Estatus = request.ID_Estatus;
            this.ID_UnidadUsuario = request.ID_UnidadUsuario;
            this.ID_TipoSolicitud = request.ID_TipoSolicitud;
            this.ProveedorId = request.ProveedorId;
            this.Comentarios = request.Comentarios;
            this.Version = request.Version;
            this.NombreContrato = request.NombreContrato;
            this.Extension = request.Extension;
            this.ContenttType = request.ContenttType;
            this.ExisteArchivo = request.ExisteArchivo;
            this.EsBorrador = request.EsBorrador;
            this.Proveedor = request.Proveedor;
            this.IdTipoSolicitud = request.IdTipoSolicitud;
            this.IDPais = request.IDPais;
            this.IDProducto = request.IDProducto;
            this.ID_ContratoPadre = request.ID_ContratoPadre;
            this.MultiProducto = request.MultiProducto;
            this.EmailSupervisor1 = request.EmailSupervisor1;
            this.EmailSupervisor2 = request.EmailSupervisor2;
            this.FieldsDoc_Liberado = request.FieldsDoc_Liberado;
            this.ID_FormatoLiberado = request.ID_FormatoLiberado;
            this.EsLiberado = request.EsLiberado;
        }

        //public long ID_Contrato { get; set; }


        //public bool isEnvio { get; set; }
        //#region Log
        //public string UserName { get; set; }
        //public string Path { get; set; }
        //public string Control { get; set; }
        //public string Message { get; set; }
        //#endregion

        //#region Contrato
        /////TB_Contratos
        ///// <summary>
        ///// ID_Solicitante
        ///// </summary>
        //public int ID_Solicitante { get; set; }
        ///// <summary>
        ///// ID_Responsable
        ///// 
        ///// </summary>
        //public int ID_Responsable { get; set; }
        /// <summary>
        /// ID_UnidadUsuario
        /// 
        /// </summary>
        public int ID_UnidadUsuario { get; set; }
        ///// <summary>
        ///// ID_Prioridad
        ///// 
        ///// </summary>
        //public int ID_Prioridad { get; set; }
        ///// <summary>
        ///// ID_TipoDocumento
        ///// 
        ///// </summary>
        //public int ID_TipoDocumento { get; set; }
        ///// <summary>
        ///// ID_Unidad
        ///// 
        ///// </summary>
        //public int ID_Unidad { get; set; }
        ///// <summary>
        ///// ID_Proveedor
        ///// 
        ///// </summary>
        //public int ID_Proveedor { get; set; }
        ///// <summary>
        ///// ID_Moneda
        ///// 
        ///// </summary>
        //public int ID_Moneda { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// 
        /// </summary>
        public int ID_TipoSolicitud { get; set; }
        ///// <summary>
        ///// idIdioma
        ///// 
        ///// </summary>
        //public int idIdioma { get; set; }
        ///// <summary>
        ///// ElaboracionContrato
        ///// 
        ///// </summary>
        //public bool ElaboracionContrato { get; set; }
        /// <summary>
        /// ID_Estatus
        /// 
        /// </summary>
        public int ID_Estatus { get; set; }
        //#endregion

        //#region Contrato Detalle
        /////TB_Contratos_Detalle
        ///// <summary>
        ///// ObjetoNegociacion
        ///// 
        ///// </summary>
        //public string ObjetoNegociacion { get; set; }
        ///// <summary>
        ///// DescServiciosProductos
        ///// </summary>
        //public string DescServiciosProductos { get; set; }
        ///// <summary>
        ///// Contraprestacion
        ///// </summary>
        //public string Contraprestacion { get; set; }
        ///// <summary>
        ///// FormaPago
        ///// </summary>
        //public string FormaPago { get; set; }
        ///// <summary>
        ///// Vigencia
        ///// </summary>
        //public string Vigencia { get; set; }
        ///// <summary>
        ///// LugarFechaFirma
        ///// </summary>
        //public string LugarFechaFirma { get; set; }
        ///// <summary>
        ///// CondicionesEspeciales
        ///// </summary>
        //public string CondicionesEspeciales { get; set; }
        //#endregion

        #region Contrato Version
        //TB_Contratos_Versiones
        /// <summary>
        /// ID_UsuarioEnvio
        /// </summary>
        public int ID_UsuarioEnvio { get; set; }
        /// <summary>
        /// ID_TipoAccion
        /// </summary>
        public int ID_TipoAccion { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public int? Version { get; set; }
        /// <summary>
        /// NombreContrato
        /// </summary>
        public string NombreContrato { get; set; }
        /// <summary>
        /// Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// ContenttType
        /// </summary>
        public string ContenttType { get; set; }

        /// <summary>
        /// Comentarios
        /// </summary>
        public string Comentarios { get; set; }
        #region Documentos
        #endregion
        /// <summary>
        /// ListContratosDoc
        /// </summary>
        public List<TBContratosDocumentacionDTO> ListContratosDoc { get; set; }
        #endregion
        /// <summary>
        /// Body
        /// </summary>
        #region Correo
        public string Body { get; set; }
        /// <summary>
        /// Destinatarios
        /// </summary>
        public string Destinatarios { get; set; }
        #endregion
        public bool EsBorrador { get; set; }
        /// <summary>
        /// Proveedor
        /// </summary>
        public string Proveedor { get; set; }
    }
}
