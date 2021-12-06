using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Requests
{
   public class UserAuthRequest
    {
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
    }
}
