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
    /// Cat_Unidad_UsuarioRepository
    /// </summary>
    public class Cat_Unidad_UsuarioRepository : Repository<Cat_Unidad_Usuario>, ICat_Unidad_UsuarioRepository
    {
        /// <summary>
        /// Cat_Unidad_UsuarioRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_Unidad_UsuarioRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UnidadesResponsableDTO> ObtenerUnidadesResponsable()
        {
            return (from qry in consisContext.Cat_Unidad_UsuarioRoutines
                    orderby qry.Nombre
                    select new UnidadesResponsableDTO
                    {
                        Nombre = qry.Nombre,
                        UnidadResponsableId = qry.ID_UnidadUsuario
                    }).ToList();
        }
    }
}
