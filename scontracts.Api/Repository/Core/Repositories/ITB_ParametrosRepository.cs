using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_ParametrosRepository
    /// </summary>
    public interface ITB_ParametrosRepository : IRepository<TB_Parametros>
    {
        TB_Parametros ObtenerParametro(int idParametro);
    }
}
