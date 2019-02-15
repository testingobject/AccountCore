using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountCore.DataModels;
using AccountCore.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGPC.Helpers;
using SGPC.ViewModels;

namespace SGPC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager accountManager;

        public AccountController(IAccountManager _accountManager)
        {
            accountManager = _accountManager;
        }

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isRegisted; string[] errorMessage;
            (isRegisted, errorMessage) = await RegisterUser(model);
            if (isRegisted)
            {
                ViewBag.Message = "Your Registration Was Successfull.";
                return View();
            }
            else
            {
                ViewBag.ErrorList = errorMessage;
                return View(model);
            }
        }

        public async Task<(bool, string[])> RegisterUser(RegisterViewModel model)
        {
            bool isRegisted = false;
            IEnumerable<string> role = new string[] { Enums.Role.User.ToString() };
            ApplicationUsers _user = new ApplicationUsers();
            _user.UserName = model.Email;
            _user.Email = model.Email;
            _user.FirstName = model.FirstName;
            _user.LastName = model.LastName;
            (bool success, string[] error) = await accountManager.CreateUserAsync(_user, role, model.Password);
            if (success)
            {
                _user = await accountManager.GetUserByEmailAsync(_user.Email);
                if (_user != null)
                {
                }
                isRegisted = true;
            }
            return (isRegisted, error);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isAuthorizeed; bool isAdmin; string errorMessage;
            (isAuthorizeed, isAdmin, errorMessage) = await LoginUser(model);
            if (isAuthorizeed)
            {
                return RedirectToAction("Dashboard", "Home");
                //ViewBag.Message = "Your Login Successfull.";
                //return View();
            }
            else
            {
                ViewBag.ErrorList = errorMessage;
                return View(model);
            }
            return View();
        }

        public async Task<(bool, bool, string)> LoginUser(LoginViewModel model)
        {
            bool isAuthorizeed = false;
            bool isAdmin = false;
            string errorMessage = string.Empty;
            ApplicationUsers _user = await accountManager.GetUserByUserNameAsync(model.UserName);
            if (_user != null)
            {
                var isPasswordCorrect = await accountManager.CheckPasswordAsync(_user, model.Password);
                if (isPasswordCorrect)
                {

                    var roles = await accountManager.GetUserRolesAsync(_user);
                    if(roles.Contains(Enums.Role.Admin.ToString()))
                    {
                        isAdmin = true;
                    }
                    isAuthorizeed = true;
                }
                else
                {
                    errorMessage = Resources.Common.PasswordIncorrect;
                }
            }
            else
            {
                errorMessage = Resources.Common.UserNameIncorrect;
            }
            if (isAuthorizeed)
            {
                await accountManager.SignInAsync(_user, true);
                string id = accountManager.CurrentUserId;
                var response = HttpContext.User;
            }
            return (isAuthorizeed, isAdmin, errorMessage);
        }

        #endregion

        #region LOGOUT
        public async Task<IActionResult> Logout()
        {
            await accountManager.SignOutAsync();
            return RedirectToActionPermanent("Login", "Account");
        }
        #endregion


    }
}