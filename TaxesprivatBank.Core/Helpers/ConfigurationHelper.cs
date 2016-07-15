using System.Configuration;

namespace TaxesprivatBank.Core.Helpers
{
    /// <summary>
    /// The configuration helper.
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Gets the Privat Bank client identifier.
        /// </summary>
        public static string PBClientID
        {
            get
            {
                return ConfigurationManager.AppSettings["PBClientID"];
            }
        }

        /// <summary>
        /// Gets the pb client secret.
        /// </summary>
        public static string PBClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["PBClientSecret"];
            }
        }
    }
}
