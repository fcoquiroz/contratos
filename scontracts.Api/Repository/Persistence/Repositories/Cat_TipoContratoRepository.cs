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
    /// Cat_TipoContratoRepository
    /// </summary>
    public class Cat_TipoContratoRepository : Repository<Cat_TipoContrato>, ICat_TipoContratoRepository
    {
        /// <summary>
        /// Cat_TipoContratoRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_TipoContratoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
