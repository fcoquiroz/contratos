using Repository.Core.Domain;
using Repository.Core.Repositories;
using Repository.Persistence.Repositories;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class Cat_IdiomaUsuarioRepository : Repository<Cat_IdiomaUsuario>, ICat_IdiomaUsuarioRepository
    {
        /// <summary>
        /// Cat_UsuarioRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_IdiomaUsuarioRepository(DataContext _context) : base(_context) { }

        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        /// <summary>
        /// obtengo la lista de idiomas activa para llenar los combos de la pantallas
        /// </summary>
        /// <returns></returns>
        public List<IdiomaUsuarioDTO> ObtenerIdiomaUsuario()
        {
            return (from qry in consisContext.cat_IdiomaUsuarioRoutines
                    orderby qry.Descripcion
                    select new IdiomaUsuarioDTO
                    {
                        ID_Idioma = qry.ID_Idioma,
                        Descripcion = qry.Descripcion,
                        Nomenclatura = qry.Nomenclatura
                    }).ToList();
        }

    }
}
