using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    public class ManagementCommentaryRequest
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// ID_Estatus
        /// </summary>
        public int ID_Estatus { get; set; }
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
        #endregion
        #region Documentos
        /// <summary>
        /// ListContratosDoc
        /// </summary>
        public List<TBContratosDocumentacionDTO> ListContratosDoc { get; set; }
        /// <summary>
        /// ListAnexosDoc
        /// </summary>
        public List<TBContratosDocumentacionDTO> ListAnexosDoc { get; set; }
        #endregion
        /// <summary>
        /// ExisteArchivo
        /// </summary>
        public bool ExisteArchivo { get; set; }
        /// <summary>
        /// Anexos 
        /// </summary>
        public bool Anexos { get; set; }
        /// <summary>
        /// EnParoSolicitante
        /// </summary>
        public bool EnParoSolicitante { get; set; }
        /// <summary>
        /// EnParoAbogado
        /// </summary>
        public bool EnParoAbogado { get; set; }
        /// <summary>
        /// AutorizaSolicitante
        /// </summary>
        public bool AutorizaSolicitante { get; set; }
        /// <summary>
        /// EnviaSolicitante
        /// </summary>
        public bool EnviaSolicitante { get; set; }
        /// <summary>
        /// hfAccion
        /// </summary>
        public int hfAccion { get; set; }
        /// <summary>
        /// StandBy
        /// </summary>
        public bool StandBy { get; set; }
        /// <summary>
        /// AutorizaAbogado
        /// </summary>
        public bool AutorizaAbogado { get; set; }
        /// <summary>
        /// EnviaAbogado
        /// </summary>
        public bool EnviaAbogado { get; set; }
        /// <summary>
        /// EsperaDocumentacion
        /// </summary>
        //public bool EsperaDocumentacion { get; set; }
        ///// <summary>
        ///// EsperaReplica
        ///// </summary>
        //public bool EsperaReplica { get; set; }
        ///// <summary>
        ///// Reactivar
        ///// </summary>
        //public bool Reactivar { get; set; }
        /// <summary>
        /// CancelarContrato
        /// </summary>
        //public bool CancelarContrato { get; set; }
        /// <summary>
        /// ID_TipoContrato
        /// </summary>
        public int? ID_TipoContrato { get; set; }
        /// <summary>
        /// SegundaVuelta
        /// </summary>
        public bool SegundaVuelta { get; set; }
        /// <summary>
        /// DiasSegundaVuelta
        /// </summary>
        public int DiasSegundaVuelta { get; set; }
        /// <summary>
        /// ID_Estatus_Cambio
        /// </summary>
        public int ID_Estatus_Cambio { get; set; }
        /// <summary>
        /// NombreUsuario
        /// </summary>
        public string NombreUsuario { get; set; }
        /// <summary>
        /// RequiereCaratula
        /// </summary>
        public int? RequiereCaratula { get; set; }
        /// <summary>
        /// NumAgrupados
        /// </summary>
        public int? NumAgrupados { get; set; }

        /// <summary>
        /// EsLiberado
        /// </summary>
        public bool EsLiberado { get; set; }
        /// <summary>
        /// ID_Prioridad
        /// </summary>
        public int ID_Prioridad { get; set; }
        /// <summary>
        /// AutorizaLiberado
        /// </summary>
        public bool AutorizaLiberado { get; set; }
        /// <summary>
        /// CancelarSolicitudContrato
        /// </summary>
        public bool CancelarSolicitudContrato { get; set; }
        /// <summary>
        /// EnviaComentarioAbogado
        /// </summary>
        public bool EnviaComentarioAbogado { get; set; }
        /// <summary>
        /// ReactivarContratoSolicitante
        /// </summary>
        public bool ReactivarContratoSolicitante { get; set; }
    }
}
