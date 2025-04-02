using CineTicket.Core.Entities;
using CineTicket.Web.Areas.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CineTicket.Web.Areas.Identity.Controllers
{
    [Area(nameof(Identity))]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

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
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
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
    }
}
