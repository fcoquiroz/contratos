using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Commands
{
    /// <summary>
    /// FileDeleteCommand
    /// </summary>
    public class FileDeleteCommand : FileDeleteRequest, IRequest<ResponseT<FileDeleteResponse>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public FileDeleteCommand(FileDeleteRequest request)
        {
            this.id_archivo = request.id_archivo;
        }
    }
}
