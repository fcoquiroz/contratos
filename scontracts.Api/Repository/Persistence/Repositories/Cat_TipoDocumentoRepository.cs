using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using scontracts.Shared.DTO;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// Cat_TipoDocumentoRepository
    /// </summary>
    public class Cat_TipoDocumentoRepository : Repository<Cat_TipoDocumento>, ICat_TipoDocumentoRepository
    {
        /// <summary>
        /// Cat_TipoDocumentoRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_TipoDocumentoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// obtengo la lista de  tipos de documentos activa para llenar los combos de las pantallas
        /// </summary>
        /// <returns></returns>
        public List<TipoDocumentoDTO> ObtenerTipoDocumentos()
        {
            return (from qry in consisContext.Cat_TipoDocumentoRoutines.Where(o => o.Activo == true)
                    orderby qry.Nombre
                    select new TipoDocumentoDTO
                    {
                        Nombre = qry.Nombre,
                        TipoDocumentoId = qry.ID_TipoDocumento
                    }).ToList();
        }
    }
}
