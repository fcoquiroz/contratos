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
    /// Cat_ResponsablesRepository
    /// </summary>
    public class Cat_ResponsablesRepository : Repository<Cat_Responsables>, ICat_ResponsablesRepository
    {
        /// <summary>
        /// Cat_ResponsablesRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_ResponsablesRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }

        public List<ResponsableDTO> ObtenerResponsable()
        {
            return (from qry in consisContext.Cat_ResponsablesRoutines
                    from u in consisContext.Cat_Unidad_UsuarioRoutines
                    .Where(uu => uu.ID_UnidadUsuario == qry.ID_UnidadUsuario).DefaultIfEmpty()
                    where qry.Activo == true 
                    orderby qry.Nombre
                    select new ResponsableDTO
                    {
                        ResponsableId = qry.ID_Responsable,
                        Nombre = qry.Nombre == null? "": qry.Nombre,
                        UnidadUsuarioId =int.Parse(qry.ID_UnidadUsuario.ToString() ?? "0"),
                        UsuarioRegistroId = int.Parse(qry.ID_Usuario_Registro.ToString() ?? "0"),
                        Cargo = qry.Cargo == null? "": qry.Cargo,
                        Telefono = qry.Telefono == null? "": qry.Telefono

                    }).ToList();
        }
    }
}
