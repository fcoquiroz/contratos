using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// UserByTokenRequest
    /// </summary>
    public class UserByTokenRequest
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }
    }
}
