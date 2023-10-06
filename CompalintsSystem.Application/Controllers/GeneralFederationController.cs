using CompalintsSystem.Core;
using CompalintsSystem.Core.Constants;
using CompalintsSystem.Core.Hubs;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.Statistics;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.EF.DataBase;
using ComplantSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NToastNotify;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static CompalintsSystem.Core.HelperModal;

namespace CompalintsSystem.Application.Controllers
{

    [Authorize(Policy = "AdminPolicy")]
    public class GeneralFederationController : Controller
    {

        //private readonly ICompalintRepository _unitOfWork.CompalinteRepo;
        private readonly IUnitOfWork _unitOfWork;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<NotefcationHub> notificationHub;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _service;
        private readonly AppCompalintsContextDB _context;

        public GeneralFederationController(

            ICategoryService service,
            //ICompalintRepository compReop,
            IUnitOfWork unitOfWork,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            IHubContext<NotefcationHub> notificationHub,
            IWebHostEnvironment env,
            IToastNotification toastNotification,
            AppCompalintsContextDB context)
        {

            //_unitOfWork.CompalinteRepo = compReop;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            this.notificationHub = notificationHub;
            _service = service;
            _context = context;
            _env = env;
            _toastNotification = toastNotification;
        }


        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }



        public async Task<IActionResult> Index()
        {
            var allComp = await _unitOfWork.Compalinte.GetAllAsync(g => g.Governorate);
            var result = await _unitOfWork.User.GetAllAsync(h => h.Governorate);
            var compSolv = allComp.Where(r => r.StatusCompalintId == 2);

            int totalcompSolv = compSolv.Count();
            int totalUsers = result.Count();
            int totalComp = allComp.Count();

            ViewBag.totalcompSolv = totalcompSolv;
            ViewBag.totalUsers = totalUsers;
            ViewBag.totalComp = totalComp;

            //------------- أحصائيات بالمستخدمين في كل محافظة --------------------//


            List<UsersInStatistic> usersIn = new List<UsersInStatistic>();
            usersIn = ViewBag.totalGovermentuser;

            List<ApplicationUser> applicationUsers = await _context.Users

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalUsers = applicationUsers.Count();

            ViewBag.Users = TotalUsers;

            //total Govermentuser
            ViewBag.totalGovermentuser = applicationUsers.GroupBy(j => j.GovernorateId).Select(g => new UsersInStatistic
            {
                Name = g.First().Governorate.Name,
                totalUsers = g.Count().ToString(),
                Users = (g.Count() * 100) / TotalUsers


            }).ToList();



            //------------- نـــــهاية أحصائيات بالمستخدمين --------------------//


            //-------------أحصائيات انواع الشكاوى --------------------//

            // استرداد جميع شكاوى الرفع من قاعدة البيانات مع تضمين نوع الشكوى
            List<UploadsComplainte> compalints = await _context.UploadsComplaintes
                .Include(su => su.TypeComplaint).ToListAsync();

            // إنشاء قائمة للاحصائيات التي سيتم عرضها في المخطط البياني
            List<TypeCompalintStatistic> typeCompalints = new List<TypeCompalintStatistic>();

            // استرداد القائمة من ViewBag
            typeCompalints = ViewBag.GrapComplanrType;

            // حساب إجمالي عدد شكاوى الرفع
            int totalcomplant = compalints.Count();

            // إضافة إجمالي عدد شكاوى الرفع إلى ViewBag
            ViewBag.Totalcomplant = totalcomplant;

            // تجميع الشكاوى الرفع حسب نوعها وإنشاء قائمة من الإحصائيات
            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId)
                .Select(g => new TypeCompalintStatistic
                {
                    Name = g.First().TypeComplaint.Type,
                    TotalCount = g.Count().ToString(),
                    TypeComp = (g.Count() * 100) / totalcomplant
                }).ToList();




            //------------- نهاية أحصائيات انواع الشكاوى --------------------//


            //-------------أحصائيات حالات الشكاوى --------------------//


            // استرداد جميع شكاوى الرفع من قاعدة البيانات مع تضمين حالة الشكوى
            List<UploadsComplainte> stutuscompalints = await _context.UploadsComplaintes
                .Include(su => su.StatusCompalint).ToListAsync();

            // إنشاء قائمة للاحصائيات التي سيتم عرضها في المخطط البياني
            List<StutusCompalintStatistic> stutusCompalints = new List<StutusCompalintStatistic>();

            // استرداد القائمة من ViewBag
            stutusCompalints = ViewBag.GrapComplanrStutus;

            // حساب إجمالي عدد شكاوى الرفع
            int totalStutuscomplant = stutuscompalints.Count();

            // إضافة إجمالي عدد شكاوى الرفع إلى ViewBag
            ViewBag.TotalStutusComplant = totalStutuscomplant;

            // تجميع الشكاوى الرفع حسب حالتها وإنشاء قائمة من الإحصائيات
            ViewBag.GrapComplanrStutus = stutuscompalints.GroupBy(s => s.StatusCompalintId)
                .Select(g => new StutusCompalintStatistic
                {
                    //id = 
                    Name = g.First().StatusCompalint.Name,
                    TotalCountStutus = g.Count().ToString(),
                    stutus = (g.Count() * 100) / totalStutuscomplant
                }).ToList();
            //------------- نهاية أحصائيات حالات الشكاوى --------------------//



            //-------------  أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//

            List<ApplicationUser> usersRoles = await _context.Users.Include(x => x.UserRoles).ToListAsync();


            //Totalcountuser
            int totalCountByRole = applicationUsers.Count();

            ViewBag.TotalCountByRoles = totalCountByRole;

            // show Name Role Rether Than Id
            var Roles = _context.Roles.ToList();
            var x = from r in Globals.RolesLists
                    join u in usersRoles
                    on r.Id equals u.RoleId
                    select new ApplicationUser
                    {
                        RoleName = r.Name,
                        UserRoles = u.UserRoles
                    };

            List<UserByRolesStatistic> gtus = new List<UserByRolesStatistic>();
            gtus = ViewBag.UserByRoles;

            //total Users By Role
            ViewBag.UserByRoles = x.GroupBy(j => j.RoleName).Select(g => new UserByRolesStatistic
            {
                RoleName = g.First().RoleName,
                TotalCount = g.Count().ToString(),
                RolsTot = (g.Count() * 100) / totalCountByRole
            }).ToList();




            //------------------ نهاية أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//


            //-------------  أحصائيات انواع اليلاغات    --------------------//



            List<UsersCommunication> communcations = await _context.UsersCommunications
                .Include(su => su.TypeCommunication).ToListAsync();
            List<TypeCommunicationStatistic> TotalTypeCommuncations = new List<TypeCommunicationStatistic>();

            int totalCommunication = communcations.Count();

            TotalTypeCommuncations = ViewBag.typeCommun;

            ViewBag.TypeCommuncations = communcations.GroupBy(x => x.TypeCommunication).Select(g => new TypeCommunicationStatistic
            {
                Name = g.First().TypeCommunication.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalCommunication
            }).ToList();

            //------------- نهاية أحصائيات انواع اليلاغات --------------------//


            //-------------  أحصائيات عدد اليلاغات    --------------------//


            List<TotalCommunicationStatistic> communicationsIn = new List<TotalCommunicationStatistic>();
            communicationsIn = ViewBag.totalcommunications;

            List<UsersCommunication> communications = await _context.UsersCommunications

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalCommun = communications.Count();

            ViewBag.Commun = TotalCommun;

            //total Govermentuser
            ViewBag.totalcommunications = communications.GroupBy(j => j.GovernorateId).Select(g => new TotalCommunicationStatistic
            {
                Name = g.First().Governorate.Name,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / TotalUsers

            }).ToList();

            //------------- نهاية أحصائيات عدد اليلاغات --------------------//

            return View();
        }

        public async Task<IActionResult> PrintReports()
        {



            //------------- أحصائيات بالمستخدمين في كل محافظة --------------------//


            List<UsersInStatistic> usersIn = new List<UsersInStatistic>();
            usersIn = ViewBag.totalGovermentuser;

            List<ApplicationUser> applicationUsers = await _context.Users

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalUsers = applicationUsers.Count();

            ViewBag.Users = TotalUsers;

            //total Govermentuser
            ViewBag.totalGovermentuser = applicationUsers.GroupBy(j => j.GovernorateId).Select(g => new UsersInStatistic
            {
                Name = g.First().Governorate.Name,
                totalUsers = g.Count().ToString(),
                Users = (g.Count() * 100) / TotalUsers


            }).ToList();



            //------------- نـــــهاية أحصائيات بالمستخدمين --------------------//


            //-------------أحصائيات انواع الشكاوى --------------------//



            List<UploadsComplainte> compalints = await _context.UploadsComplaintes
                .Include(su => su.TypeComplaint).ToListAsync();
            List<TypeCompalintStatistic> typeCompalints = new List<TypeCompalintStatistic>();
            typeCompalints = ViewBag.GrapComplanrType;

            int totalcomplant = compalints.Count();
            ViewBag.Totalcomplant = totalcomplant;

            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId).Select(g => new TypeCompalintStatistic
            {
                Name = g.First().TypeComplaint.Type,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / totalcomplant
            }).ToList();




            //------------- نهاية أحصائيات انواع الشكاوى --------------------//


            //-------------أحصائيات حالات الشكاوى --------------------//


            List<UploadsComplainte> stutuscompalints = await _context.UploadsComplaintes
                .Include(su => su.StatusCompalint).ToListAsync();
            List<StutusCompalintStatistic> stutusCompalints = new List<StutusCompalintStatistic>();
            stutusCompalints = ViewBag.GrapComplanrStutus;

            int totalStutuscomplant = stutuscompalints.Count();
            ViewBag.TotalStutusComplant = totalStutuscomplant;

            ViewBag.GrapComplanrStutus = stutuscompalints.GroupBy(s => s.StatusCompalintId).Select(g => new StutusCompalintStatistic
            {
                //id = 
                Name = g.First().StatusCompalint.Name,
                TotalCountStutus = g.Count().ToString(),
                stutus = (g.Count() * 100) / totalStutuscomplant
            }).ToList();


            //------------- نهاية أحصائيات حالات الشكاوى --------------------//



            //-------------  أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//

            List<ApplicationUser> UsersRoles = await _context.Users.Include(x => x.UserRoles).ToListAsync();

            //Totalcountuser
            int totalCountByRole = applicationUsers.Count();

            ViewBag.TotalCountByRoles = totalCountByRole;

            // show Name Role Rether Than Id
            var Roles = _context.Roles.ToList();
            var x = from r in Globals.RolesLists
                    join u in UsersRoles
                    on r.Id equals u.RoleId
                    select new ApplicationUser
                    {
                        RoleName = r.Name,
                        UserRoles = u.UserRoles
                    };

            //total Users By Role
            ViewBag.totalUserByRoles = x.GroupBy(j => j.RoleName).Select(g => new UserByRolesStatistic
            {
                RoleName = g.First().RoleName,
                TotalCount = g.Count().ToString(),
                RolsTot = (g.Count() * 100) / totalCountByRole

            }).ToList();


            List<UserByRolesStatistic> gtus = new List<UserByRolesStatistic>();
            gtus = ViewBag.totalUserByRoles;


            //------------------ نهاية أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//


            //-------------  أحصائيات انواع اليلاغات    --------------------//

            // استرداد جميع سجلات الاتصال الموجودة مع بيانات نوع الاتصال المرتبطة بها
            List<UsersCommunication> communcations = await _context.UsersCommunications
                .Include(su => su.TypeCommunication).ToListAsync();

            // إنشاء قائمة جديدة لتخزين نتائج الإحصائيات
            List<TypeCommunicationStatistic> TotalTypeCommuncations = new List<TypeCommunicationStatistic>();

            // حساب إجمالي عدد الاتصالات
            int totalCommunication = communcations.Count();

            // تعيين القيمة الإجمالية لعدد الاتصالات
            TotalTypeCommuncations = ViewBag.typeCommun;

            // تحديد الإحصائيات لكل نوع اتصال وإضافتها إلى قائمة الإحصائيات
            ViewBag.TypeCommuncations = communcations.GroupBy(x => x.TypeCommunication).Select(g => new TypeCommunicationStatistic
            {
                Name = g.First().TypeCommunication.Type, // اسم نوع الاتصال
                TotalCount = g.Count().ToString(), // عدد الاتصالات المماثلة
                TypeComp = (g.Count() * 100) / totalCommunication // نسبة الاتصالات المماثلة
            }).ToList();




            //------------- نهاية أحصائيات انواع اليلاغات --------------------//


            //-------------  أحصائيات عدد اليلاغات    --------------------//


            List<TotalCommunicationStatistic> communicationsIn = new List<TotalCommunicationStatistic>();
            communicationsIn = ViewBag.totalcommunications;

            List<UsersCommunication> communications = await _context.UsersCommunications

                .Include(su => su.Governorate).ToListAsync();

            //Totalcountuser
            int TotalCommun = communications.Count();

            ViewBag.Commun = TotalCommun;

            //total Govermentuser
            ViewBag.totalcommunications = communications.GroupBy(j => j.GovernorateId).Select(g => new TotalCommunicationStatistic
            {
                Name = g.First().Governorate.Name,
                TotalCount = g.Count().ToString(),
                TypeComp = (g.Count() * 100) / TotalUsers

            }).ToList();

            //------------- نهاية أحصائيات عدد اليلاغات --------------------//
            return View();
        }



        public async Task<IActionResult> AllComplaints()
        {
            var allComp = await _unitOfWork.Compalinte.GetAllByOrderAsync(
                d => d.UploadDate,
                 OrderBy.Descending,
                g => g.Governorate,
                g => g.StatusCompalint,
                g => g.TypeComplaint
                );
            var totaleComp = allComp.Count(); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllRejectedComplaints()
        {
            var allComp = await _unitOfWork.Compalinte.GetAllAsync(
                s => s.StatusCompalintId == 3,//جلب كافة الشكاوى بهذا الشرط
                g => g.Governorate);

            var totaleComp = allComp.Count();
            ViewBag.totaleComp = totaleComp;
            return View(allComp);

        }

        public async Task<IActionResult> AllUpComplaints()
        {
            var allComp = await _unitOfWork.Compalinte.GetByCondationAndOrderAsync(
                 s => s.StatusCompalintId == 3,//جلب كافة الشكاوى بهذا الشرط
                 d => d.UploadDate,
                 OrderBy.Descending,
                 g => g.Governorate // تضمين جدول المحافظات

                );
            var totaleComp = allComp.Count(s => s.StatusCompalintId.Equals(3));
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }

        public async Task<IActionResult> ViewCompalintUpDetails(int id)
        {
            // استرداد بيانات الشكوى المرتبطة بالمعرف المحدد
            var ComplantList = await _unitOfWork.Compalinte.FaindAsync(
                i => i.Id.Equals(id),
                g => g.Governorate,
                s => s.StatusCompalint,
                f => f.TypeComplaint,
                d => d.Directorate,
                su => su.SubDirectorate,
                st => st.StagesComplaint
            );

            // إنشاء عنصر عرض لإضافة الحلول
            AddSolutionVM addsoiationView = new AddSolutionVM()
            {
                UploadsComplainteId = id,
            };

            // إنشاء عنصر عرض للشكاوى المرفوضة
            ComplaintsRejectedVM rejectView = new ComplaintsRejectedVM()
            {
                UploadsComplainteId = id,
            };

            // إنشاء عنصر عرض لبيانات الشكوى والحلول المرتبطة بها
            ProvideSolutionsVM VM = new ProvideSolutionsVM
            {
                compalint = ComplantList,
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync(),

                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };

            // عرض العنصر النموذجي في الواجهة الأمامية للمستخدم
            return View(VM);
        }
        public async Task<IActionResult> SolutionComplaints()
        {
            var allComp = await _unitOfWork.Compalinte.GetByCondationAndOrderAsync(
                 s => s.StatusCompalintId == 2,// condation 
                 d => d.UploadDate,
                 OrderBy.Descending,
                 g => g.Governorate,
                 s => s.StatusCompalint,
                 f => f.TypeComplaint
                  );
            var totaleComp = allComp.Count(s => s.StatusCompalintId.Equals(2)); ;
            ViewBag.totaleComp = totaleComp;
            return View(allComp);
        }




        // عرض المستخدمين من غير المزارعين
        public async Task<IActionResult> ViewUsers()
        {

            var result = await _context.Users.Where(r => r.RoleId != 5)
                .OrderByDescending(d => d.CreatedDate)
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate)
                .ToListAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

        }

        public async Task<IActionResult> ViewUsers2()
        {
            var result = await _context.Users.Where(r => r.RoleId != 5)
                .OrderByDescending(d => d.CreatedDate)
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate)
                .ToListAsync();
            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            //return View(await PaginatedList<ApplicationUser>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(result.ToList());

        }


        // GET: Users/Create
        public async Task<IActionResult> Create()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var model = new AddUserViewModel()
            {
                GovernoratesList = await _context.Governorates.ToListAsync(),
            };
            ViewBag.ViewGover = model.GovernoratesList.ToArray();

            return View(model);
        }

        // تأكد من أن النموذج يتم الإرسال به بطريقة POST وأنه صالح
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            // استرداد قائمة المحافظات من قاعدة البيانات
            model.GovernoratesList = await _context.Governorates.ToListAsync();

            // استرداد المستخدم الحالي
            var currentUser = await _userManager.GetUserAsync(User);

            // الحصول على اسم المستخدم ورقم الهوية الحاليين
            var currentName = currentUser.FullName;
            var currentId = currentUser.IdentityNumber;

            try
            {
                // تحميل الصورة المرفقة مع النموذج
                UploadImage(model);

                // التحقق من أن النموذج صالح
                if (ModelState.IsValid)
                {
                    if (_unitOfWork.User.returntype == 1)
                    {
                        TempData["Error"] = _unitOfWork.User.Error;
                        return View(model);
                    }
                    else if (_unitOfWork.User.returntype == 2)
                    {
                        TempData["Error"] = _unitOfWork.User.Error;
                        return View(model);
                    }
                    // إضافة المستخدم الجديد إلى قاعدة البيانات
                    await _unitOfWork.User.AddUserAsync(model, currentName, currentId);

                    // حفظ التغييرات في قاعدة البيانات
                    await _unitOfWork.Complete();

                    // عرض رسالة النجاح
                    _toastNotification.AddSuccessToastMessage(Constant.Messages.AddUser);

                    // إعادة توجيه المستخدم إلى صفحة عرض المستخدمين بعد إضافة المستخدم بنجاح
                    return RedirectToAction(nameof(ViewUsers));
                }


            }
            catch (RetryLimitExceededException /* dex */)
            {
                // إذا حدث خطأ في قاعدة البيانات، عرض رسالة الخطأ
                ModelState.AddModelError("", "غير قادر على حفظ التغييرات. حاول مرة أخرى، وإذا استمرت المشكلة، فاستشر مدير نظامك.");
            }

            return View(model);
        }


        private void UploadImage(AddUserViewModel model)
        {

            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {  //@"wwwroot/"
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filestream = new FileStream(Path.Combine(_env.WebRootPath, "Images", ImageName), FileMode.Create);
                file[0].CopyTo(filestream);
                model.ProfilePicture = ImageName;
            }
            else if (model.ProfilePicture == null)
            {
                model.ProfilePicture = "DefultImage.jpg";
            }
            else
            {
                model.ProfilePicture = model.ProfilePicture;
            }
        }
        private void UploadImage2(EditUserViewModel model)
        {

            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {  //@"wwwroot/"
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filestream = new FileStream(Path.Combine(_env.WebRootPath, "Images", ImageName), FileMode.Create);
                file[0].CopyTo(filestream);
                model.ProfilePicture = ImageName;
            }
            else if (model.ProfilePicture == null)
            {
                model.ProfilePicture = "DefultImage.jpg";
            }
            else
            {
                model.ProfilePicture = model.ProfilePicture;
            }
        }



        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var users = await _unitOfWork.User.GetAllAsync();
            ViewBag.UserCount = users.Count();

            var user = await _unitOfWork.User.GetByIdAsync((string)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await _unitOfWork.User.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            List<Governorate> GovernorateList = new List<Governorate>();
            GovernorateList = (from d in _context.Governorates select d).ToList();
            //GovernorateList.Insert(0, new Governorate { Id = 0, Name = "حدد المحافظة" });
            ViewBag.ViewGover = GovernorateList;
            var newUser = new EditUserViewModel
            {
                //GovernoratesList = await _context.Governorates.ToListAsync(),

                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                ProfilePicture = user.ProfilePicture,
                IdentityNumber = user.IdentityNumber,
                IsBlocked = user.IsBlocked,
                DateOfBirth = user.DateOfBirth,
                GovernorateId = user.GovernorateId,
                DirectorateId = user.DirectorateId,
                DirectorateName = user.Directorate.Name,
                SubDirectorateId = user.SubDirectorateId,
                SubDirectorateName = user.SubDirectorate.Name,
                RoleId = user.RoleId,

            };

            //ViewBag.ViewGover = newUser.GovernoratesList.ToArray();
            return View(newUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel user)
        {
            //var users = await _unitOfWork.User.GetAllAsync();
            //ViewBag.UserCount = users.Count();
            UploadImage2(user);
            if (ModelState.IsValid)
            {
                try
                {

                    await _unitOfWork.User.UpdateAsync(id, user);
                    return RedirectToAction(nameof(ViewUsers));
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
            }
            return View(user);
        }

        private bool UserExists(string id)
        {
            return string.IsNullOrEmpty(_unitOfWork.User.GetByIdAsync(id).ToString());
        }


        public async Task<IActionResult> AccountRestriction()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentIdUser = currentUser.IdentityNumber;
            var result = _unitOfWork.User.GetAllUserBlockedAsync(currentIdUser);



            return View(result.ToList());

        }

        public async Task<IActionResult> ChaingStatusComp(int id)
        {

            var upComp = await _unitOfWork.CompalinteRepo.FindAsync(id);
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
            if (dbComp != null)
            {
                dbComp.StatusCompalintId = 2;

                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllComplaints));

        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditSolutions(int id = 0)
        {
            if (id == 0)
                return View(new ProvideSolutionsVM());
            else
            {
                var SolutionModel = await _context.Compalints_Solutions.FindAsync(id);
                if (SolutionModel == null)
                {
                    return NotFound();
                }
                return View(SolutionModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditSolutions(int id, ProvideSolutionsVM model)
        {
            //[Bind("Id,UserId,UserAddSolution,UploadsComplainteId,SolutionProvName,SolutionProvIdentity,IsAccept,Role,ContentSolution,DateSolution")]
            //Compalints_Solution model

            var currentUser = await _userManager.GetUserAsync(User);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var role = claimsIdentity.FindFirst(ClaimTypes.Role);
            string userRole = role.Value;
            string UserId = claim.Value;
            //var errors = ModelState
            // .Where(x => x.Value.Errors.Count > 0)
            // .Select(x => new { x.Key, x.Value.Errors })
            // .ToArray();

            if (!ModelState.IsValid)
            {
                ModelState.Remove("ContentSolution");
                if (id == 0)
                {
                    var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                    var idComp = model.AddSolution.UploadsComplainteId;
                    var solution = new Compalints_Solution()
                    {
                        UserId = subuser.Id,
                        SolutionProvName = subuser.FullName,
                        UploadsComplainteId = model.AddSolution.UploadsComplainteId,
                        SolutionProvIdentity = subuser.IdentityNumber,
                        //ContentSolution = model.AddSolution.ContentSolution,
                        ContentSolution = model.AddSolution.ContentSolution,
                        DateSolution = DateTime.Now,
                        Role = userRole,
                    };

                    _context.Compalints_Solutions.Add(solution);
                    await _context.SaveChangesAsync();
                    var upComp = await _unitOfWork.CompalinteRepo.FindAsync(idComp);
                    var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == upComp.Id);
                    if (dbComp != null)
                    {
                        dbComp.StatusCompalintId = 2;
                        dbComp.StagesComplaintId = 4;
                        await _context.SaveChangesAsync();
                    }
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(AllComplaints));
                }
                else
                {
                    var subuser = await _context.Users.Where(a => a.Id == UserId).FirstOrDefaultAsync();
                    var solutionUpdate = await _context.Compalints_Solutions.Where(sid => sid.Id == id).FirstOrDefaultAsync();
                    if (solutionUpdate != null)
                    {
                        solutionUpdate.UserId = subuser.Id;
                        solutionUpdate.SolutionProvName = subuser.FullName;
                        solutionUpdate.UploadsComplainteId = model.AddSolution.UploadsComplainteId;
                        solutionUpdate.SolutionProvIdentity = subuser.IdentityNumber;
                        //ContentSolution = model.AddSolution.ContentSolution,
                        solutionUpdate.ContentSolution = model.AddSolution.ContentSolution;
                        solutionUpdate.DateSolution = DateTime.Now;
                        solutionUpdate.Role = userRole;
                    }
                    try
                    {
                        _context.Update(solutionUpdate);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(ViewCompalintDetails), new { Id = model.AddSolution.UploadsComplainteId });
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(model.CompalintsSolution.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }

                }

                return RedirectToAction(nameof(ViewCompalintDetails), new { Id = model.AddSolution.UploadsComplainteId });

            }

            return View("AddOrEditSolutions", model);

        }


        public async Task<IActionResult> AllCategoriesCommunications()
        {
            var allCategoriesComplaints = await _service.GetAllGategoryCommAsync();

            return View(allCategoriesComplaints);
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditCategoryComm(int id = 0)
        {
            if (id == 0)
                return View(new TypeCommunication());
            else
            {
                var typeCommunicationModel = await _context.TypeCommunications.FindAsync(id);
                if (typeCommunicationModel == null)
                {
                    return NotFound();
                }
                return View(typeCommunicationModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditCategoryComm(int id, [Bind("Id,Type,UsersNameAddType,CreatedDate")] TypeCommunication typeCommunicationModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;

            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {

                    TypeCommunication type = new TypeCommunication
                    {

                        Type = typeCommunicationModel.Type,
                        UsersNameAddType = currentName,
                        CreatedDate = typeCommunicationModel.CreatedDate = DateTime.Now,
                        UserId = currentUser.Id,
                    };
                    _context.Add(type);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(typeCommunicationModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(typeCommunicationModel.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = HelperModal.RenderRazorViewToString(this, "_ViewAllCatyCoryComm", _context.TypeCommunications.ToList()) });
            }

            return Json(new { isValid = false, html = HelperModal.RenderRazorViewToString(this, "AddOrEditCategoryComm", typeCommunicationModel) });


        }



        [NoDirectAccess]
        public async Task<IActionResult> AddOrEditCategoryCompalint(int id = 0)
        {
            if (id == 0)
                return View(new TypeComplaint());
            else
            {
                var typeComplaintModel = await _context.TypeComplaints.FindAsync(id);
                if (typeComplaintModel == null)
                {
                    return NotFound();
                }
                return View(typeComplaintModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditCategoryCompalint(int id, [Bind("Id,Type,UsersNameAddType,CreatedDate")] TypeComplaint typeComplaintModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentName = currentUser.FullName;


            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {

                    TypeComplaint type = new TypeComplaint
                    {

                        Type = typeComplaintModel.Type,
                        UsersNameAddType = currentName,
                        CreatedDate = typeComplaintModel.CreatedDate = DateTime.Now,
                        UserId = currentUser.Id,
                    };
                    _context.Add(type);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(typeComplaintModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(typeComplaintModel.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = HelperModal.RenderRazorViewToString(this, "_ViewAllCatycoryCompalints", _context.TypeComplaints.ToList()) });
            }
            return Json(new { isValid = false, html = HelperModal.RenderRazorViewToString(this, "AddOrEditCategoryCompalint", typeComplaintModel) });


        }




        public async Task<IActionResult> ShowSolution(int id)
        {
            if (id == 0)
                return View(new Compalints_Solution());
            else
            {
                var SolutionModel = await _context.Compalints_Solutions.Where(i => i.Id == id).FirstOrDefaultAsync();
                if (SolutionModel == null)
                {
                    return NotFound();
                }
                //return Json(new { isValid = false, html = HelperModal.RenderRazorViewToString(this, "_ShowSolution", SolutionModel) });
                return PartialView("_ShowSolution", SolutionModel);
            }

        }


        public async Task<IActionResult> AllCategoriesComplaints()
        {
            var allCategoriesComplaints = await _service.GetAllGategoryCompAsync();

            return View(allCategoriesComplaints);
        }


        public async Task<IActionResult> ViewCompalintDetails(int id)
        {
            var ComplantList = await _unitOfWork.CompalinteRepo.FindAsync(id);
            var CompalintsSolution = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).ToListAsync();

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
                Compalints_SolutionList = await _context.Compalints_Solutions.Where(a => a.UploadsComplainteId == id).OrderByDescending(t => t.DateSolution).ToListAsync(),
                ComplaintsRejectedList = await _context.ComplaintsRejecteds.Where(a => a.UploadsComplainteId == id).ToListAsync(),
                RejectedComplaintVM = rejectView,
                AddSolution = addsoiationView
            };
            return View(VM);
        }
        public async Task<IActionResult> ViewCompalintSolutionDetails(int id)
        {
            var ComplantList = await _unitOfWork.CompalinteRepo.FindAsync(id);
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
        public async Task<IActionResult> ViewCompalintRejectedDetails(int id)
        {
            var ComplantList = await _unitOfWork.CompalinteRepo.FindAsync(id);
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



        private async Task<ApplicationUser> GetCurrentUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userId = currentUser.Id.ToString();
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        private async Task<SelectDataCommuncationDropdownsVM> GetCommunicationDropdownsData(ApplicationUser currentUser)
        {
            var governorateId = currentUser.GovernorateId;
            var directoryId = currentUser.DirectorateId;
            var subDirectoryId = currentUser.SubDirectorateId;
            var roles = await _userManager.GetRolesAsync(currentUser);
            var rolesString = string.Join(",", roles);

            return await _unitOfWork.CompalinteRepo.GetAddCommunicationDropdownsValues(subDirectoryId, directoryId, governorateId, rolesString, rolesString);
        }


        public async Task<IActionResult> AllCommunication()
        {
            var currentUser = await GetCurrentUser();
            var communicationDropdownsData = await GetCommunicationDropdownsData(currentUser);

            ViewBag.TypeCommunication = new SelectList(communicationDropdownsData.TypeCommunications, "Id", "Name");

            var result = _context.UsersCommunications
            .OrderByDescending(d => d.CreateDate)
            .Include(s => s.User)
            .Include(s => s.TypeCommunication)
            .Include(g => g.Governorate)
            .Include(d => d.Directorate)
            .Include(su => su.SubDirectorate);


            //List<ApplicationUser> meeting = _context.Users.Where(m => m.Id == ).ToList<ApplicationUser>();


            int totalCompalints = result.Count();

            ViewBag.totalCompalints = totalCompalints;

            return View(result.ToList());
        }





        //Get: Category/Delete/1

        public async Task<IActionResult> DeleteCategoriesComm(int? id)
        {

            if (id == null)
            {
                return View("Empty");
            }

            var typeCommunicationsModel = await _context.TypeCommunications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeCommunicationsModel == null)
            {
                return NotFound();
            }

            return View(typeCommunicationsModel);
        }


        public async Task<IActionResult> DeleteCategoryComm(int? id)
        {

            var typeCommunicationsModel = await _context.TypeCommunications.FindAsync(id);
            _context.TypeCommunications.Remove(typeCommunicationsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllCategoriesCommunications));
            //return Json(new { html = HelperModal.RenderRazorViewToString(this, "_ViewAllCatyCoryComm", _context.TypeCommunications.ToList()) });
        }

        public async Task<IActionResult> DeleteCategoriesComplaints(int? id)
        {

            if (id == null)
            {
                return View("Empty");
            }

            var typeComplaintsModel = await _context.TypeComplaints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeComplaintsModel == null)
            {
                return NotFound();
            }

            return View(typeComplaintsModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoriesComplaints(int id)
        {

            var typeComplaintsModel = await _context.TypeComplaints.FindAsync(id);
            _context.TypeComplaints.Remove(typeComplaintsModel);
            await _context.SaveChangesAsync();
            //return Json(new { html = HelperModal.RenderRazorViewToString(this, "_ViewAllCatycoryCompalints", _context.TypeComplaints.ToList()) });
            return RedirectToAction(nameof(AllCategoriesComplaints));
        }





        public async Task<IActionResult> AllCirculars()
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync(UserRoles.AdminSubDirectorate);
            var adminIds = adminUsers.Select(user => user.Id);
            if (adminIds.Any())
            {
                await notificationHub.Clients.Users(adminIds).SendAsync("ReceiveNotification", "WOOOOOOOOOOOOO");
            }
            return RedirectToAction();
        }

        public IActionResult AddCirculars()
        {
            return View();
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
                var rejected = new ComplaintsRejected()
                {
                    UserId = subuser.Id,
                    RejectedProvName = subuser.FullName,
                    UploadsComplainteId = model.RejectedComplaintVM.UploadsComplainteId,

                    reume = model.RejectedComplaintVM.reume,
                    DateSolution = DateTime.Now,
                    Role = userRole,


                };

                _context.ComplaintsRejecteds.Add(rejected);
                await _context.SaveChangesAsync();


                var upComp = await _unitOfWork.CompalinteRepo.FindAsync(idComp);
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

        public async Task<IActionResult> UserReportAsPDF(string Id)
        {
            var comSolution = _context.Compalints_Solutions.Where(u => u.UserId == Id)
                             .GroupBy(c => c.UploadsComplainteId);

            var AcceptSolution = _context.Compalints_Solutions.Where(u => u.UserId == Id)
                             .GroupBy(c => c.UploadsComplainteId, a => a.IsAccept);
            var ComplaintsRejecteds = _context.ComplaintsRejecteds.Where(u => u.UserId == Id)
                             .GroupBy(c => c.UploadsComplainteId);
            var user = await _unitOfWork.User.GetByIdAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            var result = new UserReportVM
            {
                UserId = user.Id,
                TotlSolutionComp = comSolution.Count(),
                TotlRejectComp = ComplaintsRejecteds.Count(),
                TotlAcceptSolution = AcceptSolution.Count(),
                //Orders = userGroup,
                FullName = user.FullName,
                Gov = user.Governorate.Name,
                Dir = user.Directorate.Name,
                Role = user.RoleName,
                PhonNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate
            };


            return new ViewAsPdf("UserReportAsPDF", result)
            {
                PageOrientation = Orientation.Portrait,
                MinimumFontSize = 25,
                PageSize = Size.A4,
                CustomSwitches = " --print-media-type --no-background --footer-line --header-line --page-offset 0 --footer-center [page] --footer-font-size 8 --footer-right \"page [page] from [topage]\"  "
            };
        }
        public async Task<IActionResult> BeneficiariesAccount()
        {

            var result = await _context.Users.Where(r => r.RoleId == 5)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();

            int totalUsers = result.Count();

            ViewBag.totalUsers = totalUsers;


            return View(result.ToList());

        }
        [HttpGet]
        public async Task<IActionResult> Download(int id)
        {
            var selectedFile = await _unitOfWork.CompalinteRepo.FindAsync(id);
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


        public async Task<IActionResult> ReportManagement()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectorateies(int id)
        {
            List<Directorate> directorate = new List<Directorate>();
            directorate = await _context.Directorates.Where(m => m.GovernorateId == id).ToListAsync();
            return Json(new SelectList(directorate, "Id", "Name"));
        }

        [HttpGet]
        public async Task<IActionResult> GetSubDirectorate(int id)
        {
            List<SubDirectorate> subdirectorate = new List<SubDirectorate>();
            subdirectorate = await _context.SubDirectorates.Where(m => m.DirectorateId == id).ToListAsync();
            return Json(new SelectList(subdirectorate, "Id", "Name"));
        }


        public async Task<IActionResult> DisbleOrEnableUser(string id)
        {
            await _unitOfWork.User.TogelBlockUserAsync(id);
            return RedirectToAction("ViewUsers");


        }
        private bool TransactionModelExists(int id)
        {
            return _context.TypeCommunications.Any(e => e.Id == id);
        }


    }
}
