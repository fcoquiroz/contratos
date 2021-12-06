using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorySP.Core.Repositories;
using RepositorySP.Persistence.FetchConfiguration;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;

namespace RepositorySP.Persistence.Repositories
{
    /// <summary>
    /// ContractRepository
    /// </summary>
    public class ContractRepository : IContractRepository
    {
        public ContractRepository(DataSPContext _context) { _dataSPContext = _context; }
        private DataSPContext _dataSPContext;
        #region Transactional





        #endregion

        #region No Transactional

        /// <summary>
        /// ValidarExisteResponsable
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ResponsableDTO> ValidarExisteResponsable(int userId)
        {
            var command = ContractConfiguration.
                   ValidarExisteResponsable_Parameters(_dataSPContext.Command(ContractConfiguration.
                   ValidarExisteResponsable), userId);

            await using (var reader = await command.ExecuteReaderAsync())
                while (reader.Read())
                    return ContractConfiguration.Fill_ValidarExisteResponsable(reader);

            return default;
        }

        public async Task<String> CalcularDiasParaEntregaDocumentos(int id_contrato)
        {
            
            var command = ContractConfiguration.
                   CalcularDiasParaEntregaDocumentos_Parameters(_dataSPContext.Command(ContractConfiguration.
                   CalcularDiasParaEntregaDocumentos), id_contrato); 
            await using (var reader = await command.ExecuteReaderAsync())
                if (reader != null)
                    return ContractConfiguration.error(reader);
            return default;
        }

        public async Task<ResponsableDTO> ActualizarTabContrato_Parameters(int id_contrato, int id_estatus)
        {
            var command = ContractConfiguration.
                   ActualizarTabContrato_Parameters(_dataSPContext.Command(ContractConfiguration.
                   ActualizarTabContrato), id_contrato,id_estatus);
            await command.ExecuteNonQueryAsync();
           
            return default;
        }
        public async Task<ResponsableDTO> CalculaFechaVencimientoAurotizacion(int id_contrato)
        {
            var command = ContractConfiguration.
                   CalculaFechaVencimientoAurotizacion_Parameters(_dataSPContext.Command(ContractConfiguration.
                   CalculaFechaVencimientoAurotizacion), id_contrato);
            await command.ExecuteNonQueryAsync();

            return default;
        }
        /// <summary>
        /// CalculaSeguimientoContrato
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        public async Task<ResponsableDTO> CalculaSeguimientoContrato(int id_contrato)
        {
            var command = ContractConfiguration.
                   CalculaSeguimientoContrato_Parameters(_dataSPContext.Command(ContractConfiguration.
                   CalculaSeguimientoContrato), id_contrato);
            await command.ExecuteNonQueryAsync();

            return default;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        public async Task<ResponsableDTO> CalculaFechaVencimientoParo(int id_contrato)
        {
            var command = ContractConfiguration.
                   CalculaFechaVencimientoParo_Parameters(_dataSPContext.Command(ContractConfiguration.
                   CalculaFechaVencimientoParo), id_contrato);
            await command.ExecuteNonQueryAsync();

            return default;
        }
        /// <summary>
        /// CalculaFechaVencimiento
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <returns></returns>
        public async Task<ResponsableDTO> CalculaFechaVencimiento(int id_contrato)
        {
            var command = ContractConfiguration.
                   CalculaFechaVencimiento_Parameters(_dataSPContext.Command(ContractConfiguration.
                   CalculaFechaVencimiento), id_contrato);
            await command.ExecuteNonQueryAsync();

            return default;
        }
        /// <summary>
        /// CalculaFechaVencimientoSegundaVuelta
        /// </summary>
        /// <param name="id_contrato"></param>
        /// <param name="dias"></param>
        /// <returns></returns>
        public async Task<ResponsableDTO> CalculaFechaVencimientoSegundaVuelta(int Id_Contrato, int Dias_Reales)
        {
            var command = ContractConfiguration.
                  CalculaFechaVencimientoSegundaVuelta_Parameters(_dataSPContext.Command(ContractConfiguration.
                  CalculaFechaVencimientoSegundaVuelta), Id_Contrato,Dias_Reales);
            await command.ExecuteNonQueryAsync();

            return default;
        }

        /// <summary>
        /// CalculaFechaVencimientoSegundaVuelta
        /// </summary>
        /// <param name="idContrato"></param>
        /// <param name="idDocumento"></param>
        /// <returns></returns>
        public async Task<List<CampoContratoLiberadoDTO>> GetCamposDocumento(long idContrato, int idDocumento)
        {
            var command = ContractConfiguration.
                   GetCamposDocumento_Parameters(_dataSPContext.Command(ContractConfiguration.
                   GetDetalleDocumentoLiberado), idContrato, idDocumento);

            await using (var reader = await command.ExecuteReaderAsync())
                if (reader != null)
                    return ContractConfiguration.Fill_CamposDocumento(reader);

            return default;

        }

        public async Task SpIMotivoCambioPrioridad(int id_contrato, int prioridadAnt, int prioridad, int idUsuario)
        {
            var command = ContractConfiguration.
                   SpIMotivoCambioPrioridad_Parameters(_dataSPContext.Command(ContractConfiguration.
                   SpIMotivoCambioPrioridad), id_contrato, prioridadAnt, prioridad, idUsuario);
            await command.ExecuteNonQueryAsync();
        }

        public async Task SpIMotivoCambioTipoContrato(int id_contrato, int? tipoContratoAnt, int? tipoContrato, int idUsuario)
        {
            var command = ContractConfiguration.
                   SpIMotivoCambioTipoContrato_Parameters(_dataSPContext.Command(ContractConfiguration.
                   SpIMotivoCambioTipoContrato), id_contrato, tipoContratoAnt, tipoContrato, idUsuario);
            await command.ExecuteNonQueryAsync();
        }


        public async Task<List<CargarSolicitudContratoDTO>> CargarSolicitudContrato(long idContrato)
        {
            var command = ContractConfiguration.
                   GetCargarSolicitudContrato_Parameters(_dataSPContext.Command(ContractConfiguration.
                   GetCargarSolicitudContrato), Convert.ToInt32(idContrato));

            await using (var reader = await command.ExecuteReaderAsync())
                if (reader != null)
                    return ContractConfiguration.Fill_SolicitudContrato(reader);

            return default;
        }

        public async Task<List<BuscarAutorizadoresPorContratoDTO>> BuscarAutorizadoresPorContrato(long idContrato)
        {
            var command = ContractConfiguration.
                   BuscarAutorizadoresPorContrato_Parameters(_dataSPContext.Command(ContractConfiguration.
                   BuscarAutorizadoresPorContrato), Convert.ToInt32(idContrato));

            await using (var reader = await command.ExecuteReaderAsync())
                if (reader != null)
                    return ContractConfiguration.Fill_BuscarAutorizadoresPorContrato(reader);

            return default;
        }


        #endregion

    }
}
