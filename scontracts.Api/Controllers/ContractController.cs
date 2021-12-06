using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Mediator.Commands;
using scontracts.Api.Mediator.Queries;
using scontracts.Api.Models;
using scontracts.Shared.DTO;
using scontracts.Shared.Requests;
using scontracts.Shared.Responses;

namespace scontracts.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = "AuthenticatedUserSchemeName", Policy = "AuthorizedUserPolicyName")]

    /// <summary>
    /// ContractController
    /// </summary>
    ///[Authorize(AuthenticationSchemes = Constants.ctoScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {

        string files_folder = Startup.StaticConfig.GetSection("files_folder").Value;

        private readonly IMediator _mediator;

        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public ContractController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }


        /// <summary>
        /// Obtiene el usuario 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/user/users/{id}
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Un Usuario</returns>
        /// <response code="200">Regresa un Usuario</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>   
        /// <response code="409">Si no hay datos</response>     
        [Route("users/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<UserGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            var query = new UserByNameQuery("Rivelino Castro Barbosa");
            var result = await _mediator.Send(query);
            return Ok(result);

        }
        /// <summary>
        /// Crea Contrato
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/contract/contract¿
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>ContractCreateResponse</returns> 
        /// <response code="200">ContractCreateResponse</response>
        /// <response code="401">Si no tiene autorización</response>     
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("contracts")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<ContractCreateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateContract([FromBody] ContractCreateRequest request)
        {

            var command = new ContractCreateCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);


        }
        /// <summary>
        /// Inserta Log
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Inserta Log de las acciones de las apis que son llamadas en cada pantalla
        ///  POST api/contracts/log
        ///   {
        ///  "userName": "string",
        ///  "path": "string",
        ///  "control": "string",
        ///  "message": "string"
        ///}
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="200">LogCreateResponse</response>
        /// <response code="401">Si no tiene autorización</response>     
        /// <response code="409">Conflicto en validaciones de negocio</response>     
        /// <response code="500">Error interno del servidor</response>     
        /// 
        [Route("log")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<LogCreateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Createlog([FromBody] LogCreateRequest request)
        {

            var command = new LogCreateCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);


        }
        /// <summary>
        /// Obtiene la lista de solicitudes de contrato
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de solicitudes para el abogado o solicitante dependiendo del rol, recibe los parametros de: Rol, UserId, EstatusId
        /// Sample request:
        ///
        ///     GET scontracts.api/contract 
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns>Lista de solicitudes de contratos</returns>
        /// <response code="200">ContractFindResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        /// 
        [Route("contracts")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<ContractFindResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindContracts([FromQuery] ContractFindRequest request)
        {
            var query = new ContractFindQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene la lista de estatus
        /// </summary>
        /// <remarks>
        /// Regresa la lista de estatus correspondiente al usuario y rol que ingresa en la aplicacion, recibe el parametro de: Rol, UserId, EstatusId
        /// Sample request:
        ///     GET api/contracts/status
        ///     {
        ///     }
        /// </remarks>
        /// <returns>Lista de estatus por rol</returns>
        /// <response code="200">StatusGetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        /// 
        [Route("status")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseList<StatusGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStatus([FromQuery] StatusGetRequest request)
        {
            var query = new StatusGetQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene la solicitud de contrato
        /// </summary>
        /// <remarks>
        /// Obtiene la informacion de la solicitud de un contrato para que sea mostrada en caso de borrador en las solicitudes de contrato, recibe el parametro de: IdContrato 
        /// Sample request:
        ///
        ///     GET api/contracts/request
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns>Informacion de la solicitud de contrato</returns>
        /// <response code="200">SolicitudGetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        /// 
        [Route("request")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseList<SolicitudGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRequest(long IdContrato)
        {
            var query = new SolicitudGetQuery(IdContrato);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene los datos que se usan para cargar la pantalla contratos
        /// </summary>
        /// <remarks>
        /// Obtiene los datos que se usan para cargar los combos de la solicitud de contrato, recibe los parametros de: UserName, UserId
        /// Sample request:
        ///GET api/contracts/contracts-data/{username}
        ///     {
        ///     }
        /// </remarks>
        /// <returns>Lista de datos para cargar la pantalla de solicitud de contrato</returns>
        /// <response code="200">ContractsDataGetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        [Route("contracts-data/{username}")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<ContractsDataGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContractsData(String UserName, int UserId)
        {
            var query = new ContractsDataGetQuery(UserName, UserId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene la informacion del seguimiento de una solicitud de contrato
        /// </summary>
        /// <remarks>
        /// En base al id del contrato obtiene la solicitud  para ser mostrada en pantalla de segumiento del contrato en base al parametro: id_Contrato
        ///     GET api/contracts/TracingGet
        ///     {
        ///     }
        /// </remarks>
        /// <returns>Lista de datos para cargar la pantalla</returns>
        /// <param name="Id_Contrato"></param>
        /// <response code="200">TracingGetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        [Route("Tracing")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<TracingGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> TracingGet(long Id_Contrato)
        {
            var query = new TracingGetQuery(Id_Contrato);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Acepta la caratula de validacion 
        /// </summary>
        /// <remarks>
        /// En base a los parametros que se le envian se acepta la caratula de validacion 
        ///     Sample request:
        /// POST api/contracts/AcceptCover
        ///  {
        ///  "parametroCont": "int",
        ///  "parametroUsr": "int",
        ///  "parametroAut": "int",
        ///  "parametroExtra": "int",
        ///  "parametroVuelta": "int",
        ///  "nombreAutorizador": "string",
        ///  "tipoAutorizador": "int",
        ///  "existeAutorizadores_Aut": true
        /// }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Cadena con mensaje de confirmacion</returns>
        /// /// <response code="200">AcceptCoverSetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        [Route("acceptCover")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<AcceptCoverSetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AcceptCover([FromBody] AcceptCoverSetRequest request)
        {
            var command = new AcceptCoverSetCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Rechaza la caratula de validación 
        /// </summary>
        /// <remarks>
        /// En base a los parametros que se le envian se rechaza la caratula de validacion agregando un motivo a los comentarios
        ///     Sample request:
        /// POST api/contracts/RejectCover
        ///  {
        ///  "motivo": "string",
        ///  "parametroCont": "int",
        ///  "parametroUsr": "int",
        ///  "parametroAut": "int",
        ///  "parametroExtra": "int",
        ///  "parametroVuelta": "int",
        ///  "nombreAutorizador": "string",
        ///  "tipoAutorizador": "int",
        ///  "existeAutorizadores_Aut": true
        /// }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Cadena con mensaje de confirmacion</returns>
        /// /// <response code="200">RejectCoverSetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>
        [Route("rejectCover")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<RejectCoverSetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RejectCover([FromBody] RejectCoverSetRequest request)
        {
            var command = new RejectCoverSetCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Manejo de comentarios
        /// </summary>
        /// <remarks>
        /// Maneja el cambio de estatus y los comentarios para el seguimiento de las solicitudes de contrato
        /// Sample request:
        /// POST api/contracts/managementCommentary
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Cadena con mensaje de confirmacion</returns>
        /// /// <response code="200">ManagementCommentaryResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>
        [Route("managementCommentary")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<ManagementCommentaryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ManagementCommentary([FromBody] ManagementCommentaryRequest request)
        {
            var command = new ManagementCommentaryCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene la lista de solicutudes del contrato principal para relacionar
        /// </summary>
        /// <remarks>
        /// Obtiene la informacion de la solicitudes de contrato principal que pueden usarse para relacionarse
        /// Sample request:
        ///
        ///     GET scontracts.api/parentContracts 
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns>Lista de contratos</returns>
        /// <response code="200">Regresa con exito la lista de solicitudes</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        /// 
        [Route("parentContracts")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<ParentContractsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindParentContracts([FromQuery] ParentContractsRequest request)
        {
            var query = new ParentContractsQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene la lista de solicitudes de contrato principal ya relacionadas
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de la informacion de la solicitudes de contrato principal; los parametros que recibe son: IdUsuario, IdContratoPadre
        /// Sample request:
        ///
        ///     GET scontracts.api/relatedContracts 
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns>Lista de contratos</returns>
        /// <response code="200">Regresa con exito la lista de contrato principal relacionado</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>
        [Route("relatedContracts")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<ParentContractsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindRelatedContracts([FromQuery] RelatedContractsRequest request)
        {
            var query = new RelatedContractsQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene los datos de la Caratula
        /// </summary>
        /// <remarks>
        /// Obtiene el formato, campos e informacion de la caratula mediante los parametros de ID_Contrato,  ID_Usuario_Envio
        /// Sample request:
        ///
        ///     GET scontracts.api/coverDataGet 
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Regresa la informacion de la caratula de validación</returns>
        /// <response code="200">Regresa con exito el mensaje de confirmacion</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        [Route("coverDataGet")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<CoverDataGetResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CoverDataGet([FromQuery] CoverDataGetRequest request)
        {
            var query = new CoverDataGetQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Manejo de la operaciones de la caratula de validación
        /// </summary>
        /// <remarks> 
        /// Maneja el guardado, envio, autorizacion y rechazo de la caratula de validación
        /// POST scontracts.api/managementCover
        /// {
        ///  "iD_Contrato": "int",
        ///  "iD_Usuario_Envio": "int",
        ///  "hfArrayNombre": "string",
        ///  "inversion": "string",
        ///  "capacidad": "string",
        ///  "pena": "string",
        ///  "accion": "string",
        ///  "extra": true,
        ///  "iD_Usuario": "int",
        ///  "nombre": "string",
        /// "correo": "string",
        ///  "iD_TipoAutorizador": "int",
        ///  "iD_TipoCaratula": "int",
        ///  "iD_Producto": "int",
        ///  "iD_Pais": "int",
        ///  "idAutorizador": "int",
        ///  "comentarios": "string"
        ///}
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Cadena con la confirmacion de la operacion</returns>
        /// <response code="200">Regresa con exito el mensaje de confirmacion</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        [Route("managementCover")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseT<ManagementCoverResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ManagementCover([FromBody] ManagementCoverRequest request)
        {
           
            var command = new ManagementCoverCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene la lista de los datos del formato liberado
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de los datos del formato liberado en base a los parametros de IdUsuario y IdUnidadUsuario
        /// Sample request:
        ///
        ///     GET scontracts.api/releasedDocs 
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <returns>Lista de contratos</returns>
        /// <response code="200">Regresa con exito la lista de formatos liberados</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        [Route("releasedDocs")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<ReleasedDocsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindReleasedDocs([FromQuery] ReleasedDocsRequest request)
        {
            var query = new ReleasedDocsQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtiene los campos del contrato liberado
        /// </summary>
        /// <remarks>
        /// Obtiene los campos del contrato liberado en base de los parametros IdUsuario, IdDocumento, IdContrato
        /// Sample request:
        ///
        ///     GET scontracts.api/templateDocs 
        ///     {
        ///     
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>campos de contrato liberado</returns>
        /// <response code="200">Regresa con exito la lista de los campos de documentos liberados</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>
        [Route("templateDocs")]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseT<TemplateDocsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplate([FromQuery] TemplateDocsRequest request)
        {
            var query = new TemplateDocsQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //http://localhost:64215/api/Contract/fileDownload?id_contrato=2345678&file_name=test%20file.pdf
        [Route("fileDownload")]
        [HttpGet]
        public async Task<IActionResult> fileDownload(String id_contrato, String file_name)
        {

            try
            {
                string directory = string.Format(@"{0}{1}", files_folder, id_contrato);
                string filename = string.Format(@"{0}{1}\{2}", files_folder, id_contrato, file_name);


                if (Directory.Exists(directory))
                {
                    if (System.IO.File.Exists(filename))
                    {
                        var path = filename;

                        var memory = new MemoryStream();
                        using (var stream = new FileStream(path, FileMode.Open))
                        {
                            await stream.CopyToAsync(memory);
                        }
                        memory.Position = 0;
                        return File(memory, GetContentType(path), Path.GetFileName(path));
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //http://localhost:64215/api/Contract/fileUpload
        [Route("fileUpload")]
        [HttpPost]
        public async Task<IActionResult> fileUpload([FromForm] FileSaveRequest request)
        {
            long id_contrato = request.id_contrato;
            String[] isRev = request.is_rev != null ? request.is_rev.Split(",") : null;
            List<IFormFile> files = request.files;

            if (files == null || files.Count == 0)
                return Content("file not selected");

            string uniqueFileName = null;
            string directory = string.Format(@"{0}{1}", files_folder, id_contrato.ToString());
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            long size = files.Sum(f => f.Length);

            var fileTypes = new List<string>();
            var fileNames = new List<string>();
            var fileExtensions = new List<string>();
            var fileIsRev = new List<int>();


            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                uniqueFileName = file.FileName;

                if (System.IO.File.Exists(string.Format(@"{0}\{1}", directory, uniqueFileName)))
                    uniqueFileName = string.Format("{0}-Hr{1}-{2}", DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("hhmm"), uniqueFileName);

                string filePath = Path.Combine(directory, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                fileNames.Add(uniqueFileName);
                fileExtensions.Add(Path.GetExtension(uniqueFileName));
                fileTypes.Add(file.ContentType);

                if (isRev[i].Equals("0"))
                {
                    fileIsRev.Add(0);
                }
                else if (isRev[i].Equals("1"))
                {
                    fileIsRev.Add(1);
                }
            }


            return Ok(new { directory = directory, fileNames, fileExtensions, fileTypes, fileIsRev });
        }
        [Route("fileDelete")]
        [HttpPost]
        public async Task<IActionResult> fileDelete([FromForm] FileDeleteRequest request)
        {
            long id_archivo = request.id_archivo;
            var query = new FileDeleteCommand(request);
            var result = await _mediator.Send(query);
            string directory = string.Format(@"{0}{1}", files_folder, result.Data.ID_Contrato.ToString());
            string Path_file = string.Format(@"{0}{1}\{2}", files_folder, result.Data.ID_Contrato.ToString(), result.Data.Nombre_Archivo);
            
            if (Directory.Exists(directory))
                System.IO.File.Delete(Path_file);

            return Ok(new { mensaje = result.Data.Mensaje});
        }


        /// <summary>
        /// Obtiene la lista de estatus
        /// </summary>
        /// <remarks>
        /// Regresa la lista de estatus correspondiente al usuario y rol que ingresa en la aplicacion, recibe el parametro de: Rol, UserId, EstatusId
        /// Sample request:
        ///     GET api/contracts/status
        ///     {
        ///     }
        /// </remarks>
        /// <returns>Lista de idiomas/returns>
        /// <response code="200">StatusGetResponse</response>
        /// <response code="401">Si no tiene autorización</response>        
        /// <response code="500">Error interno del servidor</response>
        /// <response code="404">no hay datos</response>  
        /// 
        [Route("ListaIdiomas")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Cat_IdiomaUsuario>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetIdiomas()
        {
            using (var db = new DataContext())
            {

                var idiomas =  db.cat_IdiomaUsuarioRoutines.ToList();
              return (IActionResult)idiomas;
            }
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".ppt", "application/vnd.ms-powerpoint"},
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".msg", "application/vnd.ms-outlook"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

    }

}




