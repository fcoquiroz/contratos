using scontracts.Shared.Enums;
using scontracts.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace scontracts.Shared.Settings
{
    /// <summary>
    /// Language
    /// </summary>
    public class Language
    {
        /// <summary>
        /// SetLanguage
        /// </summary>
        /// <param name="language"></param>
        public static void SetLanguage(Languages language)
        {
            switch (language)
            {
                case Languages.Spanish:
                    DefaultLanguage.AppName = AppResources_sp.AppName;
                    break;
               
            }

        }
    }


    /// <summary>
    /// DefaultLanguage
    /// </summary>
    public class DefaultLanguage
    {

        #region Messages
        /// <summary>
        /// AppName
        /// </summary>
        public static string AppName { get; set; }
       
        #endregion


        #region Labels

        #endregion

    }


}