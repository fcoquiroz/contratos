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
    /// Cat_LDAPRepository
    /// </summary>
    public class Cat_LDAPRepository : Repository<Cat_LDAP>, ICat_LDAPRepository
    {
        /// <summary>
        /// Cat_LDAPRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_LDAPRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
