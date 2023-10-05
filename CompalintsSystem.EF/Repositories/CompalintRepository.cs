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
            if (role == "AdminGovernorate")
            {
                var responseGov = new SelectDataCommuncationDropdownsVM
                {
                    ApplicationUsers = await _context.Users
                     .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                     .Where(x => x.UserRole.RoleId == roleId || x.UserRole.RoleId == "48e9b2f6-42e7-439f-afa2-03cf13342517"
                         && x.User.GovernorateId == governorateId
                         && x.User.DirectorateId == directoryId)
                     .OrderBy(x => x.User.FullName)
                     .Select(x => x.User)
                     .ToListAsync(),

                    TypeCommunications = await _context.TypeCommunications
                    .OrderBy(tc => tc.Type)
                    .ToListAsync()
                };

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
                     .Select(x => x.User)
                     .ToListAsync(),

                    TypeCommunications = await _context.TypeCommunications
                    .OrderBy(tc => tc.Type)
                    .ToListAsync()
                };

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
                    .Select(x => x.User)
                    .ToListAsync(),

                    TypeCommunications = await _context.TypeCommunications
                   .OrderBy(tc => tc.Type)
                   .ToListAsync()
                };

                return responseSub;
            }
            var responseAdmin = new SelectDataCommuncationDropdownsVM
            {
                ApplicationUsers = await _context.Users
                  .OrderBy(u => u.FullName)
                  .ToListAsync(),

                TypeCommunications = await _context.TypeCommunications
                  .OrderBy(tc => tc.Type)
                  .ToListAsync()
            };

            return responseAdmin;
        }


    }
}
