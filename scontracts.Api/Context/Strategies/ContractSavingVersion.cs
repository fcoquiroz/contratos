using App.Contratos.DAL.Enums;
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
    /// ContractSavingVersion
    /// </summary>
    public class ContractSavingVersion : IContractSave
    {
        
        /// <summary>
        /// Save - Implementación de estrategia para guardar datos Contrato Version
        /// </summary>
        /// <returns></returns>
        public ContractCreateResponse Save(ContractCreateCommand command)
        {
            ContractCreateResponse res = new ContractCreateResponse();
            TB_Contratos_Versiones dto = new TB_Contratos_Versiones();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                if (!command.EsBorrador)
                {
                    dto = new TB_Contratos_Versiones
                    {
                        ID_Contrato = command.ID_Contrato,
                        FechaCreacion = DateTime.Now,
                        ID_UsuarioEnvio = command.ID_UsuarioEnvio,
                        ID_TipoAccion = command.ID_TipoAccion, //0 /// aqui se pone si es borrador o es envio este valor lo mandaran al consumir el api
                        Comentarios = command.Comentarios, //solo se llega lleno cuando es envio
                        Version = command.Version,
                        NombreContrato = command.NombreContrato,
                        Extension = command.Extension,
                        ContenttType = command.ContenttType
                    };
                    unitofwork.TB_Contratos_VersionesRoutines.Add(dto);
                }
                else
                {
                    dto = unitofwork.TB_Contratos_VersionesRoutines.Single(o => o.ID_Contrato == command.ID_Contrato);
                    dto.FechaCreacion = DateTime.Now;
                    dto.ID_UsuarioEnvio = command.ID_UsuarioEnvio;
                    dto.ID_TipoAccion = command.ID_TipoAccion;
                    dto.Comentarios = command.Comentarios;
                    dto.Version = unitofwork.TB_Contratos_VersionesRoutines.Find(x => x.ID_Contrato == command.ID_Contrato).Count() + 1;
                    dto.NombreContrato = command.NombreContrato;
                    dto.Extension = command.Extension;
                    dto.ContenttType = command.ContenttType;
                    unitofwork.TB_Contratos_VersionesRoutines.Attach(dto);
                }
                unitofwork.Commit();
            }
            return res;


        }

    }
}
