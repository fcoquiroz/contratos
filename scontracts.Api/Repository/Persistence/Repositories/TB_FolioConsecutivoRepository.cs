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
    /// TB_FolioConsecutivoRepository
    /// </summary>
    public class TB_FolioConsecutivoRepository : Repository<TB_FolioConsecutivo>, ITB_FolioConsecutivoRepository
    {
        /// <summary>
        /// TB_FolioConsecutivoRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_FolioConsecutivoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        public TB_FolioConsecutivo ObtenerFolioConsecutivo()
        {
            TB_FolioConsecutivo FolioConsecutivo = new TB_FolioConsecutivo();

            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
               FolioConsecutivo = unitofwork.TB_FolioConsecutivoRoutines.Find(x => x.Ano == DateTime.Now.Year && x.ID_TipoSolicitud == 1).FirstOrDefault();
            }
            return FolioConsecutivo;

        }
        public void UpdateFolioConsecutivo(long FolioConsecutivo)
        {
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                TB_FolioConsecutivo fc = unitofwork.TB_FolioConsecutivoRoutines.Find(x => x.Ano == DateTime.Now.Year && x.ID_TipoSolicitud == 1).FirstOrDefault();
                fc.IdConsecutivo = FolioConsecutivo + 1;
                unitofwork.TB_FolioConsecutivoRoutines.Attach(fc);
                unitofwork.Commit();
            }
        }
    }
}
