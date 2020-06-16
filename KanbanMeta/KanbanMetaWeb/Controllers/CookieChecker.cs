using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanMetaWeb.Controllers
{
    public class CookieChecker
    {
        public bool IsLoggedIn { get; private set; } = false;

        public CookieChecker(IHttpContextAccessor accessor)
        {
            string cookie = accessor.HttpContext.Request.Cookies["LoggedIn"];

            if (cookie != null)
            {
                if (cookie.Contains("true"))
                {
                    IsLoggedIn = true;
                }
                else
                {
                    IsLoggedIn = false;
                }
            }
        }
    }
}
