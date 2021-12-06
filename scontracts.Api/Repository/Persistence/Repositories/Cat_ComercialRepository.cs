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
    /// Cat_ComercialRepository
    /// </summary>
    public class Cat_ComercialRepository : Repository<Cat_Comercial>, ICat_ComercialRepository
    {
        /// <summary>
        /// Cat_ComercialRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_ComercialRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
