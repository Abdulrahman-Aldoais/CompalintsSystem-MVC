using AutoMapper;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.Core.ViewModels.Data;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CompalintsSystem.Application.Controllers
{
    [Authorize(Roles = "AdminGeneralFederation,AdminGovernorate,AdminDirectorate,AdminSubDirectorate")]
    public class ManageUsersController : Controller
    {
        //protected abstract void Validate();
        private readonly List<Governorate> _governorates = new List<Governorate>();
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICompalintRepository _compalintRepository;
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper mapper;

        public ManageUsersController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ICompalintRepository compalintService,
            AppCompalintsContextDB context,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _compalintRepository = compalintService;
            _context = context;
            this.mapper = mapper;
            _compalintRepository = compalintService;
        }


        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            var model = new AddUserViewModel()
            {

                GovernoratesList = await _context.Governorates.ToListAsync()
            };
            ViewBag.ViewGover = model.GovernoratesList.ToArray();
            return View(model);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            model.GovernoratesList = await _context.Governorates.ToListAsync();
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            var currentId = currentUser.IdentityNumber;

            if (ModelState.IsValid)
            {
                var userIdentity = await _userManager.FindByEmailAsync(model.IdentityNumber);
                if (userIdentity != null)
                {
                    ModelState.AddModelError("Email", "email aoset");
                    model.GovernoratesList = await _context.Governorates.ToListAsync();
                    ViewBag.ViewGover = model.GovernoratesList.ToArray();
                    return View(model);
                }
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


                await _userService.AddUserAsync(model, currentName, currentId);

                return RedirectToAction("ViewUsers");
            }
            return View(model);
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var users = await _userService.GetAllAsync();
            ViewBag.UserCount = users.Count();

            var user = await _userService.GetByIdAsync((string)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            //_governorates.Clear();
            if (user == null)
            {
                return NotFound();
            }

            var newUser = new EditUserViewModel
            {
                GovernoratesList = await _context.Governorates.ToListAsync(),
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                IdentityNumber = user.IdentityNumber,
                IsBlocked = user.IsBlocked,
                DateOfBirth = user.DateOfBirth,
                GovernorateId = user.Governorate.Id,
                DirectorateId = user.Directorate.Id,
                SubDirectorateId = user.SubDirectorate.Id,
                RoleId = user.RoleId,

            };
            ViewBag.ViewGover = newUser.GovernoratesList.ToArray();
            return View(newUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel user)
        {
            //var users = await _userService.GetAllAsync();
            //ViewBag.UserCount = users.Count();
            user.GovernoratesList = await _context.Governorates.ToListAsync();
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateAsync(id, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ViewUsers");
            }
            return View();
        }

        [AllowAnonymous]

        public async Task<IActionResult> CheckingIdentityNumber(AddUserViewModel model)
        {
            var user = _userManager.FindByEmailAsync(model.IdentityNumber);

            var userr = _context.Users.Where(a => a.IdentityNumber == model.IdentityNumber).FirstOrDefault();
            if (userr == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"يوجد رقم بطاقة   {model.IdentityNumber} من قبل بهذا الرقم ");
            }


        }

        [AllowAnonymous]
        public Task<IActionResult> CheckingPhoneNumber(AddUserViewModel model)
        {


            if (model.PhoneNumber.Length == 9)
            {
                return Task.FromResult<IActionResult>(Json(true));
            }

            else
            {
                return Task.FromResult<IActionResult>(Json($"   موجود من قبل {model.PhoneNumber}رقم الهاتف هذا"));
            }


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

        //[HttpGet]
        //public async Task<IActionResult> GetDirectorateies(int id)
        //{
        //    List<Directorate> directorate = new List<Directorate>();
        //    directorate = await _context.Directorates.Where(m => m.GovernorateId == id).ToListAsync();
        //    return Json(new SelectList(directorate, "Id", "Name"));
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetSubDirectorate(int id)
        //{
        //    List<SubDirectorate> subdirectorate = new List<SubDirectorate>();
        //    subdirectorate = await _context.SubDirectorates.Where(m => m.DirectorateId == id).ToListAsync();
        //    return Json(new SelectList(subdirectorate, "Id", "Name"));
        //}



        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync((string)id, u => u.Governorate, d => d.Directorate, n => n.SubDirectorate);
            if (user != null)
            {
                await _userService.DeleteAsync(id);
                return RedirectToAction("ViewUsers");
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction("ViewUsers");
        }





        public async Task<IActionResult> Block(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = await _userService.TogelBlockUserAsync(id);
                if (result.Success)
                {
                    TempData["Succes"] = result.Message;
                }
                else
                {
                    TempData["Error"] = result.Message;
                }
                return RedirectToAction("ViewUsers", "GeneralFederation");
            }
            TempData["Error"] = "لم يتم العثور على رقم المستخدم";
            return RedirectToAction("ViewUsers", "GeneralFederation");

        }



        [HttpPost]
        public IActionResult Search(InputSearch input)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Search(input.Term);
                return View(result);
            }
            return View();
        }
        public async Task<IActionResult> AccountRestriction()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;
            var result = _userService.GetAllUserBlockedAsync(currentIdUser);



            return View(result.ToList());

        }



        public async Task<IActionResult> UsersCounts()
        {
            var totalUsersCount = await _userService.UserRegistrationCountAsync();
            var month = DateTime.Today.Month;
            var monthUsersCount = await _userService.UserRegistrationCountAsync(month);

            return Json(new { tota = totalUsersCount, month = monthUsersCount });

        }





        private bool UserExists(string id)
        {
            return string.IsNullOrEmpty(_userService.GetByIdAsync(id).ToString());
        }


        //public async Task<IActionResult> ChaingeStatusAsync(int id, bool IsBlocked)
        //{
        //    await _userService.EnableAndDisbleUser(id);
        //    return RedirectToAction("ViewUsers");
        //}



        public async Task<IActionResult> UserReport(string userId)
        {
            var comSolution = _context.Compalints_Solutions.Where(u => u.UserId == userId)
                             .GroupBy(c => c.UploadsComplainteId);
            var ComplaintsRejecteds = _context.Compalints_Solutions.Where(u => u.UserId == userId)
                             .GroupBy(c => c.UploadsComplainteId);
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = new UserReportVM
            {
                UserId = user.Id,
                TotlSolutionComp = comSolution.Count(),
                TotlRejectComp = ComplaintsRejecteds.Count(),
                //Orders = userGroup,
                FullName = user.FullName,
                Gov = user.Governorate.Name,
                Dir = user.Directorate.Name,
                Role = user.RoleName,

            };


            return View(result);
        }



    }
}
