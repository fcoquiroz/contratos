using Repository.Core.Domain;
using Repository.Core.Repositories;
using Repository.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// RefreshTokenRepository
    /// </summary>
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        /// <summary>
        /// RefreshTokenRepository Constructor
        /// </summary>
        /// <param name="_context"></param>
        public RefreshTokenRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

    }
}
