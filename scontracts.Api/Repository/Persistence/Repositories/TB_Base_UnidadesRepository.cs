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
    /// TB_Base_UnidadesRepository
    /// </summary>
    public class TB_Base_UnidadesRepository : Repository<TB_Base_Unidades>, ITB_Base_UnidadesRepository
    {
        /// <summary>
        /// TB_Base_UnidadesRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Base_UnidadesRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
