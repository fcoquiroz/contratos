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
    /// Cfg_ContratoUsuarioRepository
    /// </summary>
    public class Cfg_ContratoUsuarioRepository : Repository<Cfg_ContratoUsuario>, ICfg_ContratoUsuarioRepository
    {
        /// <summary>
        /// Cfg_ContratoUsuarioRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cfg_ContratoUsuarioRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
