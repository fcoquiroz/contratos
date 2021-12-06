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
    /// TB_Historial_EstatusRepository
    /// </summary>
    public class TB_Historial_EstatusRepository : Repository<TB_Historial_Estatus>, ITB_Historial_EstatusRepository
    {
        /// <summary>
        /// TB_Historial_EstatusRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Historial_EstatusRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
