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
    /// Cat_PantallasRepository
    /// </summary>
    public class Cat_PantallasRepository : Repository<Cat_Pantallas>, ICat_PantallasRepository
    {
        /// <summary>
        /// Cat_PantallasRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_PantallasRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
