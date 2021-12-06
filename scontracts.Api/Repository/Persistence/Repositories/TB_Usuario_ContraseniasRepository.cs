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
    /// TB_Usuario_ContraseniasRepository
    /// </summary>
    public class TB_Usuario_ContraseniasRepository : Repository<TB_Usuario_Contrasenias>, ITB_Usuario_ContraseniasRepository
    {
        /// <summary>
        /// TB_Usuario_ContraseniasRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Usuario_ContraseniasRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
