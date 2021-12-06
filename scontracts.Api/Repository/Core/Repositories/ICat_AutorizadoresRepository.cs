using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ICat_AutorizadoresRepository : IRepository<Cat_Autorizadores>
    {
        /// <summary>
        /// AutorizadorData
        /// </summary>
        /// <param name="Id_Autorizador"></param>
        /// <param name="Id_Contrato"></param>
        /// <returns></returns>
        CoverDTO AutorizadorData(int Id_Autorizador, int Id_Contrato);
        /// <summary>
        /// EditarAutorizadores
        /// </summary>
        /// <param name="command"></param>
        void EditarAutorizadores(ManagementCoverCommand command);
    }
}
