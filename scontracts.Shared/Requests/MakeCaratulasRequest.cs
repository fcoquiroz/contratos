using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace scontracts.Shared.Requests
{
    public class MakeCaratulasRequest
    {
        /// <summary>
        /// ID_Contrato
        /// </summary>
        [JsonProperty("ID_Contrato")]
        public long IDContrato { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        [JsonProperty("Token")]
        public string Token { get; set; }

        /// <summary>
        /// IDUsuario
        /// </summary>
        [JsonProperty("ID_Usuario")]
        public long IDUsuario { get; set; }
        /// <summary>
        /// EsAbogado
        /// </summary>
        [JsonProperty("EsAbogado")]
        public bool EsAbogado { get; set; }
    }
}
