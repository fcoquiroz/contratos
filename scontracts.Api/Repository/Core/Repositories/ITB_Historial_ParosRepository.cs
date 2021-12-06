using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_Historial_ParosRepository
    /// </summary>
    public interface ITB_Historial_ParosRepository : IRepository<TB_Historial_Paros>
    {
        /// <summary>
        /// existeHistorialParo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        bool existeHistorialParo(ManagementCommentaryCommand command);
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="command"></param>
        void Save(ManagementCommentaryCommand command);
        /// <summary>
        /// ObtenerHistorialParo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        TB_Historial_Paros ObtenerHistorialParo(ManagementCommentaryCommand command);
        /// <summary>
        /// update
        /// </summary>
        /// <param name="command"></param>
        void Update(ManagementCommentaryCommand command);
        /// <summary>
        /// UpdateFechaParoSolicitante
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <param name="IdUsuario"></param>
        void UpdateFechaParoSolicitante(long ID_Contrato, int IdUsuario);
    }
}
