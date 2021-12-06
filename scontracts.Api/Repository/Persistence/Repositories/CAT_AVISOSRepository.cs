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
    /// CAT_AVISOSRepository
    /// </summary>
    public class CAT_AVISOSRepository : Repository<CAT_AVISOS>, ICAT_AVISOSRepository
    {
        /// <summary>
        /// CAT_AVISOSRepository
        /// </summary>
        /// <param name="_context"></param>
        public CAT_AVISOSRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
