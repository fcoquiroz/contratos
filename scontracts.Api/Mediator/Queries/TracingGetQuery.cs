using MediatR;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    public class TracingGetQuery : IRequest<ResponseT<TracingGetResponse>>
    {/// <summary>
     /// IdContrato
     /// </summary>
        public long Id_Contrato { get; set; }

        public TracingGetQuery(long Id_Contrato)
        {
            this.Id_Contrato = Id_Contrato;
        }
    }
}
