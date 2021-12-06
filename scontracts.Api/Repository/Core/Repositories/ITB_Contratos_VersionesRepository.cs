using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_Contratos_VersionesRepository
    /// </summary>
    public interface ITB_Contratos_VersionesRepository : IRepository<TB_Contratos_Versiones>
    {
        /// <summary>
        /// ObtenerContratoVersion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        ContractCreateRequest ObtenerContratoVersion(ContractCreateCommand command);
        /// <summary>
        /// ObtenerSeguimientoSolicitudes
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        List<SeguimientoSolicitudDTO> ObtenerSeguimientoSolicitudes(long id_contrato);
        /// <summary>
        /// AcceptCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        AcceptCoverSetResponse AcceptCover(AcceptCoverSetCommand command);
        /// <summary>
        /// RejectCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        void RejectCover(RejectCoverSetCommand command);
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        ManagementCommentaryResponse Save(ManagementCommentaryCommand command, bool blnAnexo);
        /// <summary>
        /// ObtenerContratoVersiones
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        int ObtenerTipoAccion(long ID_Contrato);
        /// <summary>
        /// SaveCaratulaVersion
        /// </summary>
        /// <param name="ID_contrato"></param>
        /// <param name="ID_Usuario"></param>
        void SaveCaratulaVersion(long ID_contrato, int ID_Usuario);
        /// <summary>
        /// SaveRechazoCaratula
        /// </summary>
        /// <param name="ID_contrato"></param>
        /// <param name="ID_Usuario"></param>
        /// <param name="Comentarios"></param>
        void SaveRechazoCaratula(long ID_contrato, int ID_Usuario, string Comentarios);
        /// <summary>
        /// SaveLiberadoVersion
        /// </summary>
        /// <param name="ID_contrato"></param>
        /// <param name="ID_Usuario"></param>
        void SaveLiberadoVersion(long ID_contrato, int ID_Usuario);
        /// <summary>
        /// NombreContratoPrincipalRelacionado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        string ObtenerNombreContratoPrincipalRelacionado(long ID_Contrato);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        void SaveVersionContratoCancelado(ManagementCommentaryCommand command);
        /// <summary>
        /// SaveVersionComentarioAbogado
        /// </summary>
        /// <param name="command"></param>
        void SaveVersionComentarioAbogado(ManagementCommentaryCommand command);
        /// <summary>
        /// SaveVersionReactivarContratoSol
        /// </summary>
        /// <param name="command"></param>
        void SaveVersionReactivarContratoSol(ManagementCommentaryCommand command);
    }
}
