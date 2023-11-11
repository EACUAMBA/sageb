using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using sageb.Data;
using sageb.Database.Entities;

namespace sageb.Controllers.AccessControl
{
    public class AccessControlController : Controller
    {
        private readonly ILogger<AccessControlController> _logger;
        private readonly SignInManager<User> _signManager;
        private readonly SqliteDbContext _sqliteDbContext;
        private readonly UserManager<User> _userManager;

        public AccessControlController(
            ILogger<AccessControlController> logger,
            SignInManager<User> signManager,
            SqliteDbContext sqliteDbContext,
            UserManager<User> userManager
            )
        {
            _logger = logger;
            _signManager = signManager;
            _sqliteDbContext = sqliteDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessLogin(LoginModel loginModel)
        {
            _logger.LogInformation("Trying to login user {LoginModel}", loginModel);

            string email = loginModel.Email;
            string password = loginModel.Password;
            bool rememberMe = loginModel.RememberMe;
            string? userName = null;
            User? user = null;

            List<User> userList = this._sqliteDbContext.Users.Where(u => u.Email.Equals(email)).ToList();
            if (userList.IsNullOrEmpty())
            {
                return View("Login", loginModel);
            }
            user = userList[0];
            userName = user.UserName;

            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.UpdateNormalizedEmailAsync(user);
            await _userManager.UpdateNormalizedUserNameAsync(user);
            await _userManager.SetLockoutEnabledAsync(user, true);


            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login", loginModel);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await this._signManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return View("Login");
            }

        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
