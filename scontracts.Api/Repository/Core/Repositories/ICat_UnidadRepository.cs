using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using scontracts.Shared.DTO;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ICat_UnidadRepository
    /// </summary>
    public interface ICat_UnidadRepository : IRepository<Cat_Unidad>
    {
        List<UnidadesDTO> ObtenerUnidades();
    }
}
