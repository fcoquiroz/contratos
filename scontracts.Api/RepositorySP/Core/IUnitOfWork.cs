using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorySP.Core.Repositories;
namespace RepositorySP.Core
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        Task Commit();
        /// <summary>
        /// ContractRepo
        /// </summary>
        IContractRepository ContractRepo { get; }

    }
}
    