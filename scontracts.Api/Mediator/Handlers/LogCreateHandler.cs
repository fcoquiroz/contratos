using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;
using scontracts.Shared.DTO;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// LogCreateHandler
    /// </summary>
    public class LogCreateHandler : IRequestHandler<LogCreateCommand, ResponseT<LogCreateResponse>>

    {

        /// <summary>
        /// _logger
        /// </summary>
        private readonly ILogger<LogCreateHandler> _logger;
        /// <summary>
        /// _env
        /// </summary>
        private readonly IWebHostEnvironment _env;
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// logger
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public LogCreateHandler(ILogger<LogCreateHandler> logger, IConfiguration configuration, IWebHostEnvironment env)
        {
            _logger = logger;
            Configuration = configuration;
            _env = env;
        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<LogCreateResponse>> Handle(LogCreateCommand command, CancellationToken cancellationToken)
        {

            ResponseT<LogCreateResponse> res = new ResponseT<LogCreateResponse>();
            //Guardado del log
            try
            {
                new ContractContext(new ContractLogginData()).SaveLog(command);


                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), new LogCreateResponse());

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new LogCreateResponse());
            }
            return res;

        }


    }

}
