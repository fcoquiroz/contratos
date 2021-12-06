using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.DTO
{
    /// <summary>
    /// SolicitudDTo
    /// </summary>
    public class SolicitudDTo
    {
        #region Contrato
        //TB_CONTRATOS
        /// <summary>
        /// ID_Solicitante
        /// </summary>
        public int ID_Solicitante { get; set; }
        /// <summary>
        /// ID_Responsable
        /// </summary>
        public int ID_Responsable { get; set; }
        /// <summary>
        /// NombreResponsable
        /// </summary>
        public string NombreResponsable { get; set; }
        /// <summary>
        /// CargoResponsable
        /// </summary>
        public string CargoResponsable { get; set; }
        /// <summary>
        /// UnidadResponsable
        /// </summary>
        public string UnidadResponsable { get; set; }
        /// <summary>
        /// TelefonoResponsable
        /// </summary>
        public string TelefonoResponsable { get; set; }
        /// <summary>
        /// ID_UnidadUsuario
        /// </summary>
        public int ID_UnidadUsuario { get; set; }
        /// <summary>
        /// ID_Prioridad
        /// </summary>
        public int? ID_Prioridad { get; set; }
        /// <summary>
        /// NombrePrioridad
        /// </summary>
        public string NombrePrioridad { get; set; }
        /// <summary>
        /// ID_TipoDocumento
        /// </summary>
        public int ID_TipoDocumento { get; set; }
        /// <summary>
        /// NombreDocumento
        /// </summary>
        public string NombreDocumento { get; set; }
        /// <summary>
        /// ID_Unidad
        /// </summary>
        public int ID_Unidad { get; set; }
        /// <summary>
        /// NombreUnidad
        /// </summary>
        public string NombreUnidad { get; set; }
        /// <summary>
        /// ID_Proveedor
        /// </summary>
        public int ID_Proveedor { get; set; }
        /// <summary>
        /// Contraparte
        /// </summary>
        public string Contraparte { get; set; }
        /// <summary>
        /// ID_Moneda
        /// </summary>
        public int ID_Moneda { get; set; }
        /// <summary>
        /// ID_TipoSolicitud
        /// </summary>
        public int ID_TipoSolicitud { get; set; }
        /// <summary>
        /// idIdioma
        /// </summary>
        public int idIdioma { get; set; }
        /// <summary>
        /// NombreIdioma
        /// </summary>
        public string NombreIdioma { get; set; }
        /// <summary>
        /// ElaboracionContrato
        /// </summary>
        public bool ElaboracionContrato { get; set; }
        /// <summary>
        /// ID_Estatus
        /// </summary>
        public int ID_Estatus { get; set; }
        /// <summary>
        /// NombreSolicitante
        /// </summary>
        public string NombreSolicitante { get; set; }
        /// <summary>
        /// CargoSolicitante
        /// </summary>
        public string CargoSolicitante { get; set; }
        /// <summary>
        /// UnidadSolicitante
        /// </summary>
        public string UnidadSolicitante { get; set; }
        /// <summary>
        /// TelefonoSolicitante
        /// </summary>
        public string TelefonoSolicitante { get; set; }
        /// <summary>
        /// TipoContrato
        /// </summary>
        public int? TipoContrato { get; set; }
        #endregion

        #region Contrato Detalle
        ///TB_Contratos_Detalle
        /// <summary>
        /// ObjetoNegociacion
        /// </summary>
        public string ObjetoNegociacion { get; set; }
        /// <summary>
        /// DescServiciosProductos
        /// </summary>
        public string DescServiciosProductos { get; set; }
        /// <summary>
        /// Contraprestacion
        /// </summary>
        public string Contraprestacion { get; set; }
        /// <summary>
        /// FormaPago
        /// </summary>
        public string FormaPago { get; set; }
        /// <summary>
        /// Vigencia
        /// </summary>
        public string Vigencia { get; set; }
        /// <summary>
        /// LugarFechaFirma
        /// </summary>
        public string LugarFechaFirma { get; set; }
        /// <summary>
        /// CondicionesEspeciales
        /// </summary>
        public string CondicionesEspeciales { get; set; }
        /// <summary>
        /// Moneda
        /// </summary>
        public string Moneda { get; set; }
        /// <summary>
        /// ID_FormatoLiberados
        /// </summary>
        public int? ID_FormatoLiberados { get; set; }
        /// <summary>
        /// EnParoSolicitante
        /// </summary>
        public bool? EnParoSolicitante { get; set; }
        /// <summary>
        /// EnParoAbogado
        /// </summary>
        public bool? EnParoAbogado { get; set; }
        #endregion

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
        /// Comentarios
        /// </summary>
        public string Comentarios { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public int Version { get; set; }
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
        public DateTime? FechaVencimiento { get; set; }
        #endregion

        #region Documentos
        /// <summary>
        /// ListContratosDoc
        /// </summary>
        public List<TBContratosDocumentacionDTO> ListContratosDoc { get; set; }
        #endregion

        #region Correo
        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Destinatarios
        /// </summary>
        public string Destinatarios { get; set; }
        public int? IDPais { get; set; }
        /// <summary>
        /// ID_ContratoPadre
        /// </summary>
        public long? ID_ContratoPadre { get; set; }

        /// <summary>
        /// IdTipoSolicitud
        /// </summary>
        public int? IdTipoSolicitud { get; set; }

        /// <summary>
        /// FolioPadre
        /// </summary>
        public string FolioPadre { get; set; }

        /// <summary>
        /// FechaSolicitud
        /// </summary>
        public DateTime FechaSolicitud { get; set; }

        /// <summary>
        /// Estatus
        /// </summary>
        public string Estatus { get; set; }
        #endregion
    }


}
