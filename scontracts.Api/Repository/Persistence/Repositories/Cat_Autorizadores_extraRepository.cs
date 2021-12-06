using Newtonsoft.Json;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class Cat_Autorizadores_extraRepository : Repository<Cat_Autorizadores_extra>, ICat_Autorizadores_extraRepository
    {
        public Cat_Autorizadores_extraRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }

        public CoverDTO AutorizadorExtraData(int Id_Autorizador, int Id_Contrato)
        {
            CoverDTO AutorizadoresExtra = (from qry in consisContext.Cat_Autorizadores_extraRoutines.Where(o =>
             o.Id_Autorizador_extra == Id_Autorizador && o.Activo == true)
                                      select new CoverDTO
                                      {
                                          NombreAutorizador = qry.Nombre,
                                          TipoAutorizador = qry.TipoAutorizador,

                                      }).FirstOrDefault();


            return AutorizadoresExtra;
        }



        public int ObtenerAutorizadorNuevo()
        {
            var idAutorizadorNuevo = consisContext.Cat_Autorizadores_extraRoutines.Where(x => x.Activo == true).OrderByDescending(x => x.Id_Autorizador_extra).FirstOrDefault();
            int idNuevo = (idAutorizadorNuevo != null) ? idAutorizadorNuevo.Id_Autorizador_extra + 1 : 1;
            return idNuevo;
        }

        public void GuardarAutorizadoresExtra(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                var obj = new Cat_Autorizadores_extra()
                {
                    //Id_Autorizador_extra = command.idAutorizador,
                    Nombre = command.Nombre,
                    Correo = command.Correo,
                    Activo = true,
                    TipoAutorizador = command.ID_TipoAutorizador,
                    TipoCaratula = command.ID_TipoCaratula,
                    ID_Producto = command.ID_Producto,
                    ID_Pais = command.ID_Pais,
                    ID_Usuario = command.ID_Usuario_Envio,
                    ID_Contrato = command.ID_Contrato

                    
                };
                db.Cat_Autorizadores_extraRoutines.Add(obj);
                db.SaveChanges();
            }
        }
        public void EditarAutorizadores(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                var objModificar = db.Cat_Autorizadores_extraRoutines.Find(command.idAutorizador);
                objModificar.Nombre = command.Nombre.ToString();
                objModificar.Correo = command.Correo;
                objModificar.TipoAutorizador = command.ID_TipoAutorizador;
                objModificar.TipoCaratula = command.ID_TipoCaratula;
                objModificar.ID_Usuario = command.ID_Usuario_Envio;
                objModificar.ID_Pais = command.ID_Pais;
                objModificar.ID_Producto = command.ID_Producto;

                db.Entry(objModificar).CurrentValues.SetValues(objModificar);
                db.SaveChanges();
            }
        }
    }
}
