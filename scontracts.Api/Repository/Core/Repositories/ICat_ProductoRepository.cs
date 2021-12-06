using Repository.Core.Domain;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ICat_ProductoRepository : IRepository<Cat_Producto>
    {
        List<ProductosDTO> ObtenerProductos();
        void InsertXProducto(int id_contrato);
    }
}
