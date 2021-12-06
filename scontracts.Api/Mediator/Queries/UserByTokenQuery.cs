using MediatR;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    /// <summary>
    /// UserByTokenQuery
    /// </summary>
    public class UserByTokenQuery : IRequest<ResponseT<UserRefreshResponse>>
    {

        /// <summary>
        /// UserByTokenQuery
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="secret"></param>
        /// <param name="iss"></param>
        /// <param name="aud"></param>
        public UserByTokenQuery(string accessToken, string secret, string iss, string aud)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            Secret = secret ?? throw new ArgumentNullException(nameof(secret));
            Iss = iss ?? throw new ArgumentNullException(nameof(iss));
            Aud = aud ?? throw new ArgumentNullException(nameof(aud));
        }

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
