using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ICat_TipoSolicitudRepository : IRepository<Cat_TipoSolicitud>
    {
        List<TipoContraparteDTO> ObtenerTipoContraparte();
    }
}
