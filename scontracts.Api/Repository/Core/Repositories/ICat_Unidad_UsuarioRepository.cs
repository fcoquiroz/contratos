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
    /// ICat_Unidad_UsuarioRepository
    /// </summary>
    public interface ICat_Unidad_UsuarioRepository : IRepository<Cat_Unidad_Usuario>
    {
        /// <summary>
        /// ObtenerUnidadesResponsable
        /// </summary>
        /// <returns></returns>
        List<UnidadesResponsableDTO> ObtenerUnidadesResponsable();
    }
}
