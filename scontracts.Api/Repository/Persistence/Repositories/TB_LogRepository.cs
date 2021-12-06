using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_LogRepository
    /// </summary>
    public class TB_LogRepository : Repository<TB_Log>, ITB_LogRepository
    {
        /// <summary>
        /// TB_LogRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_LogRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
