using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_FolioConsecutivoRepository
    /// </summary>
    public interface ITB_FolioConsecutivoRepository : IRepository<TB_FolioConsecutivo>
    {
        /// <summary>
        /// ObtenerFolioConsecutivo
        /// </summary>
        /// <returns></returns>
        TB_FolioConsecutivo ObtenerFolioConsecutivo();
        /// <summary>
        /// UpdateFolioConsecutivo
        /// </summary>
        /// <param name="FolioConsecutivo"></param>
        void UpdateFolioConsecutivo(long FolioConsecutivo);
    }

}
