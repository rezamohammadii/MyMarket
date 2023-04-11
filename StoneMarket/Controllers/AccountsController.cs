﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using StoneMarket.Core.Interfaces;
using StoneMarket.Core.Services;
using StoneMarket.Core.ViewModels;
using StoneMarket.Core.Classes;

using StoneMarket.AccessLayer.Entity;

using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace StoneMarket.Controllers
{
    public class AccountsController : Controller
    {
        private IAccount _account;
        private IViewRenderService _render;

        private PersianCalendar pc = new PersianCalendar();

        public AccountsController(IAccount account, IViewRenderService render)
        {
            _account = account;
            _render = render;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_account.ExistsMobileNumber(viewModel.Mobile))
                {
                    // Go To Login
                }
                else
                {
                    User user = new User()
                    {
                        Mobile = viewModel.Mobile,
                        ActiveCode = CodeGenerators.ActiveCode(),
                        Code = null,
                        Date = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                             "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00"),
                        FullName = null,
                        IsActive = false,
                        Password = HashGenerators.MD5Encoding(viewModel.Password),
                        RoleId = _account.GetMaxRole()
                    };

                     _account.AddUser(user);

                    try
                    {
                        MessageSender sender = new MessageSender();

                      //  sender.SMS(viewModel.Mobile, "به فروشگاه اینترنتی خوش آمدید" + Environment.NewLine + "کد فعالسازی : " + user.ActiveCode);
                    }
                    catch
                    {

                    }

                    return RedirectToAction(nameof(Activate));
                }
            }

            return View(viewModel);
        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string hashPassword =  HashGenerators.MD5Encoding(viewModel.Password);

                User user = _account.LoginUser(viewModel.Mobile, hashPassword);

                if (user != null)
                {
                    if (user.Role.Name == "فروشگاه")
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Mobile)
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = true
                        };

                        HttpContext.SignInAsync(principal, properties);

                        return RedirectToAction("Dashboard", "Panel");
                    }
                    else
                    {
                        if (user.IsActive)
                        {
                            var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Mobile)
                        };

                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);

                            var properties = new AuthenticationProperties()
                            {
                                IsPersistent = true
                            };

                             HttpContext.SignInAsync(principal, properties);

                            if (user.Role.Name == "کاربر")
                            {
                                return RedirectToAction("Dashboard", "Home");
                            }
                            else
                            {
                                
                                return RedirectToAction("Dashboard", "Admin");
                            }
                        }
                        else
                        {
                            //return RedirectToAction(nameof(Activation));
                        }
                    }


                }
                else
                {
                    ModelState.AddModelError("Password", "مشخصات کاربری اشتباه است");
                }
            }

            return View(viewModel);
        }
        public IActionResult Activate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Activate(ActivateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_account.ActivateUser(viewModel.ActiveCode))
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ModelState.AddModelError("ActiveCode", "کد فعالسازی شما معتبر نیست");
                }
            }

            return View(viewModel);
        }

        public IActionResult Forget()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forget(ForgetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_account.ExistsMobileNumber(viewModel.Mobile))
                {
                    try
                    {
                        MessageSender sender = new MessageSender();

                        sender.SMS(viewModel.Mobile, "امکان تغییر کلمه عبور با کد تایید " + _account.GetUserActiveCode(viewModel.Mobile));
                    }
                    catch
                    {

                    }

                    return RedirectToAction(nameof(Reset));
                }
                else
                {
                    ModelState.AddModelError("Mobile", "کاربری با این شماره پیدا نشد");
                }
            }

            return View(viewModel);
        }

        public IActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reset(ResetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_account.ResetPassword(viewModel.ActiveCode, viewModel.Password))
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ModelState.AddModelError("ActiveCode", "کد تایید شما اشتباه است");
                }
            }

            return View(viewModel);
        }

        public IActionResult Store()
        {
            ViewBag.MyMessage = false;

            return View();
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }
    }
}