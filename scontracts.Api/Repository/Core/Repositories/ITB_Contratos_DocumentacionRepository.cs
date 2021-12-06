using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Persistence;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ITB_Contratos_DocumentacionRepository
    /// </summary>
    public interface ITB_Contratos_DocumentacionRepository : IRepository<TB_Contratos_Documentacion>
    {
        /// <summary>
        /// ObtenerNombreArchivoMail
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        string ObtenerNombreArchivoMail(long id_contrato);
        /// <summary>
        /// DeleteFile
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ID_Archivo"></param>
        TB_Contratos_Documentacion DeleteFile(DataContext db, long ID_Archivo);
    }
}
