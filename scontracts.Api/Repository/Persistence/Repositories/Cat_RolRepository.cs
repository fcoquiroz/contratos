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
    /// Cat_RolRepository
    /// </summary>
    public class Cat_RolRepository : Repository<Cat_Rol>, ICat_RolRepository
    {
        /// <summary>
        /// Cat_RolRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_RolRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
