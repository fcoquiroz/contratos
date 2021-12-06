using scontracts.Api.Context.Behaviours;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context
{
    /// <summary>
    /// ContractContext
    /// </summary>
    public class ContractContext
    {

        #region Behaviours
        /// <summary>
        /// IContractSave
        /// </summary>
        IContractSave _contractSave;


        /// <summary>
        /// IContractSave
        /// </summary>
        IContractLog _contractLog;

        #endregion

        #region Constructors
        /// <summary>
        /// ContractContext - Implementaciones para el comportamiento Save
        /// </summary>
        public ContractContext(IContractSave contractSave)
        {
            this._contractSave = contractSave;

        }


        /// <summary>
        /// ContractContext - Implementaciones para el comportamiento Log
        /// </summary>
        public ContractContext(IContractLog contractLog)
        {
            this._contractLog = contractLog;

        }
        #endregion

        #region Strategies

        /// <summary>
        /// SaveContract
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ContractCreateResponse SaveContract(ContractCreateCommand command)
        {
            return this._contractSave.Save(command);
        }


        /// <summary>
        /// SaveLog
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public void SaveLog(LogCreateCommand command)
        {
             this._contractLog.Save(command);
        }


        #endregion




    }
}
