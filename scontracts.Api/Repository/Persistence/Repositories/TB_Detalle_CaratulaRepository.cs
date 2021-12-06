using Newtonsoft.Json;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Detalle_CaratulaRepository : Repository<TB_Detalle_Caratula>, ITB_Detalle_CaratulaRepository
    {
        /// <summary>
        /// Cat_UnidadRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Detalle_CaratulaRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        public List<CoverDetalleDataGetDTO> ObtenerDetalleCaratula(int ID_Contrato)
        {

            List<CoverDetalleDataGetDTO> consultaGasto = (from qry in consisContext.TB_Detalle_CaratulaRoutines.Where(d => d.Id_Contrato == ID_Contrato)
                                                          select new CoverDetalleDataGetDTO
                                                          {
                                                              Id_Detalle_Caratula = qry.Id_Detalle_Caratula,
                                                              Id_Contrato = qry.Id_Contrato,
                                                              Id_Campo = qry.Id_Campo,
                                                              Valor = qry.Valor
                                                          }).ToList();

            return consultaGasto;
        }
        public void GuardarDetalleCaratula(ManagementCoverCommand command)
        {
            var des = JsonConvert.DeserializeObject<List<CoverDetalleDataGetDTO>>(command.HfArrayNombre);
            using (var db = new DataContext())
            {
                foreach (var item in des)
                {
                    var insertDetalle = new TB_Detalle_Caratula()
                    {
                        Id_Campo = item.Id_Campo,
                        Id_Contrato = command.ID_Contrato,
                        Valor = item.Valor
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertDetalle);
                }
                db.SaveChanges();
            }
        }
        public void GuardarExisteDetalleCaratula(ManagementCoverCommand command)
        {
            var des = JsonConvert.DeserializeObject<List<CoverDetalleDataGetDTO>>(command.HfArrayNombre);
            using (var db = new DataContext())
            {
                var x = db.TB_Detalle_CaratulaRoutines.Where(y => y.Id_Contrato == command.ID_Contrato).ToList();

                if (x != null)
                {
                    foreach (var item in x)
                    {
                        db.TB_Detalle_CaratulaRoutines.Remove(item);
                        db.SaveChanges();
                    }
                }
                foreach (var item in des)
                {
                    var insertDetalle = new TB_Detalle_Caratula()
                    {
                        Id_Campo = item.Id_Campo,
                        Id_Contrato = command.ID_Contrato,
                        Valor = item.Valor
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertDetalle);
                    db.SaveChanges();
                }
            }
        }
        public  void InsertXInversion(string Inversion, int id_contrato)
        {
            using (var db = new DataContext())
            {
                var cont = db.TB_ContratosRoutines.Find((long)id_contrato);
                var numerCampo = new TB_Campos_Caratula();
                if (cont.IdTipoSolicitud == 1)
                {
                    numerCampo = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "CampoSiNo2" && x.Id_Caratula == cont.IdTipoSolicitud).FirstOrDefault();
                }
                else
                {
                    numerCampo = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "CampoSiNo1" && x.Id_Caratula == cont.IdTipoSolicitud).FirstOrDefault();
                }


                if (Inversion == "1")
                {
                    var insertXSI = new TB_Detalle_Caratula()
                    {
                        Id_Campo = numerCampo.Id_Campo,
                        Id_Contrato = id_contrato,
                        Valor = "Si"
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertXSI);
                }
                else
                {
                    var insertXNO = new TB_Detalle_Caratula()
                    {
                        Id_Campo = numerCampo.Id_Campo,
                        Id_Contrato = id_contrato,
                        Valor = "No"
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertXNO);
                }
                db.SaveChanges();
            }
        }
        public void InsertXCapacidad(string Capacidad, int id_contrato)
        {
            using (var db = new DataContext())
            {
                var cont = db.TB_ContratosRoutines.Find((long)id_contrato);
                var numerCampo = db.TB_Campos_CaratulaRoutines.Where(x => x.Id_Caratula == cont.IdTipoSolicitud && x.KeyCampo == "CampoSiNo1").FirstOrDefault();
                if (Capacidad == "1")
                {
                    var insertXSI = new TB_Detalle_Caratula()
                    {
                        Id_Campo = numerCampo.Id_Campo,
                        Id_Contrato = id_contrato,
                        Valor = "Si"
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertXSI);
                }
                else
                {
                    var insertXNO = new TB_Detalle_Caratula()
                    {
                        Id_Campo = numerCampo.Id_Campo,
                        Id_Contrato = id_contrato,
                        Valor = "No"
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertXNO);
                }
                db.SaveChanges();
            }
        }
        public void InsertXPena(string Pena, int id_contrato)
        {
            using (var db = new DataContext())
            {
                var cont = db.TB_ContratosRoutines.Find((long)id_contrato);
                var numerCampo = new TB_Campos_Caratula();
                if (cont.IdTipoSolicitud == 1)
                {
                    numerCampo = db.TB_Campos_CaratulaRoutines.Where(x => x.Id_Caratula == cont.IdTipoSolicitud && x.KeyCampo == "CampoSiNo3").FirstOrDefault();
                }
                else
                {
                    numerCampo = db.TB_Campos_CaratulaRoutines.Where(x => x.Id_Caratula == cont.IdTipoSolicitud && x.KeyCampo == "CampoSiNo2").FirstOrDefault();
                }

                if (Pena == "1")
                {
                    var insertXSI = new TB_Detalle_Caratula()
                    {
                        Id_Campo = numerCampo.Id_Campo,
                        Id_Contrato = id_contrato,
                        Valor = "Si"
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertXSI);
                }
                else
                {
                    var insertXNO = new TB_Detalle_Caratula()
                    {
                        Id_Campo = numerCampo.Id_Campo,
                        Id_Contrato = id_contrato,
                        Valor = "No"
                    };
                    db.TB_Detalle_CaratulaRoutines.Add(insertXNO);
                }
                db.SaveChanges();
            }
        }
        public void Moneda(int id_contrato)
        {
            using (var db = new DataContext())
            {
                var moneda = (from C in db.TB_ContratosRoutines
                              join M in db.Cat_TipoMonedaRoutines on C.ID_Moneda equals M.ID_Moneda
                              where C.ID_Contrato == id_contrato
                              select new
                              {
                                  Moneda = M.Nombre,
                                  TipoContraparte = C.IdTipoSolicitud
                              }).FirstOrDefault();
                var CampoMoneda = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "Moneda" && x.Id_Caratula == moneda.TipoContraparte).FirstOrDefault();
                var proInsertar = new TB_Detalle_Caratula()
                {
                    Id_Campo = CampoMoneda.Id_Campo,
                    Id_Contrato = id_contrato,
                    Valor = moneda.Moneda
                };
                db.TB_Detalle_CaratulaRoutines.Add(proInsertar);
                db.SaveChanges();
            }
        }

        public void InsertClientesProductoPais(int id_contrato)
        {
            using (var db = new DataContext())
            {
                var consultaGeneral = (from C in db.TB_ContratosRoutines
                                       join P in db.Cat_ProveedorRoutines on C.ID_Proveedor equals P.ID_Proveedor
                                       join U in db.Cat_UnidadRoutines on C.ID_Unidad equals U.ID_Unidad
                                       join T in db.Cat_TipoSolicitudRoutines on C.IdTipoSolicitud equals T.IdTipoSolicitud
                                       join PA in db.Cat_PaisRoutines on C.IDPais equals PA.ID_Pais
                                       where C.ID_Contrato == id_contrato
                                       select new
                                       {
                                           Cliente = P.Nombre,
                                           EmpresaSol = U.Nombre,
                                           TipoContrato = T.Descripcion,
                                           Pais = PA.Pais,
                                           TipoSolicitud = C.IdTipoSolicitud
                                       }).First();
                var Kcliente = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "Cliente" && x.Id_Caratula == consultaGeneral.TipoSolicitud).FirstOrDefault();
                var KEmpresa = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "EmpresaContratante" && x.Id_Caratula == consultaGeneral.TipoSolicitud).FirstOrDefault();
                var KTipContrato = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "TipoContrato" && x.Id_Caratula == consultaGeneral.TipoSolicitud).FirstOrDefault();
                var KPais = db.TB_Campos_CaratulaRoutines.Where(x => x.KeyCampo == "Pais" && x.Id_Caratula == consultaGeneral.TipoSolicitud).FirstOrDefault();
                var insertCli = new TB_Detalle_Caratula()
                {
                    Id_Campo = Kcliente.Id_Campo,
                    Id_Contrato = id_contrato,
                    Valor = consultaGeneral.Cliente
                };
                db.TB_Detalle_CaratulaRoutines.Add(insertCli);
                var insertEmp = new TB_Detalle_Caratula()
                {
                    Id_Campo = KEmpresa.Id_Campo,
                    Id_Contrato = id_contrato,
                    Valor = consultaGeneral.EmpresaSol
                };
                db.TB_Detalle_CaratulaRoutines.Add(insertEmp);
                var insertTipC = new TB_Detalle_Caratula()
                {
                    Id_Campo = KTipContrato.Id_Campo,
                    Id_Contrato = id_contrato,
                    Valor = consultaGeneral.TipoContrato
                };
                db.TB_Detalle_CaratulaRoutines.Add(insertTipC);
                var insertPais = new TB_Detalle_Caratula()
                {
                    Id_Campo = KPais.Id_Campo,
                    Id_Contrato = id_contrato,
                    Valor = consultaGeneral.Pais
                };
                db.TB_Detalle_CaratulaRoutines.Add(insertPais);
                db.SaveChanges();
            }
        }

    }
}
