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
    /// Cat_UnidadRepository
    /// </summary>
    public class Cat_UnidadRepository : Repository<Cat_Unidad>, ICat_UnidadRepository
    {
        /// <summary>
        /// Cat_UnidadRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_UnidadRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// obtengo la lista de Unidades activa para llenar los combos de la pantalla
        /// </summary>
        /// <returns></returns>
        public List<UnidadesDTO> ObtenerUnidades()
        {
         
            return (from qry in consisContext.Cat_UnidadRoutines.Where(o => o.Activo == true).OrderBy(o => o.Nombre)
                    select new UnidadesDTO
                    {
                        Nombre = qry.Nombre,
                        UnidadID = qry.ID_Unidad
                    }).ToList();
        }
    }
}
