using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_MultiProductoRepository : Repository<TB_MultiProducto>, ITB_MultiProductoRepository
    {
        public TB_MultiProductoRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// ObtenerProductos
        /// </summary>
        /// <returns></returns>
        public List<ProductosDTO> ObtenerMultiProductos(long ID_Contrato)
        {
            int[] seleccionados = { };


            seleccionados = (from sl in consisContext.TB_MultiProductoRoutines
                             where sl.Activo == true && sl.ID_Contrato == ID_Contrato
                             select sl.ID_Producto.Value).ToArray();



            List<ProductosDTO> lista = (from pr in consisContext.Cat_ProductoRoutines
                                        where pr.Activo == true
                                        select new ProductosDTO
                                        {
                                            ProductoId = pr.Id_Producto,
                                            Nombre = pr.Descripcion,
                                            Seleccionado = (seleccionados.Contains(pr.Id_Producto)) ? "true" : "false"
                                        }).ToList();
            return lista;
        }
        /// <summary>
        /// GuardarAutorizadoresMultiProducto
        /// </summary>
        /// <param name="command"></param>
        public void GuardarAutorizadoresMultiProducto(ManagementCoverCommand command)
        {
            using (var db = new DataContext())
            {
                int multi = 0;
                using (var unitofwork = new UnitOfWork(new DataContext()))
                {
                    multi = unitofwork.TB_MultiProductoRoutines.Find(x => x.ID_Contrato == command.ID_Contrato && x.ID_Producto == command.ID_Producto).Select(x => x.ID_MultiProducto).FirstOrDefault();
                }
                if (multi == 0)
                {
                    var objMultiProducto = new TB_MultiProducto()
                    {
                        ID_Contrato = command.ID_Contrato,
                        ID_Producto = command.ID_Producto,
                        Activo = true
                    };
                    db.TB_MultiProductoRoutines.Add(objMultiProducto);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// ObtenerMultiProductoParaCorreoAutorizador
        /// </summary>
        /// <param name="ID_Contrato"></param>
        /// <returns></returns>
        public List<ProductosDTO> ObtenerMultiProductoParaCorreoAutorizador(long ID_Contrato) 
        {
        using (var db = new DataContext())
            {

                var productosSolictud = db.TB_MultiProductoRoutines.Where(x => x.ID_Contrato == ID_Contrato && x.Activo == true).ToList();
                var listProductos = new List<int>();
                foreach (var itemPro in productosSolictud)
                {
                    listProductos.Add(itemPro.ID_Producto.Value);
                }

                var producto = db.Cat_ProductoRoutines.Where(x => x.Activo == true && listProductos.Contains(x.Id_Producto)).ToList();
                List<ProductosDTO> listP = new List<ProductosDTO>();
                foreach (var item in producto)
                {
                    var prod = new ProductosDTO
                    {
                        ProductoId = item.Id_Producto,
                        Nombre = item.Descripcion
                    };
                    listP.Add(prod);
                }

                return listP;
            }
           
        }
    }
}
