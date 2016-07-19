using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxesPrivatBank.Helpers
{
    public static class CookieHelper
    {
        /// <summary>
        /// The pb session identifier cookie name.
        /// </summary>
        private const string PBSessionIDCookieName = "pbSessionID";

        /// <summary>
        /// Gets or sets the pb session identifier.
        /// </summary>
        public static string PBSessionID
        {
            get
            {
                return HttpContext.Current.Request.Cookies[PBSessionIDCookieName].Value;
            }
            set
            {
                HttpContext.Current.Response.Cookies.Remove(PBSessionIDCookieName);
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(PBSessionIDCookieName, value));
            }
        }
    }
}