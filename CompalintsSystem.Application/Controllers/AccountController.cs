using AutoMapper;
using CompalintsSystem.Core;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompalintsSystem.Application.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ICompalintRepository compalintService,

            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }




        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FullName = userVM.FullName,
                    UserName = userVM.IdentityNumber,
                    Email = userVM.IdentityNumber,
                    PhoneNumber = userVM.PhoneNumber,
                    GovernorateId = userVM.GovernorateId,
                    IsBlocked = userVM.IsBlocked,
                    SocietyId = userVM.SocietyId,
                    ProfilePicture = userVM.ProfilePicture,


                };
                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, UserRoles.AdminGeneralFederation);
                    return RedirectToAction("Index", "AllUsers");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("تعذر انشاء الحساب ", error.Description);
                }

            }
            return View(userVM);

        }



        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("");


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
                    _ = model.Email;
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user.IsBlocked == false)
                    {
                        if (User.IsInRole("AdminGeneralFederation"))
                        {
                            return RedirectToAction("Index", "GeneralFederation");

                        }
                        else if (User.IsInRole(UserRoles.Beneficiarie))
                        {
                            return RedirectToAction("Index", "Beneficiarie");

                        }
                        else if (User.IsInRole(UserRoles.AdminGovernorate))
                        {
                            return RedirectToAction("Index", "GovManageComplaints");

                        }
                        else if (User.IsInRole(UserRoles.AdminDirectorate))
                        {
                            return RedirectToAction("Report", "DirManageComplaints");

                        }
                        else if (User.IsInRole(UserRoles.AdminSubDirectorate))
                        {
                            return RedirectToAction("Index", "SubManageComplaints");

                        }
                        return RedirectToAction("AccessDenied");
                    }
                    else
                    {
                        // TempData["Error"] = " حسابك موقف!  الرجاء تنشيط الحساب من قبل المسؤول";
                        return RedirectToAction("AccessDenied");

                    }
                }

                TempData["Error"] = " تاكد من صحة كتابة رقم البطاقة او كلمة المرور";
                return View(model);
            }
            return View(model);
        }



        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");


        }





        public async Task<IActionResult> Edit()
        {



            // استرداد المستخدم الحالي
            var currentUser = await _userManager.GetUserAsync(User);

            // التحقق من أن المستخدم الحالي غير مسجل بصفته مستخدم غير معروف
            if (currentUser != null)
            {
                // إنشاء عنصر عرض لتعديل بيانات المستخدم
                var model = new EditUserViewModel
                {
                    FullName = currentUser.FullName,
                    DateOfBirth = currentUser.DateOfBirth,
                    PhoneNumber = currentUser.PhoneNumber,
                    CreatedDate = System.DateTime.Now,
                };
                // عرض العنصر النموذجي في الواجهة الأمامية للمستخدم
                return View(model);
            }
            return View("Empty");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            // التحقق من أن النموذج صالح
            if (!ModelState.IsValid)
            {
                // استرداد المستخدم الحالي
                var currentUser = await _userManager.GetUserAsync(User);

                // التحقق من أن المستخدم الحالي غير مسجل بصفته مستخدم غير معروف
                if (currentUser != null)
                {
                    // تحديث البيانات الجديدة للمستخدم
                    currentUser.FullName = model.FullName;

                    // تحديث معلومات المستخدم في قاعدة البيانات
                    var result = await _userManager.UpdateAsync(currentUser);

                    // التحقق من نجاح عملية التحديث
                    if (result.Succeeded)
                    {
                        // إعادة توجيه المستخدم إلى الصفحة الشخصية بعد تحديث البيانات بنجاح
                        return RedirectToAction("Profile");
                    }

                    // التحقق من وجود أخطاء في عملية التحديث
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    // إعادة توجيه المستخدم إلى صفحة فارغة عندما يحاول المستخدم الوصول إلى هذه الصفحة بدون تسجيل الدخول
                    return View("Empty");
                }
            }

            // إعادة عرض النموذج عندما يكون غير صالح
            return View(model);
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

