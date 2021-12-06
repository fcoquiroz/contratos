using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_Contratos_DocumentacionRepository
    /// </summary>
    public class TB_Contratos_DocumentacionRepository : Repository<TB_Contratos_Documentacion>, ITB_Contratos_DocumentacionRepository
    {
        /// <summary>
        /// TB_Contratos_DocumentacionRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Contratos_DocumentacionRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// ObtenerSeguimientoSolicitudes
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        public string ObtenerNombreArchivoMail(long id_contrato)
        {
            string nombreEmail = string.Empty;

            var m = (from doc in consisContext.TB_Contratos_DocumentacionRoutines
                     where doc.ID_Contrato == id_contrato && doc.ID_Documentacion == 9
                     orderby doc.ID_Archivo
                     select new { NombreDocEmail = doc.NombreArchivo }).FirstOrDefault();
            if (m != null)
            {
                nombreEmail = m.NombreDocEmail;
            }

            return nombreEmail;
        }
        
        /// <summary>
        /// DeleteFile
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ID_Archivo"></param>
        public TB_Contratos_Documentacion DeleteFile(DataContext db , long ID_Archivo)
        {
            var d = db.TB_Contratos_DocumentacionRoutines.Find(ID_Archivo);
            db.TB_Contratos_DocumentacionRoutines.Remove(d);
            db.SaveChanges();
            return d;
        }
    }
}
