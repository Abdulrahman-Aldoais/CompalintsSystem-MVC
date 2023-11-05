using AutoMapper;
using CompalintsSystem.Core;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompalintsSystem.Application.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppCompalintsContextDB _context;


        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppCompalintsContextDB contex,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = contex;

        }




        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new AddUserViewModel()
            {

                GovernoratesList = await _context.Governorates.ToListAsync()
            };
            ViewBag.ViewGover = model.GovernoratesList.ToArray();
            return View(model);
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            //model.GovernoratesList = await _context.Governorates.ToListAsync();

            if (ModelState.IsValid)
            {

                if (_userService.returntype == 1)
                {
                    TempData["Error"] = _userService.Error;
                    return View(model);
                }
                else if (_userService.returntype == 2)
                {
                    TempData["Error"] = _userService.Error;
                    return View(model);
                }

                await _userService.RegisterAsync(model);

                return RedirectToAction("Login", "Account");


            }
            ViewBag.ViewGover = await _context.Governorates.ToListAsync();

            return View(model);

        }




        //[HttpGet]
        //public IActionResult Login()
        //{
        //    if (_signInManager.IsSignedIn(User))
        //        return RedirectToAction("");


        //    return View();
        //}




        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    TempData["Error"] = null;
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);
        //        if (result.Succeeded)
        //        {
        //            _ = model.Email;
        //            var user = await _userManager.FindByEmailAsync(model.Email);
        //            if (user.IsBlocked == false)
        //            {
        //                if (User.IsInRole("AdminGeneralFederation"))
        //                {
        //                    return RedirectToAction("Index", "GeneralFederation");

        //                }
        //                else if (User.IsInRole(UserRoles.Beneficiarie))
        //                {
        //                    return RedirectToAction("Index", "Beneficiarie");

        //                }
        //                else if (User.IsInRole(UserRoles.AdminGovernorate))
        //                {
        //                    return RedirectToAction("Index", "GovManageComplaints");

        //                }
        //                else if (User.IsInRole(UserRoles.AdminDirectorate))
        //                {
        //                    return RedirectToAction("Report", "DirManageComplaints");

        //                }
        //                else if (User.IsInRole(UserRoles.AdminSubDirectorate))
        //                {
        //                    return RedirectToAction("Index", "SubManageComplaints");

        //                }
        //                return RedirectToAction("AccessDenied");
        //            }
        //            else
        //            {
        //                // TempData["Error"] = " حسابك موقف!  الرجاء تنشيط الحساب من قبل المسؤول";
        //                return RedirectToAction("AccessDenied");

        //            }
        //        }

        //        TempData["Error"] = " تاكد من صحة كتابة رقم البطاقة او كلمة المرور";
        //        return View(model);
        //    }
        //    return View(model);
        //}


        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            TempData["Error"] = null;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (!user.IsBlocked)
                    {
                        return await GetRedirectActionResultForUserRole(user);
                    }
                    else
                    {
                        return RedirectToAction("AccessDenied");
                    }
                }

                TempData["Error"] = "تاكد من صحة كتابة رقم البطاقة او كلمة المرور";
            }

            return View(model);
        }
        private async Task<IActionResult> GetRedirectActionResultForUserRole(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Contains(UserRoles.AdminGeneralFederation))
            {
                return Redirect(Url.Action("Index", "GeneralFederation"));
            }
            else if (userRoles.Contains(UserRoles.Beneficiarie))
            {
                return Redirect(Url.Action("Index", "Beneficiarie"));
            }
            else if (userRoles.Contains(UserRoles.AdminGovernorate))
            {
                return Redirect(Url.Action("Index", "GovManageComplaints"));
            }
            else if (userRoles.Contains(UserRoles.AdminDirectorate))
            {
                return Redirect(Url.Action("Report", "DirManageComplaints"));
            }
            else if (userRoles.Contains(UserRoles.AdminSubDirectorate))
            {
                return Redirect(Url.Action("Index", "SubManageComplaints"));
            }

            return RedirectToAction("Account", "Login");
        }



        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");


        }

        [HttpGet]
        public async Task<IActionResult> GetGovernorates()
        {
            var governorates = await _context.Governorates.ToListAsync();

            var result = governorates.Select(d => new { id = d.Id, name = d.Name }).ToList();

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectoratesByGovernorateId(int governorateId)
        {
            var directorates = await _context.Directorates.Where(d => d.GovernorateId == governorateId).ToListAsync();

            var result = directorates.Select(d => new { id = d.Id, name = d.Name }).ToList();

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubDirectoratesByDirectorateId(int directorateId)
        {
            var subDirectorates = await _context.SubDirectorates.Where(s => s.DirectorateId == directorateId).ToListAsync();

            var result = subDirectorates.Select(s => new { id = s.Id, name = s.Name }).ToList();

            return Json(result);
        }


        //منع الوصول 

        public IActionResult AccessDenied(string returnUrl)
        {
            // التحقق من أن المستخدم غير مسجل في النظام
            if (!_signInManager.IsSignedIn(User))
            {
                // إعادة توجيه المستخدم إلى صفحة تسجيل الدخول عندما يحاول المستخدم الوصول إلى صفحة محظورة بدون تسجيل الدخول
                return RedirectToAction("Account", "Login");
            }

            // إرجاع عرض AccessDenied مع إرجاع العنوان الخاص بالصفحة المحظورة
            ViewData["returnUrl"] = returnUrl;
            return View();

        }




    }

}

