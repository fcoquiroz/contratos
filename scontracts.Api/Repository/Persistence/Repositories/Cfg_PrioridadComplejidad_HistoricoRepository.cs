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
    /// Cfg_PrioridadComplejidad_HistoricoRepository
    /// </summary>
    public class Cfg_PrioridadComplejidad_HistoricoRepository : Repository<Cfg_PrioridadComplejidad_Historico>, ICfg_PrioridadComplejidad_HistoricoRepository
    {
        /// <summary>
        /// Cfg_PrioridadComplejidad_HistoricoRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cfg_PrioridadComplejidad_HistoricoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
