using App.Contratos.DAL.Enums;
using Repository.Core.Domain;
using Repository.Persistence;
using scontracts.Api.Context.Behaviours;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scontracts.Api.Context.Strategies
{
    /// <summary>
    /// ContractSavingDocuments
    /// </summary>
    public class ContractSavingDocuments : IContractSave
    {

        /// <summary>
        /// Save - Implementación de estrategia para guardar datos generales de la solicitud de contrato (Tabla Padre)
        /// </summary>
        /// <returns></returns>
        public ContractCreateResponse Save(ContractCreateCommand command)
        {
            TB_Contratos_Documentacion dto = new TB_Contratos_Documentacion();
            ContractCreateResponse res = new ContractCreateResponse();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {

                if(command.ListContratosDoc != null)
                if (command.ListContratosDoc.Count > 0 )
                {

                        foreach (var docFile in command.ListContratosDoc)
                        {
                            if (docFile.ID_Documentacion != (int)Documentacion.Contrato)
                            {
                                //if (!command.EsBorrador)
                                //{
                                    dto = new TB_Contratos_Documentacion
                                    {
                                        ID_Contrato = command.ID_Contrato,
                                        ID_Documentacion = docFile.ID_Documentacion,
                                        NombreArchivo = docFile.NombreArchivo, //filename
                                        Extension = docFile.Extension,
                                        ContenttType = docFile.ContenttType,
                                        FechaCreacion = DateTime.Now,
                                        ID_Usuario = docFile.ID_Usuario
                                    };
                                    unitofwork.TB_Contratos_DocumentacionRoutines.Add(dto);
                                //}
                                //else
                                //{
                                //    dto = unitofwork.TB_Contratos_DocumentacionRoutines.Single(o => o.ID_Contrato == command.ID_Contrato);
                                //    dto.ID_Documentacion = docFile.ID_Documentacion;
                                //    dto.NombreArchivo = docFile.NombreArchivo; 
                                //    dto.Extension = docFile.Extension;
                                //    dto.ContenttType = docFile.ContenttType;
                                //    dto.FechaCreacion = DateTime.Now;
                                //    dto.ID_Usuario = docFile.ID_Usuario;
                                //    unitofwork.TB_Contratos_DocumentacionRoutines.Attach(dto);
                                //}
                            }
                        }
               
                    unitofwork.Commit();
                }            

            }
            return res;

        }

    }
}
