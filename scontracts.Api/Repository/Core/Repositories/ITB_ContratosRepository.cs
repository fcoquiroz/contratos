using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_ContratosRepository
    /// </summary>
    public interface ITB_ContratosRepository : IRepository<TB_Contratos>
    {
        /// <summary>
        /// ObtenerEstatusParaSolicitante
        /// </summary>
        /// <param name="solicitanteId"></param>
        /// <returns></returns>
        List<EstatusDTO> ObtenerEstatusParaSolicitante(int solicitanteId);

        /// <summary>
        /// ObtenerEstatusParaAbogado
        /// </summary>
        /// <param name="abogadoId"></param>
        /// <returns></returns>
        List<EstatusDTO> ObtenerEstatusParaAbogado(int abogadoId);

        List<EstatusDTO> ObtenerEstatusAdmin(int userId);

        /// <summary>
        /// ObtenerSolicitudesParaSolicitante 
        /// </summary>
        /// <param name="estatusId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SolicitudesParaSolicitanteDTO> ObtenerSolicitudesParaSolicitante(int estatusId, int userId);

        /// <summary>
        /// ObtenerSolicitudesParaAbogado
        /// </summary>
        /// <param name="estatusId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SolicitudesParaAbogadoDTO> ObtenerSolicitudesParaAbogado(int estatusId, int userId);
        List<SolicitudesParaAbogadoDTO> ObtenerSolicitudesAdmin(int estatusId, int userId);

        /// <summary>
        /// getsolicitud
        /// </summary>
        /// <param name="idContrato"></param>
        /// <returns></returns>
        SolicitudDTo getsolicitud(long idContrato);

        /// <summary>
        /// ObtenerContratoDocumentacion
        /// </summary>
        /// <param name="idContrato"></param>
        /// <returns></returns>
        List<TBContratosDocumentacionDTO> ObtenerContratoDocumentacion(long idContrato);
        SolicitudDTo ObtenerContratoPadre(long idContratoPadre);

        ///// <summary>
        ///// UpdateContract
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //AcceptCoverSetResponse AcceptCover(AcceptCoverSetCommand command);

        /// <summary>
        /// UpdateStatusContracts
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        ManagementCommentaryResponse UpdateStatusContracts(ManagementCommentaryCommand command, bool blnAnexo, bool enviaComentario);

        /// <summary>
        /// ObtenerContrato
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        TB_Contratos ObtenerContrato(long ID_Contrato);

        /// <summary>
        /// ObtenerSolicitudesPadre
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="idContraparte"></param>
        /// <param name="idUnidadUsuario"></param>
        /// <returns></returns>
        List<SolicitudesPadreDTO> ObtenerSolicitudesPadre(int idEmpresa, int idContraparte, int idUnidadUsuario);

        /// <summary>
        /// ObtenerContratosRelacionados
        /// </summary>
        /// <param name="idContratoPadre"></param>
        /// <returns></returns>
        List<SolicitudesPadreDTO> ObtenerContratosRelacionados(long idContratoPadre);
        /// <summary>
        /// SaveEstatusContrato
        /// </summary>
        /// <param name="ID_Contrato"></param>
        void SaveEstatusContrato(long ID_Contrato, int EstatusSolicitud);
        /// <summary>
        /// ObtenerPaisTipoSolicitud
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="ID_Pais"></param>
        /// <param name="IdTipoSolicitud"></param>
        void ObtenerPaisTipoSolicitud(long ID_Contrato, ref int? ID_Pais, ref int? IdTipoSolicitud);
        /// <summary>
        /// SaveEstatusContratoCancelado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="EstatusSolicitud"></param>
        /// <param name="motivo"></param>
        /// <param name="id_usuario_envio"></param>
        void SaveEstatusContratoCancelado(long ID_Contrato, int EstatusSolicitud, string motivo, int id_usuario_envio);
        /// <summary>
        /// SaveEstatusComentarioAbogado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        void SaveEstatusComentarioAbogado(long ID_Contrato);
        /// <summary>
        /// SaveReactivarContratoSolicitante
        /// </summary>
        /// <param name="ID_Contrato"></param>
        void SaveReactivarContratoSolicitante(long ID_Contrato);
    }
}
