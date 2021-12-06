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
    /// TB_Contratos_HistorialRepository
    /// </summary>
    public class TB_Contratos_HistorialRepository : Repository<TB_Contratos_Historial>, ITB_Contratos_HistorialRepository
    {
        /// <summary>
        /// TB_Contratos_HistorialRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Contratos_HistorialRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
