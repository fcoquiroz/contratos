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
using scontracts.Api.Mediator.Commands;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// Cat_ProveedorRepository
    /// </summary>
    public class Cat_ProveedorRepository : Repository<Cat_Proveedor>, ICat_ProveedorRepository
    {
        /// <summary>
        /// Cat_ProveedorRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_ProveedorRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// obtengo la lista de Proveedores activa para llenar los combos de la pantalla
        /// </summary>
        /// <returns></returns>
        public List<ProveedoresDto> ObtenerProveedores()
        {
            return (from qry in consisContext.Cat_ProveedorRoutines.Where(o => o.Activo == true)
                    orderby qry.Nombre
                    select new ProveedoresDto
                    {
                        Nombre = qry.Nombre,
                        ProveedorId = qry.ID_Proveedor
                    }).ToList();
        }
        public int ObtenerIDProveedor(ContractCreateCommand command)
        {
            
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                Cat_Proveedor dto = new Cat_Proveedor();
                if (command.ProveedorId > 0)
                    return command.ProveedorId;
                else
                {
                    if (!string.IsNullOrEmpty(command.Proveedor))
                    {
                        //Agrega un nuevo registro y retorna el ID
                        var f = unitofwork.Cat_ProveedorRoutines.Find(x => x.Nombre.ToUpper().Trim() == command.Proveedor.ToUpper().Trim()).FirstOrDefault();
                        if (f != null)
                            return f.ID_Proveedor;
                        else
                        {
                            dto = new Cat_Proveedor
                            {
                                Nombre = command.Proveedor.ToUpper().Trim(),
                                Activo = true
                            };


                            unitofwork.Cat_ProveedorRoutines.Add(dto);
                            unitofwork.Commit();
                            return dto.ID_Proveedor;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
