using Repository.Core.Domain;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Email_Supervisor_ContratoRepository : IRepository<TB_Email_Supervisor_Contrato>
    {
        void ManipularCorreosSupervisores(ContractCreateCommand command, bool existe1, bool existe2);
        void AsignarEmailSupervisor(ContractCreateCommand command);
        List<EmailSupervisorContratoDTO> ObtenerEmailSupervisorContrato(long ID_Contrato);
    }
}
