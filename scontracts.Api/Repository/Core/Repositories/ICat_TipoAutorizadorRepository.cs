using Repository.Core.Domain;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ICat_TipoAutorizadorRepository : IRepository<Cat_TipoAutorizador>
    {
        List<TipoAutorizadorDTO> ObtenerTipoAutorizador();
    }
}
