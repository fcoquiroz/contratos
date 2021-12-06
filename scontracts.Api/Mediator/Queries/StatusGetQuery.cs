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
    /// StatusGetQuery
    /// </summary>
    public class StatusGetQuery : StatusGetRequest, IRequest<ResponseT<StatusGetResponse>>
    {
        /// <summary>
        /// StatusGetQuery
        /// </summary>
        /// <param name="request"></param>
        public StatusGetQuery(StatusGetRequest request)
        {
            this.Rol = request.Rol;
            this.ID_Usuario = request.ID_Usuario;
        }
    }
}
