using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{

    public class UserTokenResponse
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// TokenType
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// ExpiresIn
        /// </summary>
        [JsonProperty("expires_In")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }


        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        
    }

}
