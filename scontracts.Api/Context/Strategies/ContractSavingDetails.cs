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

    /// <summary>
    /// ContractSavingDetails
    /// </summary>
    public class ContractSavingDetails : IContractSave
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public ContractCreateResponse Save(ContractCreateCommand command)
        {
          
            ContractCreateResponse res = new ContractCreateResponse();
            TB_Contratos_Detalle detallesDto = new TB_Contratos_Detalle();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                if (!command.EsBorrador)
                {

                    detallesDto = new TB_Contratos_Detalle
                    {
                        ID_Contrato = command.ID_Contrato,
                        ObjetoNegociacion = command.Objeto,
                        DescServiciosProductos = command.Descripcion,
                        Contraprestacion = command.Contraprestacion,
                        FormaPago = command.FechaPago,
                        Vigencia = command.Vigencia,
                        LugarFechaFirma = command.LugarFechaFirma,
                        CondicionesEspeciales = command.Condiciones
                    };
                    unitofwork.TB_Contratos_DetalleRoutines.Add(detallesDto);
                }
                else
                {
                    detallesDto = unitofwork.TB_Contratos_DetalleRoutines.Single(o => o.ID_Contrato == command.ID_Contrato);
                   
                    detallesDto.ObjetoNegociacion = command.Objeto;
                    detallesDto.DescServiciosProductos = command.Descripcion;
                    detallesDto.Contraprestacion = command.Contraprestacion;
                    detallesDto.FormaPago = command.FechaPago;
                    detallesDto.Vigencia = command.Vigencia;
                    detallesDto.LugarFechaFirma = command.LugarFechaFirma;
                    detallesDto.CondicionesEspeciales = command.Condiciones;
                    unitofwork.TB_Contratos_DetalleRoutines.Attach(detallesDto);
                }

                unitofwork.Commit();
               
            }
            return res;

        }
    }
}
