using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Responses
{
    /// <summary>
    /// ContractsDataGetResponse
    /// </summary>
    public class ContractsDataGetResponse
    {
        /// <summary>
        /// RutaDocumentos
        /// </summary>
        public string RutaDocumentos { get; set; }
        /// <summary>
        /// ListaPrioridades
        /// </summary>
        public List<PrioridadesDTO> ListaPrioridades { get; set; }
        /// <summary>
        /// ListaIdiomas
        /// </summary>
        public List<IdiomasDTO> ListaIdiomas { get; set; }
        /// <summary>
        /// ListaTipoDocumentos
        /// </summary>
        public List<TipoDocumentoDTO> ListaTipoDocumentos { get; set; }
        /// <summary>
        /// ListaUnidades
        /// </summary>
        public List<UnidadesDTO> ListaUnidades { get; set; }
        /// <summary>
        /// ListaProveedores
        /// </summary>
        public List<ProveedoresDto> ListaProveedores { get; set; }
        /// <summary>
        /// ListaTipoMoneda
        /// </summary>
        public List<TipoMonedaDTO> ListaTipoMoneda { get; set; }
        /// <summary>
        /// ListaResponsable
        /// </summary>
        public List<ResponsableDTO> ListaResponsable { get; set; }
        /// <summary>
        /// ListaUnidadResponsable
        /// </summary>
        public List<UnidadesResponsableDTO> ListaUnidadResponsable { get; set; }
        /// <summary>
        /// noError
        /// </summary>
        public Nullable<int> noError { get; set; }
        /// <summary>
        /// descError
        /// </summary>
        public string descError { get; set; }
        /// <summary>
        /// ID_Responsable
        /// </summary>
        public Nullable<int> ID_Responsable { get; set; }
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

    }
}
