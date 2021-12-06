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
    /// ICat_PaisRepository
    /// </summary>
    public interface ICat_PaisRepository : IRepository<Cat_Pais>
    {
        List<PaisesDTO> ObtenerPaises();

    }
}
