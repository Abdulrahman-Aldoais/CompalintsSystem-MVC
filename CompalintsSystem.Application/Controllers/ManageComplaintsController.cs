//using CompalintsSystem.Data.Base;
//using CompalintsSystem.Core.ViewModels;
//using CompalintsSystem.Core.Models;
//using CompalintsSystem.Service;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace CompalintsSystem.Controllers
//{
//    [Authorize(Roles = "AdminGeneralFederation,AdminGovernorate,AdminDirectorate")]
//    public class ManageComplaintsController : Controller
//    {

//        private readonly ICompalintRepository _compReop;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IWebHostEnvironment _env;
//        private readonly ICategoryService _service;
//        private readonly AppCompalintsContextDB _context;

//        public ManageComplaintsController(

//            ICategoryService service,
//            ICompalintRepository compReop,
//            UserManager<ApplicationUser> userManager,

//            IWebHostEnvironment env,

//            AppCompalintsContextDB context)
//        {

//            _compReop = compReop;
//            _userManager = userManager;
//            _service = service;
//            _context = context;
//            _env = env;

//        }




//        private string UserId
//        {
//            get
//            {
//                return User.FindFirstValue(ClaimTypes.NameIdentifier);
//            }
//        }




//        public async Task<IActionResult> ViewCompalintDetails(int id)
//        {
//            var ComplantList = await _compReop.FindAsync(id);
//            AddSolutionVM addsoiationView = new AddSolutionVM()
//            {
//                UploadsComplainteId = id,

//            };
//            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
//            {
//                UploadsComplainteId = id,

//            };
//            ProvideSolutionsVM VM = new ProvideSolutionsVM
//            {
//                compalint = ComplantList,
//                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),
//                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
//                RejectedComplaintVM = rejectView,
//                AddSolution = addsoiationView
//            };
//            return View(VM);
//        }

//        public async Task<IActionResult> UpCompalint(int id, UploadsComplainte complainte)
//        {

//            var upComp = await _compReop.FindAsync(id);
//            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
//            if (dbComp != null)
//            {

//                dbComp.Id = complainte.Id;
//                dbComp.StagesComplaintId = dbComp.StagesComplaintId + 1;


//                await _context.SaveChangesAsync();
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction("AllComplaints");

//        }

//        public async Task<IActionResult> RejectedThisComplaint(int id, UploadsComplainte complainte)
//        {

//            var upComp = await _compReop.FindAsync(id);
//            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
//            if (dbComp != null)
//            {

//                dbComp.Id = complainte.Id;
//                dbComp.StatusCompalintId = 3;


//                await _context.SaveChangesAsync();
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(ViewAllRejectedComplaints));

//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> AddSolutions(ProvideSolutionsVM model, int id)
//        {
//            if (ModelState.IsValid)
//            {
//                var currentUser = await _userManager.GetUserAsync(User);
//                var claimsIdentity = (ClaimsIdentity)User.Identity;
//                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
//                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
//                string userRole = role.Value;
//                string UserId = claim.Value;
//                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
//                var idComp = model.AddSolution.UploadsComplainteId;
//                var solution = new Compalints_Solution()
//                {
//                    UserId = subuser.Id,
//                    SolutionProvName = subuser.FullName,
//                    UploadsComplainteId = model.AddSolution.UploadsComplainteId,
//                    SolutionProvIdentity = subuser.IdentityNumber,
//                    ContentSolution = model.AddSolution.ContentSolution,
//                    DateSolution = DateTime.Now,
//                    Role = userRole,


//                };

//                _context.Compalints_Solutions.Add(solution);
//                await _context.SaveChangesAsync();


//                var upComp = await _compReop.FindAsync(idComp);
//                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
//                if (dbComp != null)
//                {
//                    dbComp.StatusCompalintId = 2;
//                    dbComp.StagesComplaintId = 4;
//                    await _context.SaveChangesAsync();
//                }

//                await _context.SaveChangesAsync();
//                return RedirectToAction("AllComplaints");

//            }

//            return NotFound();


//        }



//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> RejectedThisComplaint(ProvideSolutionsVM model, int id)
//        {
//            if (ModelState.IsValid)
//            {
//                var currentUser = await _userManager.GetUserAsync(User);
//                var claimsIdentity = (ClaimsIdentity)User.Identity;
//                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
//                var role = claimsIdentity.FindFirst(ClaimTypes.Role);
//                string userRole = role.Value;
//                string UserId = claim.Value;
//                var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
//                var idComp = model.RejectedComplaintVM.UploadsComplainteId;

//                var complaintsRejected = new ComplaintsRejected()
//                {
//                    UserId = subuser.Id,
//                    RejectedProvName = subuser.FullName,
//                    UploadsComplainteId = model.RejectedComplaintVM.UploadsComplainteId,
//                    RejectedUserProvIdentity = subuser.IdentityNumber,
//                    reume = model.RejectedComplaintVM.reume,
//                    DateSolution = DateTime.Now,
//                    Role = userRole,


//                };

//                _context.ComplaintsRejecteds.Add(complaintsRejected);
//                await _context.SaveChangesAsync();


//                var upComp = await _compReop.FindAsync(idComp);
//                var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
//                if (dbComp != null)
//                {
//                    dbComp.StatusCompalintId = 3;
//                    dbComp.StagesComplaintId = 4;
//                    await _context.SaveChangesAsync();
//                }

//                await _context.SaveChangesAsync();
//                return RedirectToAction("AllComplaints");

//            }

//            return NotFound();


//        }



//    }
//}
