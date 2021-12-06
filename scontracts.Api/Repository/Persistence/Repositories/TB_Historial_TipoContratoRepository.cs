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
    /// TB_Historial_TipoContratoRepository
    /// </summary>
    public class TB_Historial_TipoContratoRepository : Repository<TB_Historial_TipoContrato>, ITB_Historial_TipoContratoRepository
    {
        /// <summary>
        /// TB_Historial_TipoContratoRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Historial_TipoContratoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
