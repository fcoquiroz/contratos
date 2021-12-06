using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Core.Repositories
{
    public interface ITB_Autorizadores_ContratoRepository : IRepository<TB_Autorizadores_Contrato>
    {
        /// <summary>
        /// GuardarAutorizadoresContrato
        /// </summary>
        /// <param name="ID_Contrato"></param>
        void GuardarAutorizadoresContrato(long ID_Contrato);
        /// <summary>
        /// GuardarAutorizadoresContratoCorreo
        /// </summary>
        /// <param name="command"></param>
        void GuardarAutorizadoresContratoCorreo(ManagementCoverCommand command);
        /// <summary>
        /// EliminarAutorizadoresContrato
        /// </summary>
        /// <param name="command"></param>
        void EliminarAutorizadoresContrato(ManagementCoverCommand command);
    }
}
