using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{

    public class RelatedContractsQuery : RelatedContractsRequest, IRequest<ResponseT<ParentContractsResponse>>
    {
        /// <summary>
        /// ParentContractsQuery
        /// </summary>
        /// <param name="request"></param>
        /// 

        public RelatedContractsQuery(RelatedContractsRequest request)
        {
            this.IdUsuario = request.IdUsuario;
            this.IdContratoPadre = request.IdContratoPadre;
        }
    }
}
