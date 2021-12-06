using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    public class TemplateDocsQuery : TemplateDocsRequest, IRequest<ResponseT<TemplateDocsResponse>>
    {
        /// <summary>
        /// ParentContractsQuery
        /// </summary>
        /// <param name="request"></param>
        /// 

        public TemplateDocsQuery(TemplateDocsRequest request)
        {
            this.IdUsuario = request.IdUsuario;
            this.IdDocumento = request.IdDocumento;
            this.IdContrato = request.IdContrato;
        }
    }
}
