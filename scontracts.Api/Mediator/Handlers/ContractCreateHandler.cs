using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Repository.Persistence;
using System.IO;
using scontracts.Shared.DTO;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;
using scontracts.Shared.Requests;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// ContractCreateHandler
    /// </summary>
    public class ContractCreateHandler : Constants, IRequestHandler<ContractCreateCommand, ResponseT<ContractCreateResponse>>

    {

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<ContractCreateHandler> _logger;
        /// <summary>
        /// _env
        /// </summary>
        private readonly IWebHostEnvironment _env;
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// ContractCreateHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public ContractCreateHandler(ILogger<ContractCreateHandler> logger, IConfiguration configuration, IWebHostEnvironment env)
        {
            _logger = logger;
            Configuration = configuration;
            _env = env;

        }
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ContractCreateResponse>> Handle(ContractCreateCommand command, CancellationToken cancellationToken)
        {

            ResponseT<ContractCreateResponse> res = new ResponseT<ContractCreateResponse>(); 
            ContractCreateResponse response = new ContractCreateResponse();

            #region Log
            try
            {
                LogCreateRequest requestLog = new LogCreateRequest
                {
                    UserName = command.ID_UsuarioEnvio.ToString(),
                    Path = "CreateReleasedDoc.cshtml",
                    Control = "contracts",
                    Message = "Creación de Solicitud de Contrato Liberado"
                };
                var commands = new LogCreateCommand(requestLog);
                new ContractContext(new ContractLogginData()).SaveLog(commands);
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
            }
            #endregion
            try
            {
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    command.ProveedorId = unitofwork.Cat_ProveedorRoutines.ObtenerIDProveedor(command);
                }
                    response = new ContractContext(new ContractSavingPartial()).SaveContract(command);
                command.ID_Contrato = response.ID_Contrato;
                new ContractContext(new ContractSavingMultiProduct()).SaveContract(command);
                //Saving Details
                response = new ContractContext(new ContractSavingDetails()).SaveContract(command);
                if (!command.EnElaboracion)
                {
                    using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                    {
                        ContractCreateRequest request = unitofwork.TB_Contratos_VersionesRoutines.ObtenerContratoVersion(command);
                        if (request != null)
                        {
                            command.NombreContrato = request.NombreContrato;
                            command.Extension = request.Extension;
                            command.ContenttType = request.ContenttType;
                            command.Version = request.Version;
                        }
                    }
                }
                #region correos supervisores
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    unitofwork.TB_Email_Supervisor_ContratoRoutines.AsignarEmailSupervisor(command);
                }
                #endregion
                #region contrato liberado
                if (command.FieldsDoc_Liberado != null)
                {
                    using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                    {
                        unitofwork.TB_Detalle_DocumentoLiberadoRoutines.SaveDetail(command);

                        //Saving contrato pdf
                        var detalle = JsonConvert.DeserializeObject<List<CampoContratoLiberadoDTO>>(command.FieldsDoc_Liberado);

                        var contrato = unitofwork.TB_ContratosRoutines.ObtenerContrato(command.ID_Contrato);
                        var pathPlantilla = unitofwork.TB_ParametrosRoutines.ObtenerParametro(17).Valor;
                        string pathResultado = string.Format("{0}{1}", unitofwork.TB_ParametrosRoutines.ObtenerParametro(2).Valor, contrato.ID_Contrato);
                        var plantilla = unitofwork.Cat_FormatoLiberadosRoutines.ObtenerContratoLiberado(contrato.ID_FormatoLiberado).Plantilla;
                        var original = string.Format(@"{0}\{1}", pathPlantilla, plantilla);
                        string name = contrato.ID_Contrato + "_" + plantilla;
                        var file = string.Format(@"{0}\{1}", pathResultado, command.ID_Contrato);

                        if (!Directory.Exists(pathResultado))
                            Directory.CreateDirectory(pathResultado);

                        if (File.Exists(string.Format(@"{0}\{1}", pathResultado, name)))
                            name = string.Format("{0}-Hr{1}-{2}", DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("hhmm"), name);

                        PdfReader reader = new PdfReader(original);
                        PdfStamper stm = new PdfStamper(reader, new FileStream(file, FileMode.Create));

                        AcroFields fields = stm.AcroFields;
                        foreach (var i in detalle)
                        {
                            fields.SetField(i.Nombre, i.Valor);
                        }

                        stm.FormFlattening = true;
                        stm.Close();
                        reader.Close();
                        
                        File.Move(file, string.Format(@"{0}\{1}", pathResultado, name));
                        
                        command.Comentarios = "Se envió la solicitud del contrato";
                        command.ExisteArchivo = true;
                        command.NombreContrato = name;
                        command.Extension = ".pdf";
                        command.ContenttType = "application/pdf";

                    }
                }
                #endregion

                //Saving version
                response = new ContractContext(new ContractSavingVersion()).SaveContract(command);
                
                //Saving Doc
                response = new ContractContext(new ContractSavingDocuments()).SaveContract(command);
               
                var path = "";
                List<CargarSolicitudContratoDTO> dtDatos = new List<CargarSolicitudContratoDTO>();
                List<CargarSolicitudContratoDTO> dtDatos2 = new List<CargarSolicitudContratoDTO>();
                string pathReporte = "";
                string directory = "";

                #region Reporte Contrato Liberado

                #endregion

                res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                    new ContractCreateResponse
                    {
                        ID_Contrato = command.ID_Contrato,
                        PathRdlc = path,
                        DatosReporte = dtDatos,
                        Directory = directory,
                        PathReporte = pathReporte,
                        Mensaje = "La solicitud se generó y envió correctamente."

                    });

            }
            catch (Exception ex)
            {

                ErrorLogFile.LogCritical(ex.Message);
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ContractCreateResponse() { Mensaje = ex.Message + "StackTrace" + ex.StackTrace });
            }
            return res;
        }
    }
}
