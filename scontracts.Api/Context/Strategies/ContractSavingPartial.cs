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
    /// ContractSavingPartial
    /// </summary>
    public class ContractSavingPartial : IContractSave
    {

        /// <summary>
        /// Save - Implementación de estrategia para guardar datos generales de la solicitud de contrato (Tabla Padre)
        /// </summary>
        /// <returns></returns>
        public ContractCreateResponse Save(ContractCreateCommand command) 
        {
            TB_Contratos dto = new TB_Contratos();
            ContractCreateResponse res =  new ContractCreateResponse();
            
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                if (!command.EsBorrador)
                {
                    dto = new TB_Contratos
                    {
                        idIdioma = command.IdiomaId,
                        ID_Estatus = command.ID_Estatus,
                        ID_Moneda = command.MonedaId,
                        ID_Prioridad = command.PrioridadId,
                        ID_Proveedor = command.ProveedorId,
                        ID_Responsable = command.Responsable.ResponsableId,
                        ID_Solicitante = command.SolicitanteId,
                        ID_TipoDocumento = command.TipoDocumento,
                        ID_TipoSolicitud = command.ID_TipoSolicitud,
                        ID_Unidad = command.UnidadId,
                        ID_UnidadUsuario = command.ID_UnidadUsuario,
                        ElaboracionContrato = command.EnElaboracion,
                        FechaSolicitud = DateTime.Now,
                        IdTipoSolicitud = command.IdTipoSolicitud,
                        IDPais = command.IDPais,
                        ID_ContratoPadre = command.ID_ContratoPadre,
                        ID_FormatoLiberado = command.ID_FormatoLiberado,
                        EsLiberado = command.EsLiberado
                    };


                    unitofwork.TB_ContratosRoutines.Add(dto);
                }
                else
                {

                    dto = unitofwork.TB_ContratosRoutines.Single(o => o.ID_Contrato == command.ID_Contrato);
                    dto.idIdioma = command.IdiomaId;
                    dto.ID_Estatus = command.ID_Estatus;
                    dto.ID_Moneda = command.MonedaId;
                    dto.ID_Prioridad = command.PrioridadId;
                    dto.ID_Proveedor = command.ProveedorId;
                    dto.ID_Responsable = command.Responsable.ResponsableId;
                    dto.ID_Solicitante = command.SolicitanteId;
                    dto.ID_TipoDocumento = command.TipoDocumento;
                    dto.ID_TipoSolicitud = command.ID_TipoSolicitud;
                    dto.ID_Unidad = command.UnidadId;
                    dto.ID_UnidadUsuario = command.ID_UnidadUsuario;
                    dto.ElaboracionContrato = command.EnElaboracion;
                    dto.FechaSolicitud = DateTime.Now;
                    dto.IdTipoSolicitud = command.IdTipoSolicitud;
                    dto.IDPais = command.IDPais;
                    dto.ID_ContratoPadre = command.ID_ContratoPadre;
                    dto.ID_FormatoLiberado = command.ID_FormatoLiberado;
                    dto.EsLiberado = command.EsLiberado;
                    unitofwork.TB_ContratosRoutines.Attach(dto);
                }
                unitofwork.Commit();
                res.ID_Contrato = dto.ID_Contrato;
            }


            return res;


        }

    }
}
