using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace scontracts.Shared.Responses
{
  public class ReporteLiberadoResponse
    {
        /// <summary>
        /// Resultado
        /// </summary>
        [JsonProperty("Resultado")]
        public bool Resultado { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        [JsonProperty("Mensaje")]
        public string Mensaje { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

    }
}
