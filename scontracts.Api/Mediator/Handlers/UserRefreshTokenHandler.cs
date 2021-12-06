using MediatR;
using scontracts.Api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Repository.Persistence;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    /// <summary>
    /// UserRefreshTokenHandler
    /// </summary>
    public class UserRefreshTokenHandler : CtoTokens, IRequestHandler<UserRefreshTokenQuery, ResponseT<UserRefreshResponse>>
    {

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<UserRefreshResponse>> Handle(UserRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            ResponseT<UserRefreshResponse> res = new ResponseT<UserRefreshResponse>();

            try
            {
                UserDTO user = await GetUserFromAccessToken(request.Secret, request.AccessToken,request.Aud, request.Iss);

                if (user != null && await ValidateRefreshToken(user, request.RefreshToken))
                {
                    UserRefreshResponse userWithToken = new UserRefreshResponse(user);
                    userWithToken.AccessToken = GenerateAccessToken(request.Secret, user.UserId, request.Aud, request.Iss); 
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK), userWithToken); 
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
