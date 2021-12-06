using MediatR;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    /// <summary>
    /// RefreshUserTokenQuery
    /// </summary>
    public class UserRefreshTokenQuery : IRequest<ResponseT<UserRefreshResponse>>
    {

        /// <summary>
        /// RefreshUserTokenQuery
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="accessToken"></param>
        /// <param name="secret"></param>
        /// <param name="iss"></param>
        /// <param name="aud"></param>
        public UserRefreshTokenQuery(string refreshToken, string accessToken, string secret, string iss, string aud)
        {
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            Secret = secret ?? throw new ArgumentNullException(nameof(secret));
            Iss = iss ?? throw new ArgumentNullException(nameof(iss));
            Aud = aud ?? throw new ArgumentNullException(nameof(aud));
        }

        /// <summary>
        /// RefreshToken
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Iss
        /// </summary>
        public string Iss { get; set; }

        /// <summary>
        /// Aud
        /// </summary>
        public string Aud { get; set; }
    }
}
