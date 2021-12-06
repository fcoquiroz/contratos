using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Campos_CaratulaRepository : Repository<TB_Campos_Caratula>, ITB_Campos_CaratulaRepository
    {
        public TB_Campos_CaratulaRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }
        public List<CoverDataGetDTO> ObtenerCamposCaratula(long id_contrato)
        {
            var contr = consisContext.TB_ContratosRoutines.Find(id_contrato);
            List<CoverDataGetDTO> campos = (from qry in consisContext.TB_Campos_CaratulaRoutines.Where(x => x.Id_Caratula == contr.IdTipoSolicitud && x.Activo == true)
                                               select new CoverDataGetDTO
                                               {
                                                   Id_Campo = qry.Id_Campo,
                                                   Id_Caratula = qry.Id_Caratula,
                                                   KeyCampo = qry.KeyCampo,
                                                   NombreCampo = qry.NombreCampo,
                                                   Activo = qry.Activo,
                                                   IdConstante = qry.IdConstante
                                               }
                ).ToList();
            return campos;
        }
        public List<CoverDataGetDTO> ObtenerCamposCaratulaNombreColumna(long id_contrato,int BanderaCaratula)
        {
            var contr = consisContext.TB_ContratosRoutines.Find(id_contrato);
            List<CoverDataGetDTO> campos = (from qry in consisContext.TB_Campos_CaratulaRoutines.Where(f => f.Id_Caratula == BanderaCaratula && f.KeyCampo != "NombreContrato" && f.KeyCampo != "Rol" && f.KeyCampo != "Nombre")
                                            select new CoverDataGetDTO
                                            {
                                                Id_Campo = qry.Id_Campo,
                                                Id_Caratula = qry.Id_Caratula,
                                                KeyCampo = qry.KeyCampo,
                                                NombreCampo = qry.NombreCampo,
                                                Activo = qry.Activo,
                                                IdConstante = qry.IdConstante
                                            }
                ).ToList();
            return campos;
        }
    }
}
