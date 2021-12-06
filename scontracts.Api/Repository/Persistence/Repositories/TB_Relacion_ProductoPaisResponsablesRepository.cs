using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Relacion_ProductoPaisResponsablesRepository : Repository<TB_Relacion_ProductoPaisResponsables>, ITB_Relacion_ProductoPaisResponsablesRepository
    {
        public TB_Relacion_ProductoPaisResponsablesRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }


        public void EditarAutorizadores(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                var objModRelacion = db.TB_Relacion_ProductoPaisResponsablesRoutines.Where(x => x.ID_Responsable == command.idAutorizador).Where(x => x.Activo == true);
                if (objModRelacion != null)
                {
                    foreach (var item in objModRelacion)
                    {
                        item.ID_Pais = command.ID_Pais;
                        item.Id_Producto = command.ID_Producto;
                        item.ID_Responsable = command.idAutorizador;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
