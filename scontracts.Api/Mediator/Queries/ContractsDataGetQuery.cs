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
    /// ContractsDataGetQuery
    /// </summary>
    public class ContractsDataGetQuery : IRequest<ResponseT<ContractsDataGetResponse>>
    {
        /// <summary>
        /// ContractsDataGetQuery
        /// </summary>
        /// <param name="UserName"></param>
        public ContractsDataGetQuery(String UserName, int IdUser)
        {
            this.UserName = UserName;
            this.IdUser = IdUser;
        }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
        public int IdUser { get; set; }
    }
}
