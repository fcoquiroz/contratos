using MediatR;
using scontracts.Api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// UserByTokenHandler
    /// </summary>
    public class UserByTokenHandler : CtoTokens, IRequestHandler<UserByTokenQuery, ResponseT<UserRefreshResponse>>
    {

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<UserRefreshResponse>> Handle(UserByTokenQuery request, CancellationToken cancellationToken)
        {
            ResponseT<UserRefreshResponse> res = new ResponseT<UserRefreshResponse>();

            try
            {

                UserDTO user = await GetUserFromAccessToken(request.Secret, request.AccessToken, request.Aud, request.Iss);

                if (user != null)
                {
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), new UserRefreshResponse(user));
                }
                else
                    res.update(StatusCodes.Status404NotFound, ReasonPhrases.GetReasonPhrase(StatusCodes.Status404NotFound), default);
                

            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, default);

            }
            return res;
        }



    }
}
