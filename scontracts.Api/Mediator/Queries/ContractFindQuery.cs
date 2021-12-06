using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    /// <summary>
    /// Rol
    /// </summary>
    public class ContractFindQuery : ContractFindRequest,  IRequest<ResponseT<ContractFindResponse>>
    {
        /// <summary>
        /// ContractFindQuery
        /// </summary>
        /// <param name="request"></param>
        public ContractFindQuery(ContractFindRequest request)
        {
            this.Rol = request.Rol;
            this.UserId = request.UserId;
            this.EstatusId = request.EstatusId;
        }
    }
}
