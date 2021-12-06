using Repository.Core.Domain;
using Repository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_CaratulaRepository : Repository<TB_Caratula>, ITB_CaratulaRepository
    {
        public TB_CaratulaRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
