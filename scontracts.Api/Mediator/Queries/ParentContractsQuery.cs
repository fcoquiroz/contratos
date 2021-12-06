using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    public class ParentContractsQuery : ParentContractsRequest, IRequest<ResponseT<ParentContractsResponse>>
    {
        /// <summary>
        /// ParentContractsQuery
        /// </summary>
        /// <param name="request"></param>
        /// 

        public ParentContractsQuery(ParentContractsRequest request)
        {
            this.IdEmpresa = request.IdEmpresa;
            this.IdContraparte = request.IdContraparte;
            this.IdUsuario = request.IdUsuario;
            this.IdUnidadUsuario = request.IdUnidadUsuario;
        }
    }
}
