using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Detalle_DocumentoLiberadoRepository : IRepository<TB_Detalle_DocumentoLiberado>
    {
        void SaveDetail(ContractCreateCommand command);
    }
}
