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
    /// TB_ParametrosRepository
    /// </summary>
    public class TB_ParametrosRepository : Repository<TB_Parametros>, ITB_ParametrosRepository
    {
        /// <summary>
        /// TB_ParametrosRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_ParametrosRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        /// <summary>
        /// ObtenerParametro
        /// </summary>
        /// <param name="idParametro"></param>
        /// <returns></returns>
        public TB_Parametros ObtenerParametro(int idParametro)
        {
            TB_Parametros c = new TB_Parametros();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                c = unitofwork.TB_ParametrosRoutines.Find(x => x.ID_Parametro == idParametro).FirstOrDefault();

            }
            return c;
        }

    }
}
