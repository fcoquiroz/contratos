using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
    /// <summary>
    /// UserRefreshTokenRequest
    /// </summary>
    public class UserRefreshTokenRequest
    {
        /// <summary>
        /// RefreshToken
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }
    }
}
