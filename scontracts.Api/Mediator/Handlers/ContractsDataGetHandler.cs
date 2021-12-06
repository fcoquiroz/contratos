using MediatR;
using Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using scontracts.Api.Mediator.Queries;
using scontracts.Shared.Responses;
using scontracts.Shared.DTO;
using scontracts.Api.Context;
using scontracts.Api.Context.Strategies;
using scontracts.Api.Helpers;
using Repository.Core.Domain;
using RepositorySP.Persistence;

namespace xpl.sow.organization.Mediator.Handlers
{
    /// <summary>
    /// ContractsDataGetHandler
    /// </summary>
    public class ContractsDataGetHandler : IRequestHandler<ContractsDataGetQuery, ResponseT<ContractsDataGetResponse>>
    {

        /// <summary>
        /// ContractsDataGetHandler
        /// </summary>
        public ContractsDataGetHandler()
        {

        }
        /// <summary>
        /// Handle 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseT<ContractsDataGetResponse>> Handle(ContractsDataGetQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(10);
            ResponseT<ContractsDataGetResponse> res = new ResponseT<ContractsDataGetResponse>();

            // ResponseList<ContractsDataGetResponse> res = new ResponseList<ContractsDataGetResponse>();
            ///List<ContractsDataGetResponse> list = new List<ContractsDataGetResponse>();


            //Guardado del log
            try
            {

                new ContractContext(new ContractLogginData()).SaveLog(
                    new scontracts.Api.Mediator.Commands.LogCreateCommand(new scontracts.Shared.Requests.LogCreateRequest
                    {
                        Control = "contracts.cshtml",
                        Message = "",
                        Path = "Contract/contracts",
                        UserName = request.IdUser.ToString()

                    })
                    );
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
            }

            ResponsableDTO responsable = new ResponsableDTO();

            try
            {

                await using (var unitofwork = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                {
                    responsable = await unitofwork.ContractRepo.ValidarExisteResponsable(request.IdUser);
                }
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
            }

            try
            {
                using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
                {
                    string rutaDocumentos = unitofwork.TB_ParametrosRoutines.Get(2).Valor;
                    res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                         new ContractsDataGetResponse
                         {
                             RutaDocumentos = unitofwork.TB_ParametrosRoutines.Get(2).Valor,
                             ListaPrioridades = unitofwork.Cat_PrioridadRoutines.ObtenerPrioridades(),
                             ListaIdiomas = unitofwork.cat_IdiomaRoutines.ObtenerIdiomas(),
                             ListaTipoDocumentos = unitofwork.Cat_TipoDocumentoRoutines.ObtenerTipoDocumentos(),
                             ListaUnidades = unitofwork.Cat_UnidadRoutines.ObtenerUnidades(),
                             ListaProveedores = unitofwork.Cat_ProveedorRoutines.ObtenerProveedores(),
                             ListaTipoMoneda = unitofwork.Cat_TipoMonedaRoutines.ObtenerTipoMoneda(),
                             ListaResponsable = unitofwork.Cat_ResponsablesRoutines.ObtenerResponsable(),
                             ListaUnidadResponsable = unitofwork.Cat_Unidad_UsuarioRoutines.ObtenerUnidadesResponsable(),
                             ID_Responsable = responsable.ResponsableId,
                             ListaPaises = unitofwork.Cat_PaisRoutines.ObtenerPaises(),
                             ListaTipoContraparte = unitofwork.Cat_TipoSolicitudRoutines.ObtenerTipoContraparte(),
                             ListaProductos = unitofwork.Cat_ProductoRoutines.ObtenerProductos()
                         });
                    
                }

            }
            catch (Exception ex)
            {
                res.update(StatusCodes.Status500InternalServerError, ex.Message, new ContractsDataGetResponse());
            }
            return res;
        }
        public async Task GetResponsableId(int userId)
        {
            int idResponsable = 0;
            try
            {

                await using (var unitofwork = new RepositorySP.Persistence.UnitOfWork(new DataSPContext()))
                {
                     unitofwork.ContractRepo.ValidarExisteResponsable(userId);
                }
            }
            catch (Exception ex)
            {
                ErrorLogFile.LogCritical(ex.Message);
            }


        }
    }

}