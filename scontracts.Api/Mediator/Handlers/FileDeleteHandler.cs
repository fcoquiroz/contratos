using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Helpers;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scontracts.Api.Mediator.Handlers
{
    /// <summary>
    /// FileDeleteHandler
    /// </summary>
    public class FileDeleteHandler : Constants, IRequestHandler<FileDeleteCommand, ResponseT<FileDeleteResponse>>
    {
        public async Task<ResponseT<FileDeleteResponse>> Handle(FileDeleteCommand commmand, CancellationToken cancellationToken)
        {
            ResponseT<FileDeleteResponse> res = new ResponseT<FileDeleteResponse>();
            using (var unitofwork = new Repository.Persistence.UnitOfWork(new DataContext()))
            {
                using (var con = new DataContext())
                {
                    using (var tran = con.Database.BeginTransaction())
                    {
                        try
                        {

                            TB_Contratos_Documentacion info_doc = unitofwork.TB_Contratos_DocumentacionRoutines.DeleteFile(con,commmand.id_archivo);
                                                                               
                            tran.Commit();
                            res.update(StatusCodes.Status200OK, ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK),
                              new FileDeleteResponse
                              {
                                  ID_Contrato = info_doc.ID_Contrato,
                                  Nombre_Archivo = info_doc.NombreArchivo,
                                  Mensaje = "El archivo se eliminó correctamente."
                              });
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ErrorLogFile.LogCritical(ex.Message);
                            res.update(StatusCodes.Status500InternalServerError, ex.Message, new FileDeleteResponse { Mensaje = ex.Message});
                        }
                    }
                }
            }
            return res;
        }
    }
}
