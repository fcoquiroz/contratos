using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_Historial_ParosRepository
    /// </summary>
    public class TB_Historial_ParosRepository : Repository<TB_Historial_Paros>, ITB_Historial_ParosRepository
    {
        /// <summary>
        /// TB_Historial_ParosRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Historial_ParosRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }


        public bool existeHistorialParo(ManagementCommentaryCommand command)
        {
            bool existe = false;
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                
                existe = unitofwork.TB_Historial_ParosRoutines.Find(x => x.IdContrato == command.ID_Contrato && x.FechaActivacion == null).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault() == null ? true : false;
                
            }
            return existe;
        }
        public void Save(ManagementCommentaryCommand command)
        {
            
            using (var unitofwork = new UnitOfWork(new DataContext()))
            { 
                var ce = new TB_Historial_Paros
                {
                    IdContrato = command.ID_Contrato,
                    FechaParo = DateTime.Now,
                    Comentario = command.Comentarios,
                    UsuarioAplicoParo = command.ID_UsuarioEnvio.ToString(),
                    UltimoEstatus = command.ID_Estatus
                };
                unitofwork.TB_Historial_ParosRoutines.Add(ce);
                unitofwork.Commit();
           
            }
        }
        public TB_Historial_Paros ObtenerHistorialParo(ManagementCommentaryCommand command)
        {
            TB_Historial_Paros Historial_Paros = new TB_Historial_Paros();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                Historial_Paros = unitofwork.TB_Historial_ParosRoutines.Find(x => x.IdContrato == command.ID_Contrato && x.FechaActivacion == null).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault();

            }
            return Historial_Paros;
        }
        public void Update(ManagementCommentaryCommand command)
        {
       
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                TB_Historial_Paros hp = unitofwork.TB_Historial_ParosRoutines.Find(o => o.IdContrato == command.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault();
                hp.FechaActivacion = DateTime.Now;
                hp.UsuarioAplicoActivacion = command.ID_UsuarioEnvio.ToString();
                unitofwork.TB_Historial_ParosRoutines.Attach(hp);
                unitofwork.Commit();

            }
        }
        /// <summary>
        /// ActualizarFechaParoSolicitante
        /// </summary>
        /// <param name="ID_Contrato"></param>
        public void UpdateFechaParoSolicitante(long ID_Contrato,int IdUsuario)
        {
            using (var db = new DataContext())
            {
                TB_Contratos contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                TB_Historial_Paros hp = db.TB_Historial_ParosRoutines.Where(x => x.IdContrato == contrato.ID_Contrato).OrderByDescending(x => x.Id_HistorialParos).FirstOrDefault();
                #region Historial Paro
                hp.FechaActivacion = DateTime.Now;
                hp.UsuarioAplicoActivacion = IdUsuario.ToString();

                db.Entry(hp).CurrentValues.SetValues(hp);
                db.SaveChanges();
                #endregion
            }
        }

    }
}
