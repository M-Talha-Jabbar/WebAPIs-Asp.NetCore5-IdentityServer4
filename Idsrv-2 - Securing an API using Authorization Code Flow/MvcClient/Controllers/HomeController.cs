using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.Controllers
{
    [Authorize] // Authentication Handshake using OpenID Connect is triggered here when user tries to access the protected controller action. You will see a redirect to the login page of the IdentityServer.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
            // It will clear the local application cookies. In addition it will also make a roundtrip to the IdentityServer to clear the central single sign-on session.

            // So this will clear the local cookie and then redirect to the IdentityServer. The IdentityServer will clear its cookies and then give the user a link to return back to the MVC application.
        }
    }
}
