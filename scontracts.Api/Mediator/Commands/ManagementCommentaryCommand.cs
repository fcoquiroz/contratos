using MediatR;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Commands
{
    /// <summary>
    /// ManagementCommentaryCommand
    /// </summary>
    public class ManagementCommentaryCommand : ManagementCommentaryRequest, IRequest<ResponseT<ManagementCommentaryResponse>>
    {
        /// <summary>
        /// ManagementCommentaryCommand
        /// </summary>
        /// <param name="request"></param>
        public ManagementCommentaryCommand(ManagementCommentaryRequest request)
        {
            this.ID_Contrato = request.ID_Contrato;
            this.Folio = request.Folio;
            this.ID_UsuarioEnvio = request.ID_UsuarioEnvio;
            this.ID_TipoAccion = request.ID_TipoAccion;
            this.Comentarios = request.Comentarios;
            this.Version = request.Version;
            this.NombreContrato = request.NombreContrato;
            this.Extension = request.Extension;
            this.ContenttType = request.ContenttType;
            this.ID_Estatus = request.ID_Estatus;
            this.Anexos = request.Anexos;
            this.ListAnexosDoc = request.ListAnexosDoc;
            this.ListContratosDoc = request.ListContratosDoc;
            this.EnParoAbogado = request.EnParoAbogado;
            this.EnParoSolicitante = request.EnParoSolicitante;
            this.AutorizaSolicitante = request.AutorizaSolicitante;
            this.EnviaSolicitante = request.EnviaSolicitante;
            this.StandBy = request.StandBy;
            this.EnviaAbogado = request.EnviaAbogado;
            this.AutorizaAbogado = request.AutorizaAbogado;
            this.ID_TipoContrato = request.ID_TipoContrato;
            this.SegundaVuelta = request.SegundaVuelta;
            this.DiasSegundaVuelta = request.DiasSegundaVuelta;
            this.ID_Estatus_Cambio = request.ID_Estatus_Cambio;
            this.NombreUsuario = request.NombreUsuario;
            this.RequiereCaratula = request.RequiereCaratula;
            this.EsLiberado = request.EsLiberado;
            this.ID_Prioridad = request.ID_Prioridad;
            this.CancelarSolicitudContrato = request.CancelarSolicitudContrato;
            this.EnviaComentarioAbogado = request.EnviaComentarioAbogado;
            this.ReactivarContratoSolicitante = request.ReactivarContratoSolicitante;
        }
        /// <summary>
        /// ID_Contrato
        /// </summary>
        public long ID_Contrato { get; set; }
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
        #endregion
        /// <summary>
        /// EnParoSolicitante
        /// </summary>
        public bool? EnParoSolicitante { get; set; }
        /// <summary>
        /// EnParoAbogado
        /// </summary>
        public bool? EnParoAbogado { get; set; }
        /// <summary>
        /// Folio
        /// </summary>
        public string Folio { get; set; }
        /// <summary>
        /// AutorizaSolicitante
        /// </summary>
        public bool AutorizaSolicitante { get; set; }
        /// <summary>
        /// EnviaSolicitante
        /// </summary>
        public bool EnviaSolicitante { get; set; }
        /// <summary>
        /// StandBy
        /// </summary>
        public bool StandBy { get; set; }
        /// <summary>
        /// ListAnexosDoc
        /// </summary>
        public List<TBContratosDocumentacionDTO> ListAnexosDoc { get; set; }
        /// <summary>
        /// AutorizaAbogado
        /// </summary>
        public bool AutorizaAbogado { get; set; }
        /// <summary>
        /// EnviaAbogado
        /// </summary>
        public bool EnviaAbogado { get; set; }
        ///// <summary>
        ///// EsperaDocumentacion
        ///// </summary>
        //public bool EsperaDocumentacion { get; set; }
        ///// <summary>
        ///// EsperaReplica
        ///// </summary>
        //public bool EsperaReplica { get; set; }
        /// <summary>
        /// Reactivar
        /// </summary>
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
    }
}
