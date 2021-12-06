
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// Name
    /// </summary>
   public class ContractCreateRequest
    {
        /// <summary>
        /// SolicitanteId
        /// </summary>
        public int SolicitanteId { get; set; }
        /// <summary>
        /// PrioridadId
        /// </summary>
        public int PrioridadId { get; set; }
        /// <summary>
        /// IdiomaId
        /// </summary>
        public int IdiomaId { get; set; }
        /// <summary>
        /// EsMismoResponsable
        /// </summary>
        public bool EsMismoResponsable { get; set; }
        /// <summary>
        /// Responsable
        /// </summary>
        public ResponsableDTO Responsable { get; set; }
        /// <summary>
        /// TipoDocumento
        /// </summary>
        public int TipoDocumento { get; set; }
        /// <summary>
        /// EnElaboracion
        /// </summary>
        public bool EnElaboracion { get; set; }

       /// <summary>
       /// UnidadId = Empresa
       /// </summary>
        public int UnidadId { get; set; }

        /// <summary>
        /// ProveedorId = Contraparte
        /// </summary>
        public int ProveedorId { get; set; }
        /// <summary>
        /// Proveedor
        /// </summary>
        public string Proveedor { get; set; }
        /// <summary>
        /// Objeto
        /// </summary>
        public string Objeto { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Contraprestacion
        /// </summary>
        public string Contraprestacion { get; set; }
        /// <summary>
        /// FormaPago
        /// </summary>
        public string FechaPago { get; set; }
        /// <summary>
        /// Vigencia
        /// </summary>
        public string Vigencia { get; set; }
        /// <summary>
        /// MonedaId
        /// </summary>
        public int MonedaId { get; set; }
        /// <summary>
        /// LugarFechaFirma
        /// </summary>
        public string LugarFechaFirma { get; set; }
        /// <summary>
        /// Condiciones
        /// </summary>
        public string Condiciones { get; set; }
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
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// ID_TipoAccion
        /// </summary>
        public int ID_TipoAccion { get; set; }
        /// <summary>
        /// ID_Estatus
        /// </summary>
        public int ID_Estatus { get; set; }
        /// <summary>
        /// ID_UnidadUsuario
        /// </summary>
        public int ID_UnidadUsuario { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// </summary>
        public int ID_TipoSolicitud { get; set; }
        /// <summary>
        /// RegistroData
        /// </summary>
        public string ResponsableData { get; set; }
        /// <summary>
        /// Comentarios
        /// </summary>
        public string Comentarios { get; set; }
        /// <summary>
        /// ExisteArchivo
        /// </summary>
        public bool ExisteArchivo { get; set; }
        /// <summary>
        /// IdTipoSolicitud
        /// </summary>
        public int? IdTipoSolicitud { get; set; }
        /// <summary>
        /// ReqCaratula
        /// </summary>
        public int? ReqCaratula { get; set; }
        /// <summary>
        /// IDProducto
        /// </summary>
        public int? IDProducto { get; set; }
        /// <summary>
        /// EsLiberado
        /// </summary>
        public bool? EsLiberado { get; set; }
        /// <summary>
        /// ID_FormatoLiberado
        /// </summary>
        public int? ID_FormatoLiberado { get; set; }
        /// <summary>
        /// IDPais
        /// </summary>
        public int? IDPais { get; set; }
        /// <summary>
        /// IDAutorizador
        /// </summary>
        public int? IDAutorizador { get; set; }
        /// <summary>
        /// ID_ContratoPadre
        /// </summary>
        public long? ID_ContratoPadre { get; set; }
        public List<int> MultiProducto { get; set; }
        public string EmailSupervisor1 { get; set; }
        public string EmailSupervisor2 { get; set; }
        //public bool isEnvio { get; set; }
        //#region Contrato
        ////TB_CONTRATOS
        //public int ID_Solicitante { get; set; }
        //public int ID_Responsable { get; set; }
        //public int ID_UnidadUsuario { get; set; }
        //public int ID_Prioridad { get; set; }
        //public int ID_TipoDocumento { get; set; }
        //public int ID_Unidad { get; set; }
        //public int ID_Proveedor { get; set; }
        //public int ID_Moneda { get; set; }
        //public int ID_TipoSolicitud { get; set; }
        //public int idIdioma { get; set; }
        //public bool ElaboracionContrato { get; set; }
        //public int ID_Estatus { get; set; }
        //#endregion

        //#region Contrato Detalle
        /////TB_Contratos_Detalle
        //public string ObjetoNegociacion { get; set; }
        //public string DescServiciosProductos { get; set; }
        //public string Contraprestacion { get; set; }
        //public string FormaPago { get; set; }
        //public string Vigencia { get; set; }
        //public string LugarFechaFirma { get; set; }
        //public string CondicionesEspeciales { get; set; }
        //#endregion

        //#region Contrato Version
        ////TB_Contratos_Versiones
        //public int ID_UsuarioEnvio { get; set; }
        //public int ID_TipoAccion { get; set; }
        //public string Comentarios { get; set; }
        //public int Version { get; set; }
        //public string NombreContrato { get; set; }
        //public string Extension { get; set; }
        //public string ContenttType { get; set; }

        //#endregion

        #region Documentos
        /// <summary>
        /// ListContratosDoc
        /// </summary>
        public List<TBContratosDocumentacionDTO> ListContratosDoc { get; set; }
        #endregion

        //#region Correo
        //public string Body { get; set; }
        //public string Destinatarios { get; set; }
        //#endregion
        /// <summary>
        /// EsBorrador
        /// </summary>
        public bool EsBorrador { get; set; }

        public string FieldsDoc_Liberado { get; set; }
    }


}
