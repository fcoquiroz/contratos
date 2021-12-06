using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context.Behaviours
{

    /// <summary>
    /// IContractSave -Comportamiento para guardar contratos 
    /// </summary>
    public interface IContractSave
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        ContractCreateResponse Save(ContractCreateCommand command);
    }
}
