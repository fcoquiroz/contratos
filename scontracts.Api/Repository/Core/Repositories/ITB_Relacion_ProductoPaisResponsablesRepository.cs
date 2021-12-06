using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Relacion_ProductoPaisResponsablesRepository : IRepository<TB_Relacion_ProductoPaisResponsables>
    {
        /// <summary>
        /// EditarAutorizadores
        /// </summary>
        /// <param name="command"></param>
        void EditarAutorizadores(ManagementCoverCommand command);
    }
}
