using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CompalintsSystem.Core.Interfaces;

namespace CompalintsSystem.Application.Controllers
{
    [Authorize(Roles = "AdminSubDirectorate")]
    public class SubManageComplaintsController : Controller
    {


        private readonly ICompalintRepository _compReop;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public SubManageComplaintsController(

            ICategoryService service,
            ICompalintRepository compReop,
            IUserService userService,
            UserManager<ApplicationUser> userManager,

            IWebHostEnvironment env,

            AppCompalintsContextDB context)
        {

            _compReop = compReop;
            _userService = userService;
            _userManager = userManager;
            _service = service;
            _context = context;
            _env = env;

        }

        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        //------------- عرض الشكاوى المحلولة والمرفوضه والمرفوعه--------------------
        public async Task<IActionResult> Index()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            //var Gov = currentUser?.Governorates.Id;


            var allCompalintsVewi = _compReop.GetAll().Where(g => g.SubDirectorateId == currentUser.SubDirectorateId && g.StagesComplaintId == 1).ToList();
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.Status = ViewBag.StatusCompalints;
            int totalCompalints = allCompalintsVewi.Count();

            ViewBag.totalCompalints = totalCompalints;

            return View(allCompalintsVewi);
        }

        public async Task<IActionResult> AllRejectedComplaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var AllRejectedComplaints = await _compReop.GetAllAsync(
                g => g.Governorate,
                d => d.Directorate,
                s => s.SubDirectorate,
                n => n.StatusCompalint,
                st => st.StagesComplaint);
            var Getrejected = AllRejectedComplaints.Where(g => g.Governorate.Id == currentUser.GovernorateId
            && g.StatusCompalint.Id == 3 && g.StagesComplaint.Id == 4);
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();

            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");

            ViewBag.status = ViewBag.StatusCompalints;
            int totalCompalints = Getrejected.Count();
            //ViewBag.TotalCompalints = Convert.ToInt32(page == 0 ? "false" : totalCompalints);
            ViewBag.totalCompalints = totalCompalints;

            return View(Getrejected);

        }

        public async Task<IActionResult> ViewCompalintDetails(int id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,

            };
            UpComplaintVM UpView = new UpComplaintVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView,
                UpComplaintCauseList = await _context.UpComplaintCauses.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                UpComplaint = UpView,
            };
            return View(VM);
        }


        public async Task<IActionResult> ViewCompalintRejectedDetails(int id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };
            return View(VM);
        }

        public async Task<IActionResult> AllUpComplaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var allComp = _compReop.GetAll().Where(g => g.UserId == currentUser.UserId
            && g.StatusCompalint.Id == 5); ;
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        public async Task<IActionResult> ViewCompalintUpDetails(int id)
        {
            var ComplantList = await _compReop.FindAsync(id);
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,

            };
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,

            };
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };
            return View(VM);
        }
        public async Task<IActionResult> SolutionComplaints()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var SolutionComplaints = await _compReop.GetAllAsync(
                g => g.Governorate,
                d => d.Directorate,
                s => s.SubDirectorate,
                n => n.StatusCompalint,
                st => st.StagesComplaint);
            var Getrejected = SolutionComplaints
                .Where(g => g.SubDirectorateId == currentUser.SubDirectorateId
                && g.StatusCompalintId == 2 && g.StagesComplaintId == 4);
            var compalintDropdownsData = await _service.GetNewCompalintsDropdownsValues();
            ViewBag.StatusCompalints = new SelectList(compalintDropdownsData.StatusCompalints, "Id", "Name");
            ViewBag.TypeComplaints = new SelectList(compalintDropdownsData.TypeComplaints, "Id", "Type");
            ViewBag.status = ViewBag.StatusCompalints;
            int totalCompalints = Getrejected.Count();
            ViewBag.totalCompalints = totalCompalints;

            return View(Getrejected);
        }

        public async Task<IActionResult> RejectedThisComplaint(int id, UploadsComplainte complainte)
        {

            var upComp = await _compReop.FindAsync(id);
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
            if (dbComp != null)
            {

                dbComp.Id = complainte.Id;
                dbComp.StatusCompalintId = 3;
                dbComp.StagesComplaintId = 4;


                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllRejectedComplaints));

        }
        //-------------نــــهـــــــايـــة عرض الشكاوى المحلولة والمرفوضه والمرفوعه --------------------

        // -----------------عرض المستخدمين --------------------------------------------------------------

        public async Task<IActionResult> ViewUsers()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;

            var gov = currentUser.GovernorateId;
            var dir = currentUser.DirectorateId;
            var sub = currentUser.SubDirectorateId;


            var result = await _userService.GetAllAsync(currentIdUser, gov, dir, sub);


            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

        }
        public async Task<IActionResult> BeneficiariesAccount()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var result = await _context.Users.Where(r => r.RoleId == 5 && r.SubDirectorateId == currentUser.SubDirectorateId)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            return View(result.ToList());

        }

        public async Task<IActionResult> AccountRestriction()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;
            var result = _userService.GetAllUserBlockedAsync(currentIdUser);



            return View(result.ToList());

        }

        // ----------------- نــــهـــــــايـــة عرض المستخدمين ---------------------------------------



        // ----------------------- إدارة الشكوى---------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        // ----------------------تقديم حل للشكوى--------------------------------------------------------
        public async Task<IActionResult> AddSolutions(ProvideSolutionsVM model, int id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
                string userRole = role.Value;
                string UserId = claim.Value;
                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                var idComp = model.AddSolution.UploadsComplainteId;
                var solution = new Compalints_Solution()
                {
                    UserId = subuser.Id,
                    SolutionProvName = subuser.FullName,
                    UploadsComplainteId = model.AddSolution.UploadsComplainteId,
                    SolutionProvIdentity = subuser.IdentityNumber,
                    ContentSolution = model.AddSolution.ContentSolution,
                    DateSolution = DateTime.Now,
                    Role = userRole,


                };

                _context.Compalints_Solutions.Add(solution);
                await _context.SaveChangesAsync();


                var upComp = await _compReop.FindAsync(idComp);
                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
                if (dbComp != null)
                {
                    dbComp.StatusCompalintId = 2;
                    dbComp.StagesComplaintId = 4;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SolutionComplaints));

            }

            return NotFound();


        }
        // رفع الشكوى مع سبب الرفع للإدارة العلياء 
        public async Task<IActionResult> UpCompalint(int id, ProvideSolutionsVM model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
                string userRole = role.Value;
                string UserId = claim.Value;
                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                var idComp = model.UpComplaint.UploadsComplainteId;
                var upComplaint = new UpComplaintCause()
                {
                    UserId = subuser.Id,
                    UpProvName = subuser.FullName,
                    UploadsComplainteId = model.UpComplaint.UploadsComplainteId,
                    UpUserProvIdentity = subuser.IdentityNumber,
                    Cause = model.UpComplaint.Cause,
                    DateUp = DateTime.Now,
                    Role = userRole,


                };

                _context.UpComplaintCauses.Add(upComplaint);
                await _context.SaveChangesAsync();


                var upComp = await _compReop.FindAsync(idComp);
                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
                if (dbComp != null)
                {
                    dbComp.StatusCompalintId = 5;
                    dbComp.StagesComplaintId = upComp.StagesComplaintId + 1;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllUpComplaints));



            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectedThisComplaint(ProvideSolutionsVM model, int id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
                string userRole = role.Value;
                string UserId = claim.Value;
                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                var idComp = model.RejectedComplaintVM.UploadsComplainteId;

                var complaintsRejected = new ComplaintsRejected()
                {
                    UserId = subuser.Id,
                    RejectedProvName = subuser.FullName,
                    UploadsComplainteId = model.RejectedComplaintVM.UploadsComplainteId,
                    RejectedUserProvIdentity = subuser.IdentityNumber,
                    reume = model.RejectedComplaintVM.reume,
                    DateSolution = DateTime.Now,
                    Role = userRole,


                };

                _context.ComplaintsRejecteds.Add(complaintsRejected);
                await _context.SaveChangesAsync();


                var upComp = await _compReop.FindAsync(idComp);
                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
                if (dbComp != null)
                {
                    dbComp.StatusCompalintId = 3;
                    dbComp.StagesComplaintId = 4;
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllRejectedComplaints));

            }

            return NotFound();


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddCommunication()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;
            int SubDirctoty = currentUser.SubDirectorateId;
            var communicationDropdownsData = await _compReop.GetAddCommunicationDropdownsValues(SubDirctoty);
            ViewBag.typeCommun = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Type");
            ViewBag.UsersName = new SelectList(communicationDropdownsData.ApplicationUsers, "Id", "FullName");



            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommunication(AddCommunicationVM communication)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                int SubDirctoty = currentUser.SubDirectorateId;
                var communicationDropdownsData = await _compReop.GetAddCommunicationDropdownsValues(SubDirctoty);
                ViewBag.typeCommun = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Type");
                ViewBag.UsersName = new SelectList(communicationDropdownsData.ApplicationUsers, "Id", "Name");


                var currentName = currentUser.FullName;
                var currentPhone = currentUser.PhoneNumber;
                var currentGov = currentUser.GovernorateId;
                var currentDir = currentUser.DirectorateId;
                var currentSub = currentUser.SubDirectorateId;

                await _compReop.CreateCommuncationAsync(new AddCommunicationVM
                {
                    Titile = communication.Titile,
                    NameUserId = communication.NameUserId,
                    reason = communication.reason,
                    CreateDate = communication.CreateDate,
                    TypeCommuncationId = communication.TypeCommuncationId,
                    UserId = currentUser.Id,
                    BenfName = currentName,
                    BenfPhoneNumber = currentPhone,
                    GovernorateId = currentGov,
                    DirectorateId = currentDir,
                    SubDirectorateId = currentSub,

                });

                return RedirectToAction("AllCommunication");
            }
            return View(communication);
        }

        public IActionResult AllCirculars()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Download(int id)
        {
            var selectedFile = await _compReop.FindAsync(id);
            if (selectedFile == null)
            {
                return NotFound();
            }

            //await _compService.IncreamentDownloadCount(id);

            var path = "~/Uploads/" + selectedFile.FileName;
            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");
            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);
        }

        //public async Task<IActionResult> DisbleOrEnableUser(int id)
        //{
        //    await _userService.TogelBlockUserAsync(id);
        //    return RedirectToAction("ViewUsers");


        //}


    }
}

