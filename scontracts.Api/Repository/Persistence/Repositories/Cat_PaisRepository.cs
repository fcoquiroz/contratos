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
    /// Cat_PaisRepository
    /// </summary>
    public class Cat_PaisRepository : Repository<Cat_Pais>, ICat_PaisRepository
    {
        /// <summary>
        /// Cat_PaisRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_PaisRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        public List<PaisesDTO> ObtenerPaises()
        {
            return (from qry in consisContext.Cat_PaisRoutines.Where(o => o.Activo == true)
                    select new PaisesDTO
                    {
                        Pais = qry.Pais,
                        PaisId = qry.ID_Pais
                    }).ToList();
        }

    }
}
