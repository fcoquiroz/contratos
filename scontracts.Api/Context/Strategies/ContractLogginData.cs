using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Context.Behaviours;
using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context.Strategies
{

    /// <summary>
    /// ContractLogginData
    /// </summary>
    public class ContractLogginData : IContractLog
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public void Save(LogCreateCommand command)
        {

            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
             
                unitofwork.TB_LogRoutines.Add(
                    new TB_Log
                    {
                        Usuario = command.UserName,
                        Path = command.Path,
                        Control = command.Control,
                        Message = command.Message,
                        Date = DateTime.Now
                    });
                unitofwork.Commit();
            }

        }
    }
}
