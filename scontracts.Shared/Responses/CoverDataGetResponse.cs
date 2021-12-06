using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    public class CoverDataGetResponse
    {
        public List<CoverDataGetDTO> ObtenerCamposCaratula { get; set; }
        public List<CoverDetalleDataGetDTO> ObtenerDetalleCaratula { get; set; }
        /// <summary>
        /// idNuevo
        /// </summary>
        public int idNuevo { get; set; }
        public List<BuscarAutorizadoresPorContratoDTO> ListBuscarAutorizadoresPorContrato { get; set; }
        /// <summary>
        /// ListUsuario
        /// </summary>
        public List<UsuarioDTO> ListUsuario { get; set; }
        /// <summary>
        /// ObtenerTipoAutorizador
        /// </summary>
        public List<TipoAutorizadorDTO> ObtenerTipoAutorizador { get; set; }
        /// <summary>
        /// ListaPaises
        /// </summary>
        public List<PaisesDTO> ListaPaises { get; set; }
        /// <summary>
        /// ListaTipoContraparte
        /// </summary>
        public List<TipoContraparteDTO> ListaTipoContraparte { get; set; }
        /// <summary>
        /// ListaProductos
        /// </summary>
        public List<ProductosDTO> ListaProductos { get; set; }
        /// <summary>
        /// ID_Pais
        /// </summary>
        public int? ID_Pais { get; set; }
        /// <summary>
        /// ID_TipoCaratula
        /// </summary>
        public int? ID_TipoCaratula { get; set; }

    }
}
