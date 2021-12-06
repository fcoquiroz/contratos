using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class Cat_ProductoRepository : Repository<Cat_Producto>, ICat_ProductoRepository
    {
        /// <summary>
        /// Cat_ProductoRepository
        /// </summary>
        /// <param name="_context"></param>
        public Cat_ProductoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }
        /// <summary>
        /// ObtenerProductos
        /// </summary>
        /// <returns></returns>
        public List<ProductosDTO> ObtenerProductos()
        {
            
            return (from qry in consisContext.Cat_ProductoRoutines.Where(o => o.Activo == true)
                    select new ProductosDTO
                    {
                        ProductoId = qry.Id_Producto,
                        Nombre = qry.Descripcion
                    }).ToList();

        
        }
        public void InsertXProducto(int id_contrato)
        {
            using (var db = new DataContext())
            {
                //var producto = db.TB_MultiProducto.Where(x => x.ID_Contrato == id_contrato && x.Activo == true).Select(x=>x.ID_Producto).ToList();
                var producto = (from m in db.TB_MultiProductoRoutines
                                join p in db.Cat_ProductoRoutines on m.ID_Producto equals p.Id_Producto
                                where m.ID_Contrato == id_contrato && m.Activo == true
                                select new
                                {
                                    descripcion = p.Descripcion
                                }
                                ).ToList();
                var proConcatendo = "";
                for (int i = 0; i < producto.Count(); i++)
                {
                    if (producto.Count > 1)
                    {
                        proConcatendo += producto[i].descripcion + ",";
                    }
                    else
                    {
                        proConcatendo += producto[i].descripcion;
                    }

                }
                var c = db.TB_ContratosRoutines.Find((long)id_contrato);
                var numerCampo = db.TB_Campos_CaratulaRoutines.Where(x => x.Id_Caratula == c.IdTipoSolicitud && x.KeyCampo == "Producto").FirstOrDefault();
                var proInsertar = new TB_Detalle_Caratula()
                {
                    Id_Campo = numerCampo.Id_Campo,
                    Id_Contrato = id_contrato,
                    Valor = proConcatendo
                };
                db.TB_Detalle_CaratulaRoutines.Add(proInsertar);

                db.SaveChanges();
            }

        }

    }
}
