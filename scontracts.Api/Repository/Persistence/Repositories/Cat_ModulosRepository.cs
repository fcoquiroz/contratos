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
    /// Cat_ModulosRepository
    /// </summary>
    public class Cat_ModulosRepository : Repository<Cat_Modulos>, ICat_ModulosRepository
    {
        /// <summary>
        /// Cat_ModulosRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_ModulosRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
