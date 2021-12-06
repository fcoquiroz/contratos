using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
//using mer.monitor.shared.response;
//using mer.monitor.shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Commands
{
    /// <summary>
    /// CreateContractCommand
    /// </summary>
    public class CreateContractCommand : IRequest<ResponseT<CreateContractResponse>>
    {
        /// <summary>
        /// CreateContractCommand
        /// </summary>
        /// <param name="request"></param>
        public CreateContractCommand(CreateContractRequest request)
        {
            Name = request.Name;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

    }
}
