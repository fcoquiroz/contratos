using Repository.Core.Domain;
using Repository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Relacion_Formato_UnidadRepository : Repository<TB_Relacion_Formato_Unidad>, ITB_Relacion_Formato_UnidadRepository
    {
        /// <summary>
        /// TB_Relacion_Formato_UnidadRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Relacion_Formato_UnidadRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
    }
}
