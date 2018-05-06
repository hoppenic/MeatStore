﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;




namespace BurgerStore.Controllers
{
    public class AccountController : Controller   
    
    {

        SignInManager<IdentityUser> _signInManager;


        //using microsoft.aspnetcore.identity
        public AccountController(SignInManager<IdentityUser> signInManager)
        {

            this._signInManager = signInManager;

        }



        public IActionResult Index()
        {
            return View();
        }


        //Responds on GET /account/register
        public IActionResult Register()
        {
            return View();
        }

        //Responds on POST /account/register
        [HttpPost]
        [ValidateAntiForgeryToken] //this prevents automated scripts from trying to register
        public IActionResult Register(Models.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newEmail = new IdentityUser(model.Email);

                IdentityResult creationResult = this._signInManager.UserManager.CreateAsync(newEmail).Result;
                if (creationResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in creationResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }

            return View();
        }

        //Weekend Challenge here
        //Create the Views and any additional Models required for the functionality below
        //Check the methods on UserManager and SignInManager to figure out how to do this!!
        //Beware of online examples!  Things might be renamed in code you read, or it might be DotNetFramework4.6
        //Update your Layout to display the correct links depending on whether the user is logged in / out


        //responds on /account/signout

        public IActionResult SignOut()
        {
            return View();

        }

        public IActionResult SignIn()
        {
            return View();

        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(Object Model)
        {
            return View();

        }






    }
    }




