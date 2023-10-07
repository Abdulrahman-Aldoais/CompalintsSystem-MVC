using AutoMapper;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Repositories
{
    public class CompalintRepository : EntityBaseRepository<UploadsComplainte>, ICompalintRepository
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public string Error { get; set; }
        public int returntype { get; set; }

        public CompalintRepository(
            AppCompalintsContextDB context,
            IMapper mapper,
            IWebHostEnvironment env,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager


            ) : base(context, mapper, env, userManager, signInManager)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public IQueryable<UploadsComplainte> GetAllRejectedComplaints(string identity)
        {
            var result = _context.UploadsComplaintes.Where(j => j.StatusCompalintId == 3 && j.UserId == identity)
               .OrderByDescending(u => u.UploadDate)
               .Include(s => s.StatusCompalint)
               .Include(f => f.TypeComplaint)
               .Include(st => st.StagesComplaint)
               .Include(g => g.Governorate)
               .Include(d => d.Directorate);
            return result;
        }


        public IQueryable<UploadsComplainte> GetAllResolvedComplaints(string identity)
        {
            var result = _context.UploadsComplaintes.Where(j => j.StatusCompalintId == 2 && j.UserId == identity)
               .OrderByDescending(u => u.UploadDate)
               .Include(s => s.StatusCompalint)
               .Include(st => st.StagesComplaint)
               .Include(f => f.TypeComplaint)
               .Include(g => g.Governorate)
               .Include(d => d.Directorate);
            return result;
        }

        public Task GetAllGategoryCompAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdatedbCompAsync(UploadsComplainte data)
        {
            var dbComp = await _context.UploadsComplaintes.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbComp != null)
            {

                dbComp.Id = data.Id;
                dbComp.StagesComplaintId = 2;


                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }

        public IQueryable<UploadsComplainte> Search(string term)
        {
            var result = _context.UploadsComplaintes.Where(
                u => u.TitleComplaint == term
                || u.DescComplaint == term);
            return result;
        }



        public IQueryable<UploadsComplainte> GetAll()
        {

            var result = _context.UploadsComplaintes
            .Include(s => s.StatusCompalint)
            .Include(f => f.TypeComplaint)
            .Include(st => st.StagesComplaint)
            .Include(g => g.Governorate)
            .Include(d => d.Directorate)
            .Include(su => su.SubDirectorate)
            .OrderByDescending(u => u.UploadDate);
            //Task.WhenAll((System.Collections.Generic.IEnumerable<Task>)result);
            return result;


        }

        public IQueryable<UsersCommunication> GetCommunicationBy(string UserId)
        {
            var result = _context.UsersCommunications.Where(u => u.UserId == UserId)
            //.OrderByDescending(u => u.UploadDate)
            .Include(s => s.TypeCommunication)
            //.Include(f => f.NameUserId)
            .Include(g => g.Governorate)
            .Include(d => d.Directorate)
            .Include(su => su.SubDirectorate);

            return result;
        }

        // جلب الشكاوى المقدمة من المزارع الخاصة به وعرضها له
        public IQueryable<UploadsComplainte> GetBy(string Identity)
        {
            var result = _context.UploadsComplaintes.Where(u => u.UserId == Identity)
                .OrderByDescending(u => u.UploadDate)
                .Include(s => s.StatusCompalint)
                .Include(st => st.StagesComplaint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorate)
                .Include(d => d.Directorate)
                .Include(su => su.SubDirectorate);

            return result;
        }
        public IQueryable<UploadsComplainte> GetRejectComp(string userId)
        {
            var result = _context.UploadsComplaintes.Where(u => u.UserId == userId)
                .OrderByDescending(u => u.UploadDate)
                .Include(s => s.StatusCompalint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorate)
                .Include(d => d.Directorate)
                .Include(su => su.SubDirectorate);

            return result;
        }


        public async Task<UploadsComplainte> GetCompalintById(int id)
        {
            var compalintDetails = _context.UploadsComplaintes
                .Include(s => s.StatusCompalint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorate)
                .Include(d => d.Directorate)
                .Include(su => su.SubDirectorate)
                .Include(st => st.StagesComplaint)
                .FirstOrDefaultAsync(c => c.Id == id);
            //var compalintDetails = from m in _context.UploadsComplainte select m;
            return await compalintDetails;
        }
        // جلب الشكاوى المقدمة من المزارع الخاصة به وعرضها له
        public IQueryable<UploadsComplainte> GetBenfeficarieCompalintBy(string Identity)
        {
            var result = _context.UploadsComplaintes.Where(u => u.UserId == Identity)
                .OrderByDescending(u => u.UploadDate)
                .Include(s => s.StatusCompalint)
                .Include(st => st.StagesComplaint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorate)
                .Include(d => d.Directorate)
                .Include(su => su.SubDirectorate);

            return result;
        }
        public async Task<UploadsComplainte> FindAsync(int id)
        {
            var selectedUpload = await _context.UploadsComplaintes.FindAsync(id);
            if (selectedUpload != null)
            {
                //AutoMapper 
                var compalintDetails = _context.UploadsComplaintes
                .Include(s => s.StatusCompalint)
                .Include(f => f.TypeComplaint)
                .Include(g => g.Governorate)
                .Include(d => d.Directorate)
                .Include(su => su.SubDirectorate)
                .Include(st => st.StagesComplaint)
                .FirstOrDefaultAsync(c => c.Id == id);
                //var compalintDetails = from m in _context.UploadsComplainte select m;
                return await compalintDetails;
            }
            return null;
        }

        public async Task CreateAsync(InputCompmallintVM model)
        {
            var mappedObj = _mapper.Map<UploadsComplainte>(model);
            await _context.UploadsComplaintes.AddAsync(mappedObj);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCommuncationAsync(AddCommunicationVM model)
        {
            var mappedObj = _mapper.Map<UsersCommunication>(model);
            await _context.UsersCommunications.AddAsync(mappedObj);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var DeletedUser = await _userManager.FindByIdAsync(id);
            var roleId = await _userManager.GetRolesAsync(DeletedUser);
            if (DeletedUser == null)
            {
                return;
            }
            await _userManager.RemoveFromRolesAsync(DeletedUser, roleId);
            await _userManager.DeleteAsync(DeletedUser);
            await _context.SaveChangesAsync();
        }

        public async Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int subDirctoty, int directoryId, int governorateId, string role, string roleId)
        {
            var userManager = _userManager;// initialize your user manager here
            if (role == "AdminGovernorate")
            {
                var responseGov = new SelectDataCommuncationDropdownsVM
                {
                    ApplicationUsers = await _context.Users
                        .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                        .Join(_context.Roles, ur => ur.UserRole.RoleId, r => r.Id, (ur, r) => new { User = ur.User, UserRole = ur.UserRole, Role = r })
                        .Where(x =>
                            (x.UserRole.RoleId == roleId || x.UserRole.RoleId == "48e9b2f6-42e7-439f-afa2-03cf13342517") &&
                            x.User.GovernorateId == governorateId &&
                            x.User.DirectorateId == directoryId
                        )
                        .OrderBy(x => x.User.FullName)
                        .Select(x => new ApplicationUser
                        {
                            Id = x.User.Id,
                            FullName = x.User.FullName + " ( " + x.User.UserRoleName + "  )",
                        })
                        .ToListAsync(),


                    TypeCommunications = await _context.TypeCommunications
                        .OrderBy(tc => tc.Type)
                        .ToListAsync()
                };

                foreach (var user in responseGov.ApplicationUsers)
                {
                    var identityUser = await userManager.FindByIdAsync(user.Id);
                    var roles = await userManager.GetRolesAsync(identityUser);
                    user.UserRoles = roles.Select(role => new IdentityRole { Name = role }).ToList();
                }



                return responseGov;


            }
            else if (role == "AdminDirectorate")
            {
                var responseDir = new SelectDataCommuncationDropdownsVM
                {
                    ApplicationUsers = await _context.Users
                     .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                     .Where(x => x.UserRole.RoleId == roleId || x.UserRole.RoleId == "2afd97e1-b763-4a31-9a5a-0ed57efd7a04"
                         && x.User.GovernorateId == governorateId
                         && x.User.DirectorateId == directoryId)
                     .OrderBy(x => x.User.FullName)
                        .Select(x => new ApplicationUser
                        {
                            Id = x.User.Id,
                            FullName = x.User.FullName + " ( " + x.User.UserRoleName + "  )",
                        })
                        .ToListAsync(),


                    TypeCommunications = await _context.TypeCommunications
                        .OrderBy(tc => tc.Type)
                        .ToListAsync()
                };

                foreach (var user in responseDir.ApplicationUsers)
                {
                    var identityUser = await userManager.FindByIdAsync(user.Id);
                    var roles = await userManager.GetRolesAsync(identityUser);
                    user.UserRoles = roles.Select(role => new IdentityRole { Name = role }).ToList();
                }

                return responseDir;
            }
            else if (role == "AdminSubDirectorate")
            {
                var responseSub = new SelectDataCommuncationDropdownsVM
                {
                    ApplicationUsers = await _context.Users
                    .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                    .Where(x => x.UserRole.RoleId == roleId
                        && x.User.GovernorateId == governorateId
                        && x.User.DirectorateId == directoryId)
                      .OrderBy(x => x.User.FullName)
                        .Select(x => new ApplicationUser
                        {
                            Id = x.User.Id,
                            FullName = x.User.FullName + " ( " + x.User.UserRoleName + "  )",
                        })
                        .ToListAsync(),


                    TypeCommunications = await _context.TypeCommunications
                        .OrderBy(tc => tc.Type)
                        .ToListAsync()
                };

                foreach (var user in responseSub.ApplicationUsers)
                {
                    var identityUser = await userManager.FindByIdAsync(user.Id);
                    var roles = await userManager.GetRolesAsync(identityUser);
                    user.UserRoles = roles.Select(role => new IdentityRole { Name = role }).ToList();
                }

                return responseSub;
            }
            else
            {
                var responseAdmin = new SelectDataCommuncationDropdownsVM
                {
                    ApplicationUsers = await _context.Users
                    .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                    .Where(x => x.UserRole.RoleId != roleId)
                      .OrderBy(x => x.User.FullName)
                        .Select(x => new ApplicationUser
                        {
                            Id = x.User.Id,
                            FullName = x.User.FullName + "   " + "(" + x.User.UserRoleName + ")",
                        }).ToListAsync(),

                    TypeCommunications = await _context.TypeCommunications
                      .OrderBy(tc => tc.Type)
                      .ToListAsync()
                };
                foreach (var user in responseAdmin.ApplicationUsers)
                {
                    var identityUser = await userManager.FindByIdAsync(user.Id);
                    var roles = await userManager.GetRolesAsync(identityUser);
                    user.UserRoles = roles.Select(role => new IdentityRole { Name = role }).ToList();
                }

                return responseAdmin;
            }
        }

        //public void InsertDefaultData()
        //{

        //    var compalintsSolution = new Compalints_Solution
        //    {
        //        Id = 1,
        //        ContentSolution = "اخي المواطن سعيد علي احمد \r\nتحية طيبة،\r\n\r\nأود أن أعبر لك عن تقديري العميق لثقتكم بنا ممثلين عزلة القفاعة مخلاف، وعلى تقديمكم للشكوى المتعلقة بنقص العلاجات والأدوات والتوعية الزراعية.\r\n\r\nنحن ندرك تمامًا أهمية قطاع الزراعة في تنمية البلاد وتحسين معيشة المزارعين. وبناءً على شكواكم، قمنا بإجراء التحقيقات والدراسات اللازمة لفهم الوضع الحالي وتحديد الخطوات المناسبة للتحسين.\r\n\r\nنود أن نؤكد لكم أننا نعمل جاهدين على حل مشكلة نقص العلاجات الزراعية والأدوات المطلوبة لدعم المزارعين. قد تواجهنا بعض التحديات والعقبات في توفير الموارد اللازمة في ظل الظروف الصعبة التي تمر بها البلاد، ولكن نحن نعمل بكل الإمكانات المتاحة لتوفير العلاجات والأدوات التي تعزز الإنتاجية وتحسن جودة المحاصيل.\r\n\r\nبالإضافة إلى ذلك، سنعمل على تعزيز التوعية الزراعية من خلال تنظيم برامج وحملات تثقيفية تستهدف المزارعين. سنقوم بتوفير المعلومات المهمة حول أفضل الممارسات الزراعية وتقديم الدعم الفني والاستشارات اللازمة لمساعدتكم في التعامل مع التحديات الزراعية المختلفة.\r\n\r\nنحن نعتز بتواصلكم ونقدر اهتمامكم بتطوير القطاع الزراعي في اليمن. نحن ملتزمون بتحسين الوضع الزراعي وتقديم الدعم اللازم للمزارعين في جميع أنحاء البلاد.\r\n\r\nإذا كان لديكم أي استفسارات إضافية أو توجيهات خاصة، فلا تترددوا في التواصل معنا. نحن هنا لخدمتكم والعمل سويًا من أجل تحقيق التقدم في قطاع الزراعة.\r\n\r\nشاكرين لكم صبركم وتفهمكم، ونأمل في أن يكون لديكم تجربة زراعية ناجحة ومثمرةمع خالص التحية،\r\n\r\nعبدالجليل سرحان الدعيس\r\nمدير عزلة\r\nعزلة القفاعة \r\nمحافظة تــــعــــــز",
        //        DateSolution = new DateTime(),
        //        UserId = "e70aa106-c6d6-4037-bb94-eb241dd1ef50",
        //        SolutionProvName = "عبدالجليل سرحان غالب الدعيس",
        //        UploadsComplainteId = 1,
        //        SolutionProvIdentity = "001024312444",
        //        Role = "مدير عزلة",
        //    };


        //    var uploadsCompalints = new UploadsComplainte
        //    {
        //        Id = 1,
        //        TitleComplaint = "نقص العلاجات والأدوات والتوعية الزراعية",
        //        DescComplaint = "\r\nالموضوع: شكوى بشأن نقص العلاجات والأدوات والتوعية الزراعية\r\n\r\n\r\nأتمنى أن تصلكم هذه الرسالة في أتم الصحة والعافية. أنا سعيد علي احمد ، مزارع يمني مخلص لهذا الوطن ومهتم بتطوير القطاع الزراعي في بلادنا الجميلة.\r\n\r\nأود أن أبدي استياءي العميق وشكواي بخصوص الوضع الحالي للزراعة في اليمن، وتحديدًا فيما يتعلق بنقص العلاجات الزراعية والأدوات اللازمة لتنمية القطاع الزراعي بشكل فعال، بالإضافة إلى نقص التوعية الزراعية الملائمة.\r\n\r\nفي ظل الظروف الصعبة التي يواجهها القطاع الزراعي في اليمن، فإن نقص العلاجات والأدوات الزراعية يؤثر سلبًا على إنتاجية المزارعين وجودة المحاصيل. نحن بحاجة ماسة إلى توفير العلاجات المناسبة لمكافحة الآفات والأمراض التي تهدد محاصيلنا وتقوم بتدميرها. كما أننا بحاجة إلى الأدوات والمعدات الزراعية الحديثة التي تسهم في زيادة الإنتاجية وتحسين جودة المنتجات.\r\n\r\nبالإضافة إلى ذلك، يعاني القطاع الزراعي من نقص التوعية الزراعية الملائمة. نحن بحاجة إلى برامج وحملات تثقيفية تستهدف المزارعين وتزودهم بالمعلومات اللازمة حول أفضل الممارسات الزراعية، وكذلك توفر التوجيه والاستشارات الفنية لمواجهة التحديات الزراعية المتغيرة.\r\n\r\nأنا مدرك للتحديات الكبيرة التي تواجهها البلاد حاليًا، ولكن أعتقد أن تطوير القطاع الزراعي يشكل جزءًا أساسيًا في بناء مستقبل أفضل لليمن. لذا، أناشدكم بأن تولوا هذه الشكوى بجدية وتعملوا على تحسين الوضع الحالي من خلال توفير العلاجات الزراعية اللازمة، وتوفير الأدوات والمعدات الحديثة، وتعزيز التوعية الزراعية.\r\n\r\nأنا واثق أن بإمكانكم أن تتخذوا الإجراءات اللازمة لتحسين الوضع الزراعي في اليمن وتقديم الدعم اللازم للمزارعين. سأكون ممتنًا لو تم تنظيم ورش عمل ودورات تدريبية للمزارعين لتعزيز مهاراتهم وزيادة وعيهم بأحدث التقنيات الزراعية.\r\n\r\nأنا على استعداد لتقديم أي مساهمة أو مشاركة في هذا الجهد، وأتطلع إلى رؤية تحسن ملموس في القطاع الزراعي في بلادنا.\r\n\r\nأشكركم مقدمًا على اهتمامكم وتعاونكم، وأنا في انتظار استجابتكم في أقرب وقت ممكن.\r\n\r\nمع خالص التحية،",
        //        GovernorateId = 2,
        //        DirectorateId = 1,
        //        SubDirectorateId = 2,
        //        FileName = "سعيد علي احمد",
        //        UserId = "530e8dda-7ef5-4f39-909b-072e7ccb6dab",
        //        UploadDate = DateTime.Now,
        //        TypeComplaintId = 1,
        //        SocietyId = 1,
        //        StatusCompalintId = 1,
        //        StagesComplaintId = 1,
        //    };



        //    _context.Compalints_Solutions.Add(compalintsSolution);
        //    _context.UploadsComplaintes.Add(uploadsCompalints);
        //    _context.SaveChanges();

        //}


    }
}
