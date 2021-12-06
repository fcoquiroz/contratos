using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context.Behaviours
{
    /// <summary>
    /// IContractLog
    /// </summary>
    public interface IContractLog
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="command"></param>
        void Save(LogCreateCommand command);
    }
}
