using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_MultiProductoRepository : IRepository<TB_MultiProducto>
    {
        /// <summary>
        /// ObtenerMultiProductos
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        List<ProductosDTO> ObtenerMultiProductos(long ID_Contrato);
        /// <summary>
        /// GuardarAutorizadoresMultiProducto
        /// </summary>
        /// <param name="command"></param>
        void GuardarAutorizadoresMultiProducto(ManagementCoverCommand command);
        /// <summary>
        /// ObtenerMultiProductoParaCorreoAutorizador
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        List<ProductosDTO> ObtenerMultiProductoParaCorreoAutorizador(long ID_Contrato);
    }
}
