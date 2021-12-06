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
    /// SolicitudGetQuery
    /// </summary>
    public class SolicitudGetQuery : IRequest<ResponseT<SolicitudGetResponse>>
    {
        /// <summary>
        /// IdContrato
        /// </summary>
        public long IdContrato { get; set; }
        /// <summary>
        /// SolicitudGetQuery
        /// </summary>
        /// <param name="IdContrato"></param>
        public SolicitudGetQuery(long IdContrato)
        {
            this.IdContrato = IdContrato;
        }
    }
}
