using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ICat_Autorizadores_extraRepository : IRepository<Cat_Autorizadores_extra>
    {
        /// <summary>
        /// AutorizadorExtraData
        /// </summary>
        /// <param name="Id_Autorizador"></param>
        /// <param name="Id_Contrato"></param>
        /// <returns></returns>
        CoverDTO AutorizadorExtraData(int Id_Autorizador, int Id_Contrato);
        /// <summary>
        /// ObtenerAutorizadorNuevo
        /// </summary>
        /// <returns></returns>
        int ObtenerAutorizadorNuevo();
        /// <summary>
        /// GuardarAutorizadoresExtra
        /// </summary>
        /// <param name="command"></param>
        void GuardarAutorizadoresExtra(ManagementCoverCommand command);
        /// <summary>
        /// EditarAutorizadores
        /// </summary>
        /// <param name="command"></param>
        void EditarAutorizadores(ManagementCoverCommand command);
    }
}
