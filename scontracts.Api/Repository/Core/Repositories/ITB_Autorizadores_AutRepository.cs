using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Autorizadores_AutRepository : IRepository<TB_Autorizadores_Aut>
    {
        /// <summary>
        /// AutorizadoresAutData
        /// </summary>
        /// <param name="Id_Contrato"></param>
        /// <param name="pVuelta"></param>
        /// <param name="pIdAutorizador"></param>
        /// <param name="EsExtra"></param>
        /// <returns></returns>
        CoverDTO AutorizadoresAutData(int Id_Contrato, int pVuelta, int pIdAutorizador, bool EsExtra);
        /// <summary>
        /// AutorizadoresAutSave
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        CoverDTO AutorizadoresAutSave(AcceptCoverSetCommand command);
        /// <summary>
        /// AutorizadoresAutExisteRechazo
        /// </summary>
        /// <param name="Id_Contrato"></param>
        /// <param name="pVuelta"></param>
        /// <returns></returns>
        bool AutorizadoresAutExisteRechazo(int Id_Contrato, int pVuelta);
        /// <summary>
        /// AutorizacionAutCompleta
        /// </summary>
        /// <param name="Id_Contrato"></param>
        /// <param name="pVuelta"></param>
        /// <returns></returns>
        bool AutorizacionAutCompleta(int Id_Contrato, int pVuelta);
        /// <summary>
        /// AutorizadoresAutSaveReject
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        CoverDTO AutorizadoresAutSaveReject(RejectCoverSetCommand command);
        /// <summary>
        /// GenerateAutorizacion
        /// </summary>
        /// <param name="Id_Contrato"></param>
        void GenerateAutorizacion(int Id_Contrato);
    }
}
