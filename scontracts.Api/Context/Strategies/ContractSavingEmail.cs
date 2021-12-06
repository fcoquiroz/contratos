using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Context.Behaviours;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context.Strategies
{
    /// <summary>
    /// ContractSavingEmail
    /// </summary>
    public class ContractSavingEmail : Constants, IContractSave
    {
        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public ContractCreateResponse Save(ContractCreateCommand command)
        {

            ContractCreateResponse res = new ContractCreateResponse();

            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                TB_Contratos_Email dto = new TB_Contratos_Email
                {
                    Asunto = Asunto,
                    ID_Contrato = command.ID_Contrato,
                    ID_Correo = ID_Correo,
                    Body = command.Body,
                    Destinatarios = command.Destinatarios,
                    FechaGeneroCorreo = DateTime.Now
                };

                if (!Validate(dto))
                {
                    unitofwork.TB_Contratos_EmailRoutines.Add(dto);
                    unitofwork.Commit();
                }
            }
            return res;

        }
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public bool Validate(TB_Contratos_Email ce)
        {
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                var cm = unitofwork.TB_Contratos_EmailRoutines.Find(x => x.ID_Contrato == ce.ID_Contrato &&
                                                            x.ID_Correo == ce.ID_Correo &&
                                                            x.Enviado != true).OrderByDescending(x => x.ID_Contrato_Email).FirstOrDefault();
                unitofwork.Commit();

                if (cm != null)
                    return true;
                else
                    return false;

            }
        }
    }



}
