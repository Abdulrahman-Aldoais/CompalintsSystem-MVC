//using CompalintsSystem.Data.Base;
//using CompalintsSystem.Hubs;
//using CompalintsSystem.Core.Models;
//using @using CompalintsSystem.Core.Models.Statistics;
//using CompalintsSystem.Service;
//using CompalintsSystem.Service.Helpers;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CompalintsSystem.Controllers
//{
//    public class ReportsSystemController : Controller
//    {

//        private readonly ICompalintRepository _compReop;
//        private readonly IUserService _userService;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IHubContext<NotefcationHub> notificationHub;
//        private readonly IWebHostEnvironment _env;
//        private readonly ICategoryService _service;
//        private readonly AppCompalintsContextDB _context;

//        public ReportsSystemController(

//            ICategoryService service,
//            ICompalintRepository compReop,
//            IUserService userService,
//            UserManager<ApplicationUser> userManager,
//            IHubContext<NotefcationHub> notificationHub,

//            IWebHostEnvironment env,

//            AppCompalintsContextDB context)
//        {

//            _compReop = compReop;
//            _userService = userService;
//            _userManager = userManager;
//            this.notificationHub = notificationHub;
//            _service = service;
//            _context = context;
//            _env = env;

//        }
//        public async Task<IActionResult> Index()
//        {
//            var allComp = await _compReop.GetAllAsync(h => h.Governorate);
//            var result = await _userService.GetAllAsync(h => h.Governorate);
//            var compSolv = allComp.Where(r => r.StatusCompalintId == 2);

//            int totalcompSolv = compSolv.Count();
//            int totalUsers = result.Count();
//            int totalComp = allComp.Count();

//            ViewBag.totalcompSolv = totalcompSolv;
//            ViewBag.totalUsers = totalUsers;
//            ViewBag.totalComp = totalComp;




//            //------------- أحصائيات بالمستخدمين في كل محافظة --------------------//


//            List<UsersInStatistic> usersIn = new List<UsersInStatistic>();
//            usersIn = ViewBag.totalGovermentuser;

//            List<ApplicationUser> applicationUsers = await _context.Users

//                .Include(su => su.Governorate).ToListAsync();

//            //Totalcountuser
//            int TotalUsers = applicationUsers.Count();

//            ViewBag.Users = TotalUsers;

//            //total Govermentuser
//            ViewBag.totalGovermentuser = applicationUsers.GroupBy(j => j.GovernorateId).Select(g => new UsersInStatistic
//            {
//                Name = g.First().Governorate.Name,
//                totalUsers = g.Count().ToString(),
//                Users = (g.Count() * 100) / TotalUsers


//            }).ToList();



//            //------------- نـــــهاية أحصائيات بالمستخدمين --------------------//


//            //-------------أحصائيات انواع الشكاوى --------------------//



//            List<UploadsComplainte> compalints = await _context.UploadsComplaintes
//                .Include(su => su.TypeComplaint).ToListAsync();
//            List<TypeCompalintStatistic> typeCompalints = new List<TypeCompalintStatistic>();
//            typeCompalints = ViewBag.GrapComplanrType;

//            int totalcomplant = compalints.Count();
//            ViewBag.Totalcomplant = totalcomplant;

//            ViewBag.GrapComplanrType = compalints.GroupBy(x => x.TypeComplaintId).Select(g => new TypeCompalintStatistic
//            {
//                Name = g.First().TypeComplaint.Type,
//                TotalCount = g.Count().ToString(),
//                TypeComp = (g.Count() * 100) / totalcomplant
//            }).ToList();




//            //------------- نهاية أحصائيات انواع الشكاوى --------------------//


//            //-------------أحصائيات حالات الشكاوى --------------------//


//            List<UploadsComplainte> stutuscompalints = await _context.UploadsComplaintes
//                .Include(su => su.StatusCompalint).ToListAsync();
//            List<StutusCompalintStatistic> stutusCompalints = new List<StutusCompalintStatistic>();
//            stutusCompalints = ViewBag.GrapComplanrStutus;

//            int totalStutuscomplant = stutuscompalints.Count();
//            ViewBag.TotalStutusComplant = totalStutuscomplant;

//            ViewBag.GrapComplanrStutus = stutuscompalints.GroupBy(s => s.StatusCompalintId).Select(g => new StutusCompalintStatistic
//            {
//                //id = 
//                Name = g.First().StatusCompalint.Name,
//                TotalCountStutus = g.Count().ToString(),
//                stutus = (g.Count() * 100) / totalStutuscomplant
//            }).ToList();


//            //StutusCompalintStatistic stutus = new StutusCompalintStatistic()
//            //    {
//            //        Name = item.Name,
//            //        stutus = item.stutus,
//            //        TotalCountStutus = item?.TotalCountStutus?.ToString(),
//            //    };

//            //List<StutusCompalintStatistic> parts = new List<StutusCompalintStatistic>();

//            //foreach (var item in ViewBag.GrapComplanrStutus)
//            //{
//            //    var list = parts.Add(item);
//            //    _context.Add(list);
//            //    _context.SaveChangesAsync();
//            //}





//            //------------- نهاية أحصائيات حالات الشكاوى --------------------//



//            //-------------  أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//

//            List<ApplicationUser> UsersRoles = await _context.Users.Include(x => x.UserRoles).ToListAsync();


//            //Totalcountuser
//            int totalCountByRole = applicationUsers.Count();

//            ViewBag.TotalCountByRoles = totalCountByRole;

//            // show Name Role Rether Than Id
//            var Roles = _context.Roles.ToList();
//            var x = from r in Globals.RolesLists
//                    join u in UsersRoles
//                    on r.Id equals u.RoleId
//                    select new ApplicationUser
//                    {
//                        RoleName = r.Name,
//                        UserRoles = u.UserRoles
//                    };

//            //total Users By Role
//            ViewBag.totalUserByRoles = x.GroupBy(j => j.RoleName).Select(g => new UserByRolesStatistic
//            {
//                RoleName = g.First().RoleName,
//                TotalCount = g.Count().ToString(),
//                RolsTot = (g.Count() * 100) / totalCountByRole


//            }).ToList();


//            List<UserByRolesStatistic> gtus = new List<UserByRolesStatistic>();
//            gtus = ViewBag.totalUserByRoles;


//            //------------------ نهاية أحصائيات عدد المستخدمين حسب الصلاحيات--------------------//


//            //-------------  أحصائيات انواع اليلاغات    --------------------//



//            List<UsersCommunication> communcations = await _context.UsersCommunications
//                .Include(su => su.TypeCommunication).ToListAsync();
//            List<TypeCommunicationStatistic> TotalTypeCommuncations = new List<TypeCommunicationStatistic>();

//            int totalCommunication = communcations.Count();

//            TotalTypeCommuncations = ViewBag.typeCommun;

//            ViewBag.TypeCommuncations = communcations.GroupBy(x => x.TypeCommunication).Select(g => new TypeCommunicationStatistic
//            {
//                Name = g.First().TypeCommunication.Type,
//                TotalCount = g.Count().ToString(),
//                TypeComp = (g.Count() * 100) / totalCommunication
//            }).ToList();




//            //------------- نهاية أحصائيات انواع اليلاغات --------------------//


//            //-------------  أحصائيات عدد اليلاغات    --------------------//


//            List<TotalCommunicationStatistic> communicationsIn = new List<TotalCommunicationStatistic>();
//            communicationsIn = ViewBag.totalcommunications;

//            List<UsersCommunication> communications = await _context.UsersCommunications

//                .Include(su => su.Governorate).ToListAsync();

//            //Totalcountuser
//            int TotalCommun = communications.Count();

//            ViewBag.Commun = TotalCommun;

//            //total Govermentuser
//            ViewBag.totalcommunications = communications.GroupBy(j => j.GovernorateId).Select(g => new TotalCommunicationStatistic
//            {
//                Name = g.First().Governorate.Name,
//                TotalCount = g.Count().ToString(),
//                TypeComp = (g.Count() * 100) / TotalUsers

//            }).ToList();

//            //------------- نهاية أحصائيات عدد اليلاغات --------------------//

//            return View();
//        }
//    }
//}
