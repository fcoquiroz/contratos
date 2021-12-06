using Repository.Core.Domain;
using Repository.Core.Repositories;
using Repository.Persistence;
using Repository.Persistence.Repositories;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// Cat_TipoAutorizadorRepository
    /// </summary>
    public class Cat_TipoAutorizadorRepository : Repository<Cat_TipoAutorizador>, ICat_TipoAutorizadorRepository
    {
        /// <summary>
        /// Cat_TipoAutorizadorRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_TipoAutorizadorRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        public List<TipoAutorizadorDTO> ObtenerTipoAutorizador()
        {

            var tipA = consisContext.Cat_TipoAutorizadorRoutines.Where(x => x.Activo == true).ToList();
            List<TipoAutorizadorDTO> listTipo = new List<TipoAutorizadorDTO>();
            foreach (var item3 in tipA)
            {
                var objTipoA = new TipoAutorizadorDTO
                {
                    Id_TipoAutorizador = item3.Id_TipoAutorizador,
                    Descripcion = item3.Descripcion
                };
                listTipo.Add(objTipoA);
            }

            return listTipo;
        }
    }
}
