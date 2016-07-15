using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxesprivatBank.Core.Dto;
using TaxesPrivatBank.Business;
using TaxesPrivatBank.Business.Interfaces;

namespace TaxesPrivatBank.Controllers
{
    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// The pb session identifier cookie name.
        /// </summary>
        private const string PBSessionIDCookieName = "pbSessionID";

        /// <summary>
        /// The privat bank manager
        /// </summary>
        private IPrivatBankManager privatBankManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
        {
            this.privatBankManager = new PrivatBankManager();
        }

        // GET: Account
        public ActionResult LoginToPB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginToPB(string login, string password)
        {
            ActionResult result = null;
            PBSessionDto session = this.privatBankManager.GetSession();
            PBPersonSessionDto personSession = this.privatBankManager
                .GetPersonSession(session.ID, login, password);
            this.Response.Cookies.Remove(PBSessionIDCookieName);
            this.Response.Cookies.Add(new HttpCookie(PBSessionIDCookieName, personSession.ID));
            if (personSession.Message.StartsWith("Authentication successful"))
            {
                result = this.RedirectToAction("Index", "Home", null);
            }
            else
            {
                result = this.RedirectToAction("ConfirmCode", "Account");
            }

            return result;
        }

        public ActionResult ConfirmCode()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ConfirmCode(string code)
        {
            string sessionID = this.Request.Cookies[PBSessionIDCookieName].Value;
            PBPersonSessionDto personSession = this.privatBankManager.ConfirmSmsCode(sessionID, code);
            return this.RedirectToAction("Index", "Home", null);
        }
    }
}