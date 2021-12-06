using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorySP.Core;
using RepositorySP.Core.Repositories;
using RepositorySP.Persistence.Repositories;

namespace RepositorySP.Persistence
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DataSPContext
        /// </summary>
        private readonly DataSPContext _context;
        /// <summary>
        /// Task
        /// </summary>
        /// <returns></returns>
        public async Task Commit()
        {
            await _context.Commit();
        }
         

        /// <summary>
        /// DisposeAsync
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await _context.Dispose();
        }
        /// <summary>
        /// UnitOfWork
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DataSPContext context)
        {
            _context = context;
         
            ContractRepo = new ContractRepository(_context);

        }
        /// <summary>
        /// ContractRepo
        /// </summary>
        public IContractRepository ContractRepo { get; private set; }

    }
}
