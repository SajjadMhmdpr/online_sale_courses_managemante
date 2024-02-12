using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3.Controllers.user
{
    public class AccountController : Controller
    {
        private UserManager<Model.User> userManager;
        private SignInManager<Model.User> signInManager;

        public AccountController(UserManager<Model.User> userManager, SignInManager<Model.User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task< IActionResult> Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Models.User u)
        {
            var user1 = await userManager.FindByNameAsync(u.username);

            if(user1 !=null)
            {
                ModelState.AddModelError("", "این نام کاربری از قبل ثبت شده است");
                return View(u);
            }


            if(u.password != u.confirmPass)
            {
                ModelState.AddModelError("", "رمز و تکرار آن یکسان نیستند");
                return View(u);
            }


            var user = new Model.User
            {
                name = u.name,
                family = u.family,
                UserName = u.username,
                Email = u.email
            };

            var appResult = await userManager.CreateAsync(user, u.password);

            if (!appResult.Succeeded)
            {
                ModelState.AddModelError("", "");
                return View(u);

            }




            return RedirectToAction(nameof(Register));
        }



        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Models.User u)
        {
            var user = await userManager.FindByNameAsync(u.username);

            if(user == null)
            {
                ModelState.AddModelError("", "کاربری با این نام کاربری پیدا نشد");
                return View(u);

            }

            var signInResult = await signInManager.PasswordSignInAsync(user, u.password, true, false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "کاربری با این مشخصات پیدا نشد");
                return View(u);
            }

            return RedirectToAction("Index", "Home");
        }

        //[Authorize]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");


            //if(User.Identity.IsAuthenticated)  // bedone  [Authorize]
            //{
            //    await signInManager.SignOutAsync();
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }
    }
}
