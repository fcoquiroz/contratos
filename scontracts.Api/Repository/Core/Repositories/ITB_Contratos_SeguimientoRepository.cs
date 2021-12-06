using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_Contratos_SeguimientoRepository
    /// </summary>
    public interface ITB_Contratos_SeguimientoRepository : IRepository<TB_Contratos_Seguimiento>
    {
        /// <summary>
        /// CancelarMeeting
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        bool CancelarMeeting(long ID_Contrato);
    }
}
