using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Core.Domain
{
    /// <summary>
    /// Cat_LDAP
    /// </summary>
    public class Cat_LDAP
    {
        /// <summary>
        /// IdLDAP
        /// </summary>
        public int IdLDAP { get; set; }
        /// <summary>
        /// Empresa
        /// </summary>
        public string Empresa { get; set; }
        /// <summary>
        /// Dominio
        /// </summary>
        public string Dominio { get; set; }
        /// <summary>
        /// LDAP
        /// </summary>
        public string LDAP { get; set; }
        /// <summary>
        /// FechaAlta
        /// </summary>
        public DateTime FechaAlta { get; set; }
    }
}
