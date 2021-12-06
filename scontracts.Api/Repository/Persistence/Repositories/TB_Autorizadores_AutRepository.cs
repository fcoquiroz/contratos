using Repository.Core.Domain;
using Repository.Core.Repositories;
using Repository.Persistence.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Enums;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Autorizadores_AutRepository : Repository<TB_Autorizadores_Aut>, ITB_Autorizadores_AutRepository
    {
        public TB_Autorizadores_AutRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }
        public CoverDTO AutorizadoresAutData(int Id_Contrato, int pVuelta, int pIdAutorizador, bool EsExtra)
        {
            CoverDTO banderasActivas = (from qry in consisContext.TB_Autorizadores_AutRoutines.Where(o => o.Id_Contrato == Id_Contrato && o.Vuelta == pVuelta && o.Id_Autorizador == pIdAutorizador && o.EsExtra== EsExtra)
                                        select new CoverDTO
                                        {
                                            Autorizo = qry.Autorizo
                                        }).FirstOrDefault();


            return banderasActivas;
        }
        public CoverDTO AutorizadoresAutSave(AcceptCoverSetCommand command)
        {
            bool isExtra;
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                CoverDTO res = new CoverDTO();
                isExtra = command.EsExtra == 1;
                TB_Autorizadores_Aut cto = unitofwork.TB_Autorizadores_AutRoutines.Single(o => o.Id_Contrato == command.Id_Contrato && o.Vuelta == command.Vuelta && o.Id_Autorizador == command.ID_Autorizador && o.EsExtra == isExtra);

                #region Código anterior comentado.
                /*if (command.ExisteAutorizadores_Aut)
                {
                    TB_Autorizadores_Aut cto = unitofwork.TB_Autorizadores_AutRoutines.Single(o => o.Id_Contrato == command.Id_Contrato);
                    switch (command.TipoAutorizador)
                    {
                        case (int)TipoAutorizador.AutorizadorBC:
                            cto.B_Business = 1;
                            break;
                        case (int)TipoAutorizador.AutorizadorComercial:
                            cto.B_Comercial = 1;
                            break;
                        case (int)TipoAutorizador.AutorizadorTecnico:
                            cto.B_Tecnico_Operativo = 1;
                            break;
                    }
                    unitofwork.TB_Autorizadores_AutRoutines.Attach(cto);
                }
                else
                {
                   
                    TB_Autorizadores_Aut dto = new TB_Autorizadores_Aut
                    {
                        Id_Contrato = (int)command.Id_Contrato,
                        B_Tecnico_Operativo = command.TipoAutorizador == (int)TipoAutorizador.AutorizadorTecnico ? 1 :0,
                        B_Business = command.TipoAutorizador == (int)TipoAutorizador.AutorizadorBC ? 1 : 0,
                        B_Comercial = command.TipoAutorizador == (int)TipoAutorizador.AutorizadorComercial ? 1 : 0
                    };
                    unitofwork.TB_Autorizadores_AutRoutines.Add(dto);
                   
                }*/
                #endregion

                cto.Autorizo = true;
                cto.Fecha = DateTime.Now;
                unitofwork.TB_Autorizadores_AutRoutines.Attach(cto);
                unitofwork.Commit();

                return AutorizadoresAutData((int)command.Id_Contrato, command.Vuelta, command.ID_Autorizador, isExtra);
            }
        }

        public bool AutorizadoresAutExisteRechazo(int Id_Contrato, int pVuelta)
        {
            int countRechazos = consisContext.TB_Autorizadores_AutRoutines.Where(o => o.Id_Contrato == Id_Contrato && o.Vuelta == pVuelta && o.Autorizo == false).Count();

            return (countRechazos == 0 ? false : true);
        }

        public bool AutorizacionAutCompleta(int Id_Contrato, int pVuelta)
        {
            int count = consisContext.TB_Autorizadores_AutRoutines.Where(o => o.Id_Contrato == Id_Contrato && o.Vuelta == pVuelta && o.Autorizo == null).ToList().Count();

            return (count == 0 ? true : false);
        }

        public CoverDTO AutorizadoresAutSaveReject(RejectCoverSetCommand command)
        {
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                CoverDTO res = new CoverDTO();
                bool isExtra = command.EsExtra == 1;
                TB_Autorizadores_Aut cto = unitofwork.TB_Autorizadores_AutRoutines.Single(o => o.Id_Contrato == command.Id_Contrato && o.Vuelta == command.Vuelta && o.Id_Autorizador == command.ID_Autorizador && o.EsExtra == isExtra);

                cto.Autorizo = false;
                cto.Fecha = DateTime.Now;
                cto.Comentario = command.Motivo;
                unitofwork.TB_Autorizadores_AutRoutines.Attach(cto);
                unitofwork.Commit();

                return AutorizadoresAutData((int)command.Id_Contrato, command.Vuelta, command.ID_Autorizador, isExtra);
            }
        }

        public void GenerateAutorizacion(int Id_Contrato)
        {
            using (var db = new DataContext())
            {
                var aut = db.TB_Autorizadores_AutRoutines.Where(x => x.Id_Contrato == Id_Contrato).OrderByDescending(x => x.Vuelta).FirstOrDefault();

                var max = (aut != null) ? aut.Vuelta + 1 : 1;

                var autorizadores = db.TB_Autorizadores_ContratoRoutines.Where(x => x.Activo == true && x.ID_Contrato == Id_Contrato).ToList();

                foreach (var item in autorizadores)
                {
                    db.TB_Autorizadores_AutRoutines.Add(
                        new TB_Autorizadores_Aut
                        {
                            Id_Contrato = Id_Contrato,
                            Autorizo = null,
                            Comentario = null,
                            Id_Autorizador = item.Id_Autorizador.Value,
                            EsExtra = item.Extra,
                            Fecha = null,
                            Vuelta = max
                        });

                    db.SaveChanges();
                }
            }
        }

    }
}
