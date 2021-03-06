using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Persona.IdentityServer.Models;

namespace Persona.IdentityServer.Services
{
    public class LocalAccountService : IAccountService<ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signInManager;

        public LocalAccountService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<ApplicationUser> FindByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> ValidateCredentialsAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task SignInUserAsync(ApplicationUser user, bool isPersistent = true)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }
    }
}
