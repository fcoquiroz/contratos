using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mediator.Queries
{
    public class CoverDataGetQuery : CoverDataGetRequest, IRequest<ResponseT<CoverDataGetResponse>>
    {
        public CoverDataGetQuery(CoverDataGetRequest request)
        {
            
            this.ID_Contrato = request.ID_Contrato;
            this.ID_Usuario_Envio = request.ID_Usuario_Envio;

        }
    }
}
