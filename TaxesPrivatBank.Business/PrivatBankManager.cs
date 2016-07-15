using TaxesprivatBank.Core.Dto;
using TaxesprivatBank.Core.Helpers;
using TaxesPrivatBank.Business.Interfaces;
using TaxesPrivatBank.Business.Services;

namespace TaxesPrivatBank.Business
{
    /// <summary>
    /// The privat bank manager.
    /// </summary>
    public class PrivatBankManager : ManagerBase, IPrivatBankManager
    {
        /// <summary>
        /// The privat24 service.
        /// </summary>
        private Privat24Service privat24Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivatBankManager"/> class.
        /// </summary>
        public PrivatBankManager()
        {
            this.privat24Service = new Privat24Service(ConfigurationHelper.PBClientID, ConfigurationHelper.PBClientSecret);
        }

        /// <summary>
        /// Gets the session identifier.
        /// </summary>
        /// <returns>
        /// The session.
        /// </returns>
        public PBSessionDto GetSession()
        {
            return this.privat24Service.GetSession();
        }

        /// <summary>
        /// Gets the person session.
        /// </summary>
        /// <param name="sessionID">The session identifier.</param>
        /// <param name="login">The login.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The person session.
        /// </returns>
        public PBPersonSessionDto GetPersonSession(string sessionID, string login, string password)
        {
            return this.privat24Service.GetPersonSession(sessionID, login, password);
        }

        /// <summary>
        /// Confirms the SMS code.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>The person session.</returns>
        public PBPersonSessionDto ConfirmSmsCode(string sessionId, string code)
        {
            return this.privat24Service.ConfirmSmsCode(sessionId, code);
        }
    }
}
