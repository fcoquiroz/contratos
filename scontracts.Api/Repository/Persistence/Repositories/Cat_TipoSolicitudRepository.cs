using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class Cat_TipoSolicitudRepository : Repository<Cat_TipoSolicitud>, ICat_TipoSolicitudRepository
    {
        public Cat_TipoSolicitudRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }

        public List<TipoContraparteDTO> ObtenerTipoContraparte()
        {
            return (from qry in consisContext.Cat_TipoSolicitudRoutines.Where(o => o.Activo == true)
            select new TipoContraparteDTO
            {
                TipoContraparteId = qry.IdTipoSolicitud,
                Nombre = qry.Descripcion
            }).ToList();
        }

    }
}
