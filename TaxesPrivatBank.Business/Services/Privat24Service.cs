using System.Collections.Generic;
using TaxesprivatBank.Core.Dto;
using TaxesprivatBank.Core.Helpers;

namespace TaxesPrivatBank.Business.Services
{
    /// <summary>
    /// The privat24 client service.
    /// </summary>
    public class Privat24Service : ServiceBase
    {
        /// <summary>
        /// The privat bank API URL.
        /// </summary>
        private const string PrivatBankApiUrl = "https://link.privatbank.ua/";

        /// <summary>
        /// The client identifier.
        /// </summary>
        private string clientID;

        /// <summary>
        /// The client secret.
        /// </summary>
        private string clientSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="Privat24Service" /> class.
        /// </summary>
        /// <param name="clientID">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        public Privat24Service(string clientID, string clientSecret)
            : base(PrivatBankApiUrl)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
        }

        /// <summary>
        /// Gets the session identifier.
        /// </summary>
        /// <param name="clientID">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <returns>The session.</returns>
        public PBSessionDto GetSession()
        {
            string apiEndpoint = "api/auth/createSession";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "clientId", this.clientID },
                { "clientSecret", this.clientSecret},
            };

            return this.GetPOSTResponse<PBSessionDto>(apiEndpoint, parameters);
        }

        /// <summary>
        /// Gets the person session.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="login">The login.</param>
        /// <param name="password">The password.</param>
        /// <returns>The person session.</returns>
        public PBPersonSessionDto GetPersonSession(string sessionId, string login, string password)
        {
            string apiEndpoint = "api/p24BusinessAuth/createSession";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "sessionId", sessionId },
                { "login", login},
                { "password", password }
            };

            return this.GetPOSTResponse<PBPersonSessionDto>(apiEndpoint, parameters);
        }

        /// <summary>
        /// Confirms the SMS code.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>The person session.</returns>
        public PBPersonSessionDto ConfirmSmsCode(string sessionId, string code)
        {
            string apiEndpoint = "api/p24BusinessAuth/checkOtp";
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "sessionId", sessionId },
                { "otp", code},
            };

            return this.GetPOSTResponse<PBPersonSessionDto>(apiEndpoint, parameters);
        }
    }
}
