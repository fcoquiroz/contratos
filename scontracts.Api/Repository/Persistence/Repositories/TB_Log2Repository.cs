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
    /// TB_Log2Repository
    /// </summary>
    public class TB_Log2Repository : Repository<TB_Log2>, ITB_Log2Repository
    {
        /// <summary>
        /// TB_Log2Repository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Log2Repository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
