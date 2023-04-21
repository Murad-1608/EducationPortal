using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        UserManager<AppUser> userManager { get; }
        SignInManager<AppUser> signInManager { get; }

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {

           this.userManager = userManager;
           this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser userEmail = await userManager.FindByEmailAsync(loginModel.Email);
                AppUser userName = await userManager.FindByNameAsync(loginModel.Email);
                
                AppUser user = userName ?? userEmail;

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectPermanent("/user/book");
                    }
                }
            }
            ModelState.AddModelError(nameof(loginModel.Password), "İstifadəçi adı və ya parol yanlışdır");
            return View(loginModel);

        }

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
