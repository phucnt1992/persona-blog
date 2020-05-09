using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Persona.IdentityServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger
        )
        {
            this._logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
