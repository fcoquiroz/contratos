using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_Contratos_EmailRepository
    /// </summary>
    public interface ITB_Contratos_EmailRepository : IRepository<TB_Contratos_Email>
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="ID_Correo"></param>
        /// <param name="Asunto"></param>
        /// <param name="Comentarios"></param>
        /// <param name="EsSolicitante"></param>
        /// <returns></returns>
        ManagementCommentaryResponse Save(long ID_Contrato, int ID_Correo, string Asunto, string Comentarios, bool EsSolicitante);
        /// <summary>
        /// SaveEmailAcceptCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        bool SaveEmailAcceptCover(AcceptCoverSetCommand command);
        /// <summary>
        /// SaveEmailRejectCover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        bool SaveEmailRejectCover(RejectCoverSetCommand command);
        /// <summary>
        /// SaveContratoFirma
        /// </summary>
        /// <param name="iD_Contrato"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="comentarios"></param>
        /// <param name="v3"></param>
        /// <param name="listContratosDoc"></param>
        /// <returns></returns>
        ManagementCommentaryResponse SaveContratoFirma(long iD_Contrato, int v1, string v2, string comentarios, bool v3, List<TBContratosDocumentacionDTO> listContratosDoc);
        /// <summary>
        /// SaveContratoCaratula
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="BuscarAutorizadoresPorContrato"></param>
        void SaveContratoCaratula(long ID_Contrato, List<BuscarAutorizadoresPorContratoDTO> BuscarAutorizadoresPorContrato);
        /// <summary>
        /// SaveEmailRechazo
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="Comentarios"></param>
        void SaveEmailRechazo(long ID_Contrato, string Comentarios);
        /// <summary>
        /// SaveEmailEnvioCaratula
        /// </summary>
        /// <param name="ID_Contrato"></param>
        void SaveEmailEnvioCaratula(long ID_Contrato);
        /// <summary>
        /// SaveEmailAutLiberado
        /// </summary>
        /// <param name="ID_Contrato"></param>
        void SaveEmailAutLiberado(long ID_Contrato);
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
        ManagementCommentaryResponse SaveEmailAutorizar(long ID_Contrato, int ID_Correo, string Asunto, string Comentarios, bool EsSolicitante,int Id_Prioridad);
        /// <summary>
        /// SaveEmailContratoCancelado
        /// </summary>
        /// <param name="command"></param>
        void SaveEmailContratoCancelado(ManagementCommentaryCommand command);
        /// <summary>
        /// GetCorreosSupervisoresContrato
        /// </summary>
        /// <param name="db"></param>
        /// <param name="IdContrato"></param>
        /// <returns></returns>
        string GetCorreosSupervisoresContrato(DataContext db, long IdContrato);
        /// <summary>
        /// SaveEmailComentarioAbogado
        /// </summary>
        /// <param name="command"></param>
        void SaveEmailComentarioAbogado(ManagementCommentaryCommand command);

    }

}
