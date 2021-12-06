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
    /// Cfg_UsuarioUnidadConsultaRepository
    /// </summary>
    public class Cfg_UsuarioUnidadConsultaRepository : Repository<Cfg_UsuarioUnidadConsulta>, ICfg_UsuarioUnidadConsultaRepository
    {
        /// <summary>
        /// Cfg_UsuarioUnidadConsultaRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cfg_UsuarioUnidadConsultaRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
