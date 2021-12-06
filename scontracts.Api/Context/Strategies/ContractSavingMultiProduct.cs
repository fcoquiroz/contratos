using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Context.Behaviours;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context.Strategies
{
    public class ContractSavingMultiProduct : IContractSave
    {
        public ContractCreateResponse Save(ContractCreateCommand command)
        {
            ContractCreateResponse res = new ContractCreateResponse();
            TB_MultiProducto dto = new TB_MultiProducto();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                var ProductosDesactivar = unitofwork.TB_MultiProductoRoutines.Find(x => x.Activo == true && x.ID_Contrato == command.ID_Contrato && !command.MultiProducto.Contains(x.ID_Producto.Value));

                foreach (var des in ProductosDesactivar)
                {
                    dto = unitofwork.TB_MultiProductoRoutines.Single(o => o.ID_Contrato == command.ID_Contrato && o.ID_Producto == des.ID_Producto);
                    dto.Activo = false;
                    unitofwork.TB_MultiProductoRoutines.Attach(dto);
                    unitofwork.Commit();
                }
                var ProductosExistente = unitofwork.TB_MultiProductoRoutines.Find(x => x.Activo == true && x.ID_Contrato == command.ID_Contrato).Select(x => x.ID_Producto);

                var nuevosProductos = command.MultiProducto.Where(x => !ProductosExistente.Contains(x));

                foreach (var idProd in nuevosProductos)
                {
                    dto = new TB_MultiProducto
                    {
                        ID_Producto = idProd,
                        Activo = true,
                        ID_Contrato = command.ID_Contrato
                    };
                    unitofwork.TB_MultiProductoRoutines.Add(dto);
                    unitofwork.Commit();
                }
            }

            return res;
        }
    }
}
