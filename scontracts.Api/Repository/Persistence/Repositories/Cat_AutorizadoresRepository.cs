using Repository.Core.Domain;
using Repository.Core.Repositories;
using Repository.Persistence.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class Cat_AutorizadoresRepository : Repository<Cat_Autorizadores>, ICat_AutorizadoresRepository
    {
        public Cat_AutorizadoresRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }


        public CoverDTO AutorizadorData(int Id_Autorizador, int Id_Contrato)
        {
            CoverDTO Autorizadores = (from qry in consisContext.Cat_AutorizadoresRoutines.Where(o =>
             o.Id_Autorizador == Id_Autorizador && o.Activo == true)
                                      select new CoverDTO
                                      {
                                          NombreAutorizador = qry.Nombre,
                                          TipoAutorizador = qry.TipoAutorizador,

                                      }).FirstOrDefault();


            return Autorizadores;
        }
        public void EditarAutorizadores(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                var objModificar = db.Cat_AutorizadoresRoutines.Where(x => x.Id_Autorizador == command.idAutorizador).Where(x => x.Activo == true);
                if (objModificar != null)
                {
                    foreach (var item2 in objModificar)
                    {
                        item2.Nombre = command.Nombre;
                        item2.Correo = command.Correo;
                        item2.TipoAutorizador = command.ID_TipoAutorizador;
                        item2.TipoCaratula = command.ID_TipoCaratula;
                        item2.ID_usuario = command.ID_Usuario_Envio;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
