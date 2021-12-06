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
    /// Cat_PrioridadRepository
    /// </summary>
    public class Cat_PrioridadRepository : Repository<Cat_Prioridad>, ICat_PrioridadRepository
    {
        /// <summary>
        /// Cat_PrioridadRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_PrioridadRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }


        /// <summary>
        /// obtengo la lista de prioridades activa para llenar los combo de la pantallas
        /// </summary>
        /// <returns></returns>
        public List<PrioridadesDTO> ObtenerPrioridades()
        {
            return (from qry in consisContext.Cat_PrioridadRoutines.Where(o => o.Activo == true)
                    orderby qry.Nombre
                    select new PrioridadesDTO
                    {
                        Nombre = qry.Nombre,
                        PrioridadId = qry.ID_Prioridad
                    }).ToList();
        }
    }
}
