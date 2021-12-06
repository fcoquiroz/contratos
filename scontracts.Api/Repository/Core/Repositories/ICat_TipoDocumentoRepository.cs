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
    /// ICat_TipoDocumentoRepository
    /// </summary>
    public interface ICat_TipoDocumentoRepository : IRepository<Cat_TipoDocumento>
    {
        List<TipoDocumentoDTO> ObtenerTipoDocumentos();
    }
}
