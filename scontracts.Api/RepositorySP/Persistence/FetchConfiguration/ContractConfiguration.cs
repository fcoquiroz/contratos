using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace RepositorySP.Persistence.FetchConfiguration
{
    /// <summary>
    /// ContractConfiguration
    /// </summary>
    public class ContractConfiguration
    {
        #region Procedures
        /// <summary>
        /// ValidarExisteResponsable
        /// </summary>
        public const string ValidarExisteResponsable = "ValidarExisteResponsable";
        public const string CalcularDiasParaEntregaDocumentos = "SP_CalcularDiasParaEntregaDocumentos";
        public const string ActualizarTabContrato = "SP_ActualizarTabContrato";
        public const string CalculaFechaVencimientoAurotizacion = "CalculaFechaVencimientoAurotizacion";
        public const string CalculaSeguimientoContrato = "CalculaSeguimientoContrato";
        public const string CalculaFechaVencimientoParo = "CalculaFechaVencimientoParo";
        public const string CalculaFechaVencimiento = "CalculaFechaVencimiento";
        public const string CalculaFechaVencimientoSegundaVuelta = "CalculaFechaVencimientoSegundaVuelta";
        public const string GetDetalleDocumentoLiberado = "SP_GetDetalleDocumentoLiberado";
        public const string SpIMotivoCambioPrioridad = "SpIMotivoCambioPrioridad";
        public const string SpIMotivoCambioTipoContrato = "SpIMotivoCambioTipoContrato";
        public const string GetCargarSolicitudContrato = "CargarSolicitudContrato";
        public const string BuscarAutorizadoresPorContrato = "BuscarAutorizadoresPorContrato";
        #endregion

        #region Parameters
        /// <summary>
        /// ValidarExisteResponsable_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static SqlCommand ValidarExisteResponsable_Parameters(SqlCommand command, int userId)
        {
            command.Parameters.AddWithValue("@idUsuario", userId);
           
            return command;
        }
        /// <summary>
        /// CalcularDiasParaEntregaDocumentos_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <returns></returns>
        public static SqlCommand CalcularDiasParaEntregaDocumentos_Parameters(SqlCommand command, int Id_contrato)
        {
            command.Parameters.AddWithValue("@pID_Contrato", Id_contrato);

            return command;
        }
        /// <summary>
        /// ActualizarTabContrato_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <param name="id_estatus"></param>
        /// <returns></returns>
        public static SqlCommand ActualizarTabContrato_Parameters(SqlCommand command, int Id_contrato,int id_estatus)
        {
            command.Parameters.AddWithValue("@pID_Contrato", Id_contrato);
            command.Parameters.AddWithValue("@pID_Estatus", id_estatus);
            return command;
        }
        /// <summary>
        /// CalculaFechaVencimientoAurotizacion_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <param name="id_estatus"></param>
        /// <returns></returns>
        public static SqlCommand CalculaFechaVencimientoAurotizacion_Parameters(SqlCommand command, int Id_contrato)
        {
            command.Parameters.AddWithValue("@idContrato", Id_contrato);
            return command;
        }

        /// <summary>
        /// CalculaFechaVencimientoAurotizacion_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <param name="id_estatus"></param>
        /// <returns></returns>
        public static SqlCommand CalculaSeguimientoContrato_Parameters(SqlCommand command, int Id_contrato)
        {
            
            command.Parameters.AddWithValue("@idContrato", Id_contrato);
            return command;
        }
        /// <summary>
        /// CalculaFechaVencimientoParo_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <returns></returns>
        public static SqlCommand CalculaFechaVencimientoParo_Parameters(SqlCommand command, int Id_contrato)
        {

            command.Parameters.AddWithValue("@pID_Contrato", Id_contrato);
            return command;
        }
        /// <summary>
        /// CalculaFechaVencimiento_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <returns></returns>
        public static SqlCommand CalculaFechaVencimiento_Parameters(SqlCommand command, int Id_contrato)
        {

            command.Parameters.AddWithValue("@pID_Contrato", Id_contrato);
            return command;
        }
        /// <summary>
        /// CalculaFechaVencimientoSegundaVuelta_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <returns></returns>
        public static SqlCommand CalculaFechaVencimientoSegundaVuelta_Parameters(SqlCommand command, int Id_Contrato, int Dias_Reales)
        {

            command.Parameters.AddWithValue("@idContrato", Id_Contrato);
            command.Parameters.AddWithValue("@DiasReales", Dias_Reales);
            return command;
        }

        /// <summary>
        /// GetCamposDocumento_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <returns></returns>
        public static SqlCommand GetCamposDocumento_Parameters(SqlCommand command, long IdContrato, int IdDocumento)
        {

            command.Parameters.AddWithValue("@ID_Contrato", IdContrato);
            command.Parameters.AddWithValue("@ID_DocumentoLiberado", IdDocumento);
            return command;
        }

        public static SqlCommand SpIMotivoCambioPrioridad_Parameters(SqlCommand command, int Id_contrato,int prioridadAnt, int prioridad, int idUsuario)
        {
            command.Parameters.AddWithValue("@pID_Contrato", Id_contrato);
            command.Parameters.AddWithValue("@PrioridadAnt", prioridadAnt);
            command.Parameters.AddWithValue("@Prioridad", prioridad);
            command.Parameters.AddWithValue("@IdUsuario", idUsuario);
            return command;
        }
        public static SqlCommand SpIMotivoCambioTipoContrato_Parameters(SqlCommand command, int Id_contrato, int? tipoContratoAnt, int? tipoContrato, int idUsuario)
        {
            command.Parameters.AddWithValue("@pID_Contrato", Id_contrato);
            command.Parameters.AddWithValue("@TipoContratoAnt",(int) tipoContratoAnt);
            command.Parameters.AddWithValue("@TipoContrato", (int) tipoContrato);
            command.Parameters.AddWithValue("@idUsurio", idUsuario);
            return command;
        }

        /// <summary>
        /// GetCamposDocumento_Parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id_contrato"></param>
        /// <returns></returns>
        public static SqlCommand GetCargarSolicitudContrato_Parameters(SqlCommand command, int IdContrato)
        {
            command.Parameters.AddWithValue("@idContrato", IdContrato);
            return command;
        }
        public static SqlCommand BuscarAutorizadoresPorContrato_Parameters(SqlCommand command, int IdContrato)
        {
            command.Parameters.AddWithValue("@ID_Contrato", IdContrato);
            return command;
        }
        #endregion

        #region Readers

        /// <summary>
        /// Fill_ValidarExisteResponsable
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ResponsableDTO Fill_ValidarExisteResponsable(SqlDataReader reader)
        {
            return new ResponsableDTO
            {
                ResponsableId = Convert.ToInt32(reader["ID_Responsable"])
            };
        }

        /// <summary>
        /// Fill_CamposDocumento
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<CampoContratoLiberadoDTO> Fill_CamposDocumento(SqlDataReader reader)
        {
            var result = new List<CampoContratoLiberadoDTO>();

            while (reader.Read())
            {
                result.Add(new CampoContratoLiberadoDTO
                {
                    Id_Campo = Convert.ToInt32(reader["ID_Campo"]),
                    Id_Constante = Convert.ToInt32(reader["ID_Constante"]),
                    Valor = (string)reader["Valor"],
                    Etiqueta = (string)reader["Etiqueta"],
                    Nombre = (string)reader["Nombre"]
                });
            }
            return result;

        }


        public static List<CargarSolicitudContratoDTO> Fill_SolicitudContrato(SqlDataReader reader)
        {
            var result = new List<CargarSolicitudContratoDTO>();

            while (reader.Read())
            {
                result.Add(new CargarSolicitudContratoDTO
                {
                    Folio = (string)reader["Folio"],
                    Prioridad = (string)reader["Prioridad"],
                    Solicitante = (string)reader["Solicitante"],
                    PuestoSolicitante = (string)reader["PuestoSolicitante"],
                    UnidadSolicitante = (string)reader["UnidadSolicitante"],
                    Juridico = reader["Juridico"] == null ? "" : reader["Juridico"].ToString(),
                    JuridicoCorreo = reader["JuridicoCorreo"] == null ? "" : reader["JuridicoCorreo"].ToString(),
                    Responsable = (string)reader["Responsable"],
                    PuestoResponsable = (string)reader["PuestoResponsable"],
                    TelResponsable = (string)reader["TelResponsable"],
                    UnidadResponsable = reader["UnidadResponsable"] == null ? "" : reader["UnidadResponsable"].ToString(),
                    TipoDocumento = (string)reader["TipoDocumento"],
                    EmpresaContrato = (string)reader["EmpresaContrato"],
                    Contraparte = (string)reader["Contraparte"],
                    ObjetoNegociacion = (string)reader["ObjetoNegociacion"],
                    DescServiciosProductos = (string)reader["DescServiciosProductos"],
                    Contraprestacion = (string)reader["Contraprestacion"],
                    FormaPago = (string)reader["FormaPago"],
                    Vigencia = (string)reader["Vigencia"],
                    LugarFechaFirma = (string)reader["LugarFechaFirma"],
                    CondicionesEspeciales = (string)reader["CondicionesEspeciales"],
                    Acta = Convert.ToInt32(reader["Acta"]),
                    Poder = Convert.ToInt32(reader["Poder"]),
                    Comprobante = Convert.ToInt32(reader["Comprobante"]),
                    Identificacion = Convert.ToInt32(reader["Identificacion"]),
                    Cedula = Convert.ToInt32(reader["Cedula"]),
                    Version = Convert.ToInt32(reader["Version"]),
                    Titulo = Convert.ToInt32(reader["Titulo"]),
                    Otros = Convert.ToInt32(reader["Otros"]),
                    Moneda = (string)reader["Moneda"],
                    Idioma = (string)reader["Idioma"],
                    FechaSol = (string)reader["FechaSol"],
                    FechaVen = (string)reader["FechaVen"],
                    Estatus = Convert.ToInt32(reader["Estatus"]),
                });

            }

            return result;

        }

        public static List<BuscarAutorizadoresPorContratoDTO> Fill_BuscarAutorizadoresPorContrato(SqlDataReader reader)
        {
            var result = new List<BuscarAutorizadoresPorContratoDTO>();

            while (reader.Read())
            {
                result.Add(new BuscarAutorizadoresPorContratoDTO
                {
                    Id_Autorizador = Convert.ToInt32(reader["Id_Autorizador"]),
                    Nombre = reader["Nombre"] == null ? "" : reader["Nombre"].ToString(),
                    Correo = reader["Correo"] == null ? "" : reader["Correo"].ToString(),
                    TipoAutorizador = reader["TipoAutorizador"] == null ? "" : reader["TipoAutorizador"].ToString(),
                    TipoCaratula = reader["TipoCaratula"] == null ? "" : reader["TipoCaratula"].ToString(),
                    Producto = reader["Producto"] == null ? "" : reader["Producto"].ToString(),
                    Pais = reader["Pais"] == null ? "" : reader["Pais"].ToString(),
                    IDProducto = Convert.ToInt32(reader["IDProducto"]),
                    IDPais = Convert.ToInt32(reader["IDPais"]),
                    IDTipoAut = Convert.ToInt32(reader["IDTipoAut"]),
                    idTipoCaratula = Convert.ToInt32(reader["idTipoCaratula"]),
                    Extra = Convert.ToInt32(reader["Extra"]),
                    idUsuario = Convert.ToInt32(reader["idUsuario"])
                });

            }

            return result;

        }


        public static String error(SqlDataReader reader)
        {
            String error = "";

            while (reader.Read())
            {
                error += "<br>";
                   error += reader["descError"] == null ? "" : reader["descError"].ToString();

            }

            return error;

        }
        #endregion

    }
}
