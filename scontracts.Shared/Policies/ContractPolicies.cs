using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Policies
{
    /// <summary>
    /// Policies
    /// </summary>
    public static partial class Policies
    {

        /// <summary>
        /// CanManageContracts
        /// </summary>
        public const string CanManageContracts = "CanManageContracts";
        /// <summary>
        /// AuthorizationPolicy
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy CanManageContractsPolicy()
        {
            return new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole("Administrador", "Abogado")
                    .Build();
        }

    }
}
