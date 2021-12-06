using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;

namespace Repository.Core.Repositories
{
    /// <summary>
    /// ICat_ProveedorRepository
    /// </summary>
    public interface ICat_ProveedorRepository : IRepository<Cat_Proveedor>
    {
        /// <summary>
        /// ObtenerProveedores
        /// </summary>
        /// <returns></returns>
        List<ProveedoresDto> ObtenerProveedores();
        int ObtenerIDProveedor(ContractCreateCommand command);
    }
}
