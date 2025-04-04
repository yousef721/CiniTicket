using AutoMapper;
using CineTicket.Application.ViewModels.IdentityViewModels;
using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CineTicket.Web.Areas.Identity.Controllers
{
    [Area(nameof(Identity))]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper; 
        private readonly IIdentityServices _identityServices;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, IIdentityServices identityServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _identityServices = identityServices;
        }

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<ApplicationUser>(model);

                // Create unique user name
                user.UserName = await _identityServices.CreateUserNameUniqueAsync(model.FirstName);

                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home", new { area = nameof(Customer) });
                }
                foreach (var error in result.Errors)
                {
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        #endregion
        
        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginVM.Account) ?? await _userManager.FindByEmailAsync(loginVM.Account);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { area = nameof(Customer) });
                    }
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Account locked out. Please try again later.");
                        return View(loginVM);
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Email Or Password");
            }
            return View(loginVM);
        }
        #endregion

        #region Logout
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        #endregion
    }
}
