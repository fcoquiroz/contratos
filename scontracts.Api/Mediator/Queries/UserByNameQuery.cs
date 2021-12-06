using MediatR;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Queries
{
    /// <summary>
    /// UserByNameQuery
    /// </summary>
    public class UserByNameQuery : IRequest<ResponseT<UserGetByNameResponse>>
    {
        /// <summary>
        /// UserByNameQuery
        /// </summary>
        /// <param name="username"></param>
        public UserByNameQuery(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

    }
}
