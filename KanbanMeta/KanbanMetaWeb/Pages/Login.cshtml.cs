using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KanbanMetaWeb.Controllers;
using Microsoft.AspNetCore.Identity;
using KanbanMetaWeb.Models;
using Microsoft.AspNetCore.Http;
using KanbanMetaWeb.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

namespace KanbanMetaWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public string userCookie { get; private set; }
        public bool loginFaled { get; private set; } = false;

        private readonly ILogger<LoginModel> _logger;

        private readonly IUserManager _userService;

        public LoginModel(ILogger<LoginModel> logger, IUserManager userService)
        {
            _logger = logger;
            _userService= userService;
        }


        public void OnGet()
        {
            userCookie = Request.Cookies["LoggedIn"];
            if (userCookie != null)
            {
                Response.Cookies.Delete("LoggedIn");
                Response.Redirect("Login");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var users = await _userService.GetUsers();

            foreach (var u in users)
            {
                if(u.Email == user.Email && u.Password == user.Password)
                {
                    LogUserIn();
                    return RedirectToPage("Privacy");
                }
                else
                {
                    loginFaled = true;
                    return RedirectToPage("Login");
                }
            }
            return RedirectToPage("Login");
        }

        private void LogUserIn()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(15)

            };
            Response.Cookies.Append("LoggedIn", "true", cookieOptions);

            userCookie = Request.Cookies["LoggedIn"];
        }
    }
}
