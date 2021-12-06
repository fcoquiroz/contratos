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
    /// Cat_TipoMonedaRepository
    /// </summary>
    public class Cat_TipoMonedaRepository : Repository<Cat_TipoMoneda>, ICat_TipoMonedaRepository
    {
        /// <summary>
        /// Cat_TipoMonedaRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_TipoMonedaRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// obtengo la lista de Monedas activa para llenar los combos de la pantalla
        /// </summary>
        /// <returns></returns>
        public List<TipoMonedaDTO> ObtenerTipoMoneda()
        {
            return (from qry in consisContext.Cat_TipoMonedaRoutines.Where(o => o.Activo == true)
                    select new TipoMonedaDTO
                    {
                        Nombre = qry.Nombre,
                        MonedaId = qry.ID_Moneda
                    }).ToList();
        }
    }
}
