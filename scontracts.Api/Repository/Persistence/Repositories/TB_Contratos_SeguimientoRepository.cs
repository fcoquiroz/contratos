using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using Microsoft.Exchange.WebServices.Data;
using scontracts.Api.Helpers;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// TB_Contratos_SeguimientoRepository
    /// </summary>
    public class TB_Contratos_SeguimientoRepository : Repository<TB_Contratos_Seguimiento>, ITB_Contratos_SeguimientoRepository
    {
        /// <summary>
        /// TB_Contratos_SeguimientoRepository
        /// </summary>
        /// <param name="_context"></param>
        public TB_Contratos_SeguimientoRepository(DataContext _context) : base(_context) { }
        /// <summary>
        /// consisContext
        /// </summary>
        public DataContext consisContext { get { return Context as DataContext; } }


        public bool CancelarMeeting(long ID_Contrato)
        {

            using (var db = new DataContext())
            {
                try
                {
                    var c = db.TB_ContratosRoutines.Find(ID_Contrato);
                    TB_Contratos_Seguimiento cs = db.TB_Contratos_SeguimientoRoutines.Where(x => x.ID_Contrato == c.ID_Contrato).OrderByDescending(x => x.ID_Contrato_Seguimiento).FirstOrDefault();
                    TB_Contratos_Appointment ca = db.TB_Contratos_AppointmentRoutines.Where(x => x.ID_Contrato == c.ID_Contrato && x.Modify_Date == null).FirstOrDefault();

                    if (ca != null)
                    {
                        ExchangeService service = new ExchangeService();

                        service.Credentials = new WebCredentials(db.TB_ParametrosRoutines.Find(4).Valor, db.TB_ParametrosRoutines.Find(5).Valor);
                        service.Url = new Uri(db.TB_ParametrosRoutines.Find(13).Valor);
                        service.TraceEnabled = true;
                        service.TraceFlags = TraceFlags.All;

                        ItemId itemId = new ItemId(ca.ID_Appointment);
                        Appointment meeting = Appointment.Bind(service, itemId);

                        meeting.Delete(DeleteMode.HardDelete, SendCancellationsMode.SendToAllAndSaveCopy);

                        #region TB_Contratos_Appointment
                        ca.Modify_Date = DateTime.Now;

                        db.Entry(ca).CurrentValues.SetValues(ca);
                        db.SaveChanges();
                        #endregion

                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogFile.LogCritical(ex.Message);
                    return false;
                }
            }
        }
    }
}
