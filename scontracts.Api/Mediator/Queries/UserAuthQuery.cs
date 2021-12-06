using MediatR;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    /// <summary>
    /// UserAuthQuery
    /// </summary>
    public class UserAuthQuery : IRequest<ResponseT<UserAuthResponse>>
    {
        /// <summary>
        /// UserAuthQuery
        /// </summary>
        /// <param name="request"></param>
        /// <param name="secret"></param>
        /// <param name="iss"></param>
        /// <param name="aud"></param>
        public UserAuthQuery(UserAuthRequest request, string secret, string iss, string aud)
        {
            Username = request.Username;
            Password = request.Password;
            this.Secret = secret;
            this.Iss = iss;
            this.Aud = aud;
           
        }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

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
