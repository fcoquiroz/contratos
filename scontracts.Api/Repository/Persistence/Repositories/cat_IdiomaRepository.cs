using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Shared.DTO;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// cat_IdiomaRepository
    /// </summary>
    public class cat_IdiomaRepository : Repository<cat_Idioma>, Icat_IdiomaRepository
    {
        /// <summary>
        /// cat_IdiomaRepository
        /// </summary>
        /// <param name="_context"></param>
        public cat_IdiomaRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// obtengo la lista de idiomas activa para llenar los combos de la pantallas
        /// </summary>
        /// <returns></returns>
        public List<IdiomasDTO> ObtenerIdiomas()
        {
            return (from qry in consisContext.cat_IdiomaRoutines
                    orderby qry.Idioma
                    select new IdiomasDTO
                    {
                        Idioma = qry.Idioma,
                        IdiomaId = qry.idIdioma
                    }).ToList();
        }
    }
}
