using Repository.Core.Domain;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ICat_FormatoLiberadosRepository : IRepository<Cat_FormatoLiberados>
    {
        List<FormatosLiberadosDTO> ObtenerContratosLiberados(int idUnidadUsuario);
        Cat_FormatoLiberados ObtenerContratoLiberado(int? idFormatoLiberado);
    }
}
