using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorySP.Core.Repositories
{
    public interface IContractRepository
    {


        /// <summary>
        /// ValidarExisteResponsable
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ResponsableDTO> ValidarExisteResponsable(int userId);
        /// <summary>
        /// CalcularDiasParaEntregaDocumentos
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        Task<String> CalcularDiasParaEntregaDocumentos(int id_contrato);
        /// <summary>
        /// ActualizarTabContrato_Parameters
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <param name="id_estatus"></param>
        /// <returns></returns>
        Task<ResponsableDTO> ActualizarTabContrato_Parameters(int id_contrato, int id_estatus);
        /// <summary>
        /// CalculaFechaVencimientoAurotizacion
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        Task<ResponsableDTO> CalculaFechaVencimientoAurotizacion(int id_contrato);
        /// <summary>
        /// CalculaSeguimientoContrato
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        Task<ResponsableDTO> CalculaSeguimientoContrato(int id_contrato);
        /// <summary>
        /// CalculaFechaVencimientoParo
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        Task<ResponsableDTO> CalculaFechaVencimientoParo(int id_contrato);
        /// <summary>
        /// CalculaFechaVencimiento
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        Task<ResponsableDTO> CalculaFechaVencimiento(int id_contrato);
        /// <summary>
        /// CalculaFechaVencimientoSegundaVuelta
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        Task<ResponsableDTO> CalculaFechaVencimientoSegundaVuelta(int Id_Contrato, int Dias_Reales);

        /// <summary>
        /// GetCamposDocumento
        /// </summary>
        /// <param name="idContrato"></param>
        /// <param name="idDocumento"></param>
        /// <returns></returns>
        Task <List<CampoContratoLiberadoDTO>> GetCamposDocumento(long idContrato, int idDocumento);
        /// <summary>
        /// SpIMotivoCambioPrioridad
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <param name="prioridadAnt"></param>
        /// <param name="prioridad"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task SpIMotivoCambioPrioridad(int id_contrato, int prioridadAnt, int prioridad, int idUsuario);
        /// <summary>
        /// SpIMotivoCambioTipoContrato
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <param name="tipoContratoAnt"></param>
        /// <param name="tipoContrato"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task SpIMotivoCambioTipoContrato(int id_contrato, int? tipoContratoAnt, int? tipoContrato, int idUsuario);


        /// <summary>
        /// CargarSolicitudContrato
        /// </summary>
        /// <param name="idContrato"></param>
        /// <param name="idDocumento"></param>
        /// <returns></returns>
        Task <List<CargarSolicitudContratoDTO>> CargarSolicitudContrato(long idContrato);

        Task<List<BuscarAutorizadoresPorContratoDTO>> BuscarAutorizadoresPorContrato(long idContrato);
    }
}
