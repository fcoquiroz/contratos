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
    public class TB_Email_Supervisor_ContratoRepository : Repository<TB_Email_Supervisor_Contrato>, ITB_Email_Supervisor_ContratoRepository
    {
        public TB_Email_Supervisor_ContratoRepository(DataContext _context) : base(_context) { }
        public DataContext consisContext { get { return Context as DataContext; } }

        public void ManipularCorreosSupervisores(ContractCreateCommand command, bool existe1, bool existe2)
        {
            TB_Email_Supervisor_Contrato dto = new TB_Email_Supervisor_Contrato();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
                if (command.EmailSupervisor1.Replace(" ", "") != "" && !existe1)
                {
                    dto = new TB_Email_Supervisor_Contrato
                    {
                        Email = command.EmailSupervisor1,
                        Activo = true,
                        ID_Contrato = command.ID_Contrato
                    };
                    unitofwork.TB_Email_Supervisor_ContratoRoutines.Add(dto);
                    unitofwork.Commit();
                }

                if (command.EmailSupervisor2.Replace(" ", "") != "" && !existe2)
                {
                    dto = new TB_Email_Supervisor_Contrato
                    {
                        Email = command.EmailSupervisor2,
                        Activo = true,
                        ID_Contrato = command.ID_Contrato
                    };
                    unitofwork.TB_Email_Supervisor_ContratoRoutines.Add(dto);
                    unitofwork.Commit();
                }
            }
        }
        public void AsignarEmailSupervisor(ContractCreateCommand command)
        {
            TB_Email_Supervisor_Contrato dto = new TB_Email_Supervisor_Contrato();
            using (var unitofwork = new UnitOfWork(new DataContext()))
            {
              var correosExistentes = unitofwork.TB_Email_Supervisor_ContratoRoutines.Find(x => x.ID_Contrato == command.ID_Contrato && x.Activo == true);

                if (correosExistentes.Count() == 0)
                {
                    ManipularCorreosSupervisores(command, false, false);
                }
                else
                {
                    bool existe1 = false;
                    bool existe2 = false;
                    foreach (var t in correosExistentes)
                    {
                        //el correo ya no existe 
                        if (t.Email != command.EmailSupervisor1 && t.Email != command.EmailSupervisor2)
                        {
                            dto = unitofwork.TB_Email_Supervisor_ContratoRoutines.Single(o => o.ID_Contrato == command.ID_Contrato && o.ID_CorreoSupervisor == t.ID_CorreoSupervisor);
                            dto.Activo = false;
                            unitofwork.TB_Email_Supervisor_ContratoRoutines.Attach(dto);
                            unitofwork.Commit();
                        }
                        else
                        {
                            if (t.Email == command.EmailSupervisor1)
                                existe1 = true;

                            if (t.Email == command.EmailSupervisor2)
                                existe2 = true;
                        }
                    }
                    ManipularCorreosSupervisores(command, existe1, existe2);
                }

            }
        }
        public List<EmailSupervisorContratoDTO> ObtenerEmailSupervisorContrato(long ID_Contrato)
        {
            //db.Tb_Email_Supervisor_Contrato.Where(x => x.Activo == true && x.ID_Contrato == entity.ID_Contrato);
            List<EmailSupervisorContratoDTO> i = new List<EmailSupervisorContratoDTO>();
            var lista = (from email in consisContext.TB_Email_Supervisor_ContratoRoutines
                         where email.Activo == true && email.ID_Contrato == ID_Contrato
                         select new
                         {
                             email = email
                         }).ToList();

            var lap = 1;
            string EmailSupervisor1 = "", EmailSupervisor2 = "";


            foreach (var item in lista)
            {

                if (lap == 1)
                    EmailSupervisor1 = item.email.Email;
                if (lap == 2)
                    EmailSupervisor2 = item.email.Email;
                lap++;
            }

            i.Add(new EmailSupervisorContratoDTO() { EmailSupervisor1 = EmailSupervisor1 , EmailSupervisor2 = EmailSupervisor2 });
            return i;
        }
    }
}
