using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Autorizadores_ContratoRepository : Repository<TB_Autorizadores_Contrato>, ITB_Autorizadores_ContratoRepository
    {
        public TB_Autorizadores_ContratoRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }

        public void GuardarAutorizadoresContrato(long ID_Contrato)
        {
            using (var db = new DataContext())
            {
                var contrato = db.TB_ContratosRoutines.Find(ID_Contrato);
                #region autorizadores
                var tb_aut = db.TB_Autorizadores_ContratoRoutines.Where(x => x.ID_Contrato == contrato.ID_Contrato && x.Activo == true).ToList();
                if (tb_aut.Count == 0)
                {
                    var prd = db.TB_MultiProductoRoutines.Where(x => x.Activo == true && x.ID_Contrato == contrato.ID_Contrato).Select(x => x.ID_Producto);
                    var relacion = db.TB_Relacion_ProductoPaisResponsablesRoutines.Where(x => x.Activo == true && x.ID_Pais == contrato.IDPais && prd.Contains(x.Id_Producto)).Select(x => x.ID_Responsable);

                    var aut = db.Cat_AutorizadoresRoutines.Where(x => x.Activo == true && relacion.Contains(x.Id_Autorizador) && x.TipoCaratula == contrato.IdTipoSolicitud);
                    List<Cat_Autorizadores> autlist = aut.ToList();
                    foreach (var item10 in autlist)
                    {

                        db.TB_Autorizadores_ContratoRoutines.Add(new TB_Autorizadores_Contrato
                        {
                            Id_Autorizador = item10.Id_Autorizador,
                            Activo = true,
                            Extra = false,
                            ID_Contrato = contrato.ID_Contrato
                        });

                        db.SaveChanges();
                    }
                }


                #endregion

            }
        }
        public void GuardarAutorizadoresContratoCorreo(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                var objAutoC = new TB_Autorizadores_Contrato()
                {
                    ID_Contrato = command.ID_Contrato,
                    Extra = true,
                    Activo = true,
                    Id_Autorizador = command.idAutorizador
                };
                db.TB_Autorizadores_ContratoRoutines.Add(objAutoC);
                db.SaveChanges();
            }
        }
        public void EliminarAutorizadoresContrato(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                var consultaIncialAutorizaodr = db.TB_Autorizadores_ContratoRoutines.Where(x => x.Id_Autorizador == command.idAutorizador && x.Activo == true && x.Extra ==command.Extra && x.ID_Contrato == command.ID_Contrato).First();
                consultaIncialAutorizaodr.Activo = false; 
                db.Entry(consultaIncialAutorizaodr).CurrentValues.SetValues(consultaIncialAutorizaodr);
                db.SaveChanges();
            }
        }
    }
}
