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
    /// Cfg_PrioridadComplejidadSegundaRepository
    /// </summary>
    public class Cfg_PrioridadComplejidadSegundaRepository : Repository<Cfg_PrioridadComplejidadSegunda>, ICfg_PrioridadComplejidadSegundaRepository
    {
        /// <summary>
        /// Cfg_PrioridadComplejidadSegundaRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cfg_PrioridadComplejidadSegundaRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
