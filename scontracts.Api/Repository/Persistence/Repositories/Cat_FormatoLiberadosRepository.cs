using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class Cat_FormatoLiberadosRepository : Repository<Cat_FormatoLiberados>, ICat_FormatoLiberadosRepository
    {
        /// <summary>
        /// Cat_DiaFestivoRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_FormatoLiberadosRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }


        /// <summary>
        /// ObtenerContratosLiberados - Lista de contratos liberados para mostrar en el combo.
        /// </summary>
        /// <returns></returns>
        public List<FormatosLiberadosDTO> ObtenerContratosLiberados(int idUnidadUsuario)
        {
            List<FormatosLiberadosDTO> contratosLiberados = new List<FormatosLiberadosDTO>();

            var disponibles = consisContext.TB_Relacion_Formato_UnidadRoutines.Where(x => x.ID_UnidadUsuario == idUnidadUsuario && x.Activo == true);

            if(disponibles.Count() > 0)
            {
                var docxXRegion = disponibles.Select(x => x.ID_FormatoLiberado);

                contratosLiberados = (from qry in consisContext.Cat_FormatoLiberadosRoutines.Where(o => o.Activo == true && docxXRegion.Contains(o.ID_FormatoLiberado))
                                      select new FormatosLiberadosDTO
                                      {
                                          IdDocumento = qry.ID_FormatoLiberado,
                                          Nombre = qry.Nombre,
                                          IdTipoSolicitud = qry.Id_TipoSolicitud,
                                          IdTipoDocumento = qry.Id_TipoDocumento
                                      }).ToList();
            }

            return contratosLiberados;
        }

        /// <summary>
        /// ObtenerParametro
        /// </summary>
        /// <param name="idParametro"></param>
        /// <returns></returns>
        public Cat_FormatoLiberados ObtenerContratoLiberado(int? idFormatoLiberado)
        {
            Cat_FormatoLiberados c = new Cat_FormatoLiberados();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                c = unitofwork.Cat_FormatoLiberadosRoutines.Find(x => x.ID_FormatoLiberado == idFormatoLiberado).FirstOrDefault();
            }
            return c;
        }

    }
}
