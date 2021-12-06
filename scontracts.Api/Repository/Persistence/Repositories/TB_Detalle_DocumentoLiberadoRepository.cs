using Newtonsoft.Json;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using scontracts.Api.Mediator.Commands;
using scontracts.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    public class TB_Detalle_DocumentoLiberadoRepository: Repository<TB_Detalle_DocumentoLiberado>, ITB_Detalle_DocumentoLiberadoRepository
    {
        public TB_Detalle_DocumentoLiberadoRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }

        public void SaveDetail(ContractCreateCommand command)
        {
            TB_Detalle_DocumentoLiberado dto = new TB_Detalle_DocumentoLiberado();
            var detalle = JsonConvert.DeserializeObject<List<CampoContratoLiberadoDTO>>(command.FieldsDoc_Liberado);

            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                var detalleExistente = unitofwork.TB_Detalle_DocumentoLiberadoRoutines.Find(x => x.ID_Contrato == command.ID_Contrato && x.Activo == true);
                if (detalleExistente.Count() == 0)
                {
                    foreach (var field in detalle)
                    {
                        dto = new TB_Detalle_DocumentoLiberado
                        {
                            ID_Campo = field.Id_Campo,
                            ID_Contrato = command.ID_Contrato,
                            Activo = true,
                            Valor = field.Valor
                        };

                        unitofwork.TB_Detalle_DocumentoLiberadoRoutines.Add(dto);
                        unitofwork.Commit();
                    }
                }
                else
                {
                    foreach (var field in detalle)
                    {
                        dto = unitofwork.TB_Detalle_DocumentoLiberadoRoutines.Single(o => o.ID_Contrato == command.ID_Contrato && o.Activo == true && o.ID_Campo == field.Id_Campo);
                        dto.Valor = field.Valor;
                        unitofwork.TB_Detalle_DocumentoLiberadoRoutines.Attach(dto);
                        unitofwork.Commit();
                    }
                }
            }
        }
    }
}
