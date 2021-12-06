using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    public class ReleasedDocsQuery : ReleasedDocsRequest, IRequest<ResponseT<ReleasedDocsResponse>>
    {
        /// <summary>
        /// ReleasedDocsQuery
        /// </summary>
        /// <param name="request"></param>
        /// 

        public ReleasedDocsQuery(ReleasedDocsRequest request)
        {
            this.IdUsuario = request.IdUsuario;
            this.IdUnidadUsuario = request.IdUnidadUsuario;
        }
    }
}
