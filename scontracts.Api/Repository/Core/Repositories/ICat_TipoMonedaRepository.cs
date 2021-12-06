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
    /// ICat_TipoMonedaRepository
    /// </summary>
    public interface ICat_TipoMonedaRepository : IRepository<Cat_TipoMoneda>
    {
        List<TipoMonedaDTO> ObtenerTipoMoneda();
    }
}
