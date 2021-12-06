using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using scontracts.Shared.Requests;
using Repository.Core.Domain;
using scontracts.Shared.DTO;

namespace scontracts.Api.Mediator.Commands
{
    /// <summary>
    /// LogCreateCommand
    /// </summary>
    public class LogCreateCommand : IRequest<ResponseT<LogCreateResponse>>
    {
        /// <summary>
        /// LogCreateCommand constructor para inyeccion de dependencias
        /// </summary>
        public LogCreateCommand(LogCreateRequest request)
        {
            UserName = request.UserName;
            Path = request.Path;
            Control = request.Control;
            Message = request.Message;            
        }
        /// <summary>
        /// UserName
        /// </summary>
        #region Log
        public string UserName { get; set; }
        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Control
        /// </summary>
        public string Control { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
        #endregion
    }
}
