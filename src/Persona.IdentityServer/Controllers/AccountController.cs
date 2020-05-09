using System;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persona.IdentityServer.Models;
using Persona.IdentityServer.Models.ViewModels;
using Persona.IdentityServer.Services;

namespace Persona.IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService<ApplicationUser> _accountService;
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly IEventService _eventService;
        private readonly IClientStore _clientStoreService;

        public AccountController(
            ILogger<AccountController> logger,
            IAccountService<ApplicationUser> accountService,
            IIdentityServerInteractionService interactionService,
            IEventService eventService,
            IClientStore clientStoreService
        )
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            this._interactionService = interactionService ?? throw new ArgumentNullException(nameof(interactionService));
            this._eventService = eventService ?? throw new ArgumentException(nameof(eventService));
            this._clientStoreService = clientStoreService ?? throw new ArgumentException(nameof(clientStoreService));
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = await this._interactionService.GetAuthorizationContextAsync(returnUrl);
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var loginViewModel = new LoginViewModel
                {

                };
                return View(model);
            }

            var context = await _interactionService.GetAuthorizationContextAsync(model.ReturnUrl);
            var account = await _accountService.FindByUsernameAsync(model.Username);

            if (!await _accountService.ValidateCredentialsAsync(account, model.Password))
            {
                await _eventService.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials", clientId: context?.ClientId));

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            await _accountService.SignInUserAsync(account, model.RememberMe);
            await _eventService.RaiseAsync(new UserLoginSuccessEvent(account.UserName, account.Id, account.UserName, clientId: context?.ClientId));

            if (context != null)
            {
                var client = await _clientStoreService.FindEnabledClientByIdAsync(context.ClientId);
                if (client?.RequirePkce == true)
                {
                    return View("Redirect", new RedirectViewModel { RedirectUrl = context.RedirectUri });
                }
                return Redirect(model.ReturnUrl);
            }
            else if (Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            else if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect("~/");
            }
            else
            {
                // user might have clicked on a malicious link - should be logged
                throw new Exception("invalid return URL");
            }
        }
    }
}
