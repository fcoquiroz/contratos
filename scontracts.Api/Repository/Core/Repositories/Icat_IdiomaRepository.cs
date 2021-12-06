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
    /// Icat_IdiomaRepository
    /// </summary>
    public interface Icat_IdiomaRepository : IRepository<cat_Idioma>
    {
        List<IdiomasDTO> ObtenerIdiomas();
    }
}
