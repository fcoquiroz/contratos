
using Newtonsoft.Json;
using System.Collections.Generic;

namespace scontracts.Shared.Requests
{
   public class UserTokenRequest { 

        [JsonProperty("UserName")]
        public string UserName { get; set; }
        //
        // Resumen:
        //     Resource owner password.
        [JsonProperty("Password")]
        public string Password { get; set; }
        /// <summary>
        /// Grant_Type
        /// </summary>
        [JsonProperty("grant_type")]
        public string Grant_Type { get; set; }       
    }
}
