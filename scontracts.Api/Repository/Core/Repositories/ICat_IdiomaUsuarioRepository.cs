using Repository.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scontracts.Shared.DTO;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ICat_IdiomaUsuarioRepository
    /// </summary>
    public interface ICat_IdiomaUsuarioRepository : IRepository<Cat_IdiomaUsuario>
    {
        List<IdiomaUsuarioDTO> ObtenerIdiomaUsuario();
    }
}
