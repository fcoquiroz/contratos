using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Repository.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

using scontracts.Shared.Responses;
using scontracts.Shared.DTO;
using scontracts.Api.Mediator.Queries;
using Repository.Core.Domain;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// UserGetByNameHandler
    /// </summary>
    public class UserGetByNameHandler : IRequestHandler<UserByNameQuery, ResponseT<UserGetByNameResponse>>
    {
        /// <summary>
        /// _logger
        /// </summary>
        private readonly ILogger<UserGetByNameHandler> _logger;

        /// <summary>
        /// UserGetByNameHandler
        /// </summary>
        /// <param name="logger"></param>
        public UserGetByNameHandler(ILogger<UserGetByNameHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<UserGetByNameResponse>> Handle(UserByNameQuery request, CancellationToken cancellationToken)
        {

            ResponseT<UserGetByNameResponse> res = new ResponseT<UserGetByNameResponse>();
            try
            {
                Cat_Usuario UserData = new Cat_Usuario();

                 using (var unitofwork = new UnitOfWork(new DataContext()))
                    UserData = unitofwork.Cat_UsuarioRoutines.GetUserByName(request.Username);

                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), new UserGetByNameResponse
                {
                    UserId = UserData.ID_Usuario,

                    //Email = UserData.Correo
                });

            }
            catch (Exception ex)
            {

                res.update(StatusCodes.Status500InternalServerError, ex.Message, default);
            }

            return res;
         }

        }
}