

using AutoMapper;
using AutoMapper.QueryableExtensions;
using CompalintsSystem.Core;
using CompalintsSystem.Core.Helpers.Constants;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.Core.ViewModels.Data;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Repositories
{
    public class UserService : IUserService
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor httpcontexttAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public string Error { get; set; }
        public int returntype { get; set; }

        public UserService(
            AppCompalintsContextDB context,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment

            )
        {
            _context = context;
            this.mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;

            var user = httpContextAccessor.HttpContext.User;
        }


        public async Task AddBenefAsync(AddUserViewModel userVM, string currentName, string currentId)
        {

            var newUser = new ApplicationUser()
            {
                FullName = userVM.FullName,
                UserName = userVM.IdentityNumber.ToString(),
                Email = userVM.IdentityNumber.ToString(),
                IdentityNumber = userVM.IdentityNumber,
                PhoneNumber = userVM.PhoneNumber,
                GovernorateId = userVM.GovernorateId,
                DirectorateId = userVM.DirectorateId,
                SubDirectorateId = userVM.SubDirectorateId,
                IsBlocked = userVM.IsBlocked,
                SocietyId = userVM.SocietyId,
                ProfilePicture = userVM.ProfilePicture,
                RoleId = userVM.userRoles,
                EmailConfirmed = userVM.IsBlocked,
                PhoneNumberConfirmed = userVM.IsBlocked,
                UserId = currentId,
                originatorName = currentName,



            };



            var user = await _userManager.FindByEmailAsync(newUser.IdentityNumber);
            if (user != null)
            {
                returntype = 1;
                Error = "المستخدم موجود مسبقا برقم البطاقة هذه ";
                return;
            }

            var newUserResponse = await _userManager.CreateAsync(newUser, userVM.Password);

            if (newUserResponse.Succeeded)
            {
                if (userVM.userRoles == 1)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminGeneralFederation);

                }
                else if (userVM.userRoles == 2)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminGovernorate);
                }
                else if (userVM.userRoles == 3)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminDirectorate);
                }
                else if (userVM.userRoles == 4)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminSubDirectorate);
                }

                else if (userVM.userRoles == 5)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.Beneficiarie);
                }
                await _userManager.AddPasswordAsync(newUser, userVM.Password);



            }

            else
            {
                returntype = 2;

                Error = "كلمة السر يجب ان تكون ارقام و حروف و رموز";
                return;
            }


        }




        // انشاء مستخدم جديد
        public async Task AddUserAsync(AddUserViewModel userVM, string currentName, string currentId)
        {

            var newUser = new ApplicationUser()
            {
                FullName = userVM.FullName,
                UserName = userVM.IdentityNumber.ToString(),
                Email = userVM.IdentityNumber.ToString(),
                IdentityNumber = userVM.IdentityNumber,
                PhoneNumber = userVM.PhoneNumber,
                ProfilePicture = userVM.ProfilePicture,
                GovernorateId = userVM.GovernorateId,
                DirectorateId = userVM.DirectorateId,
                SubDirectorateId = userVM.SubDirectorateId,
                IsBlocked = userVM.IsBlocked,
                SocietyId = userVM.SocietyId,
                RoleId = userVM.userRoles,
                EmailConfirmed = userVM.IsBlocked,
                PhoneNumberConfirmed = userVM.IsBlocked,
                UserId = currentId,
                originatorName = currentName,
                CreatedDate = DateTime.Now,

            };

            var userIdentity1 = await _context.Users.FirstOrDefaultAsync(u => u.IdentityNumber == newUser.IdentityNumber);
            if (userIdentity1 != null)
            {
                returntype = 1;
                Error = "رقم الهوية  موجود مسبقًا";
                return;
            }

            var newUserResponse = await _userManager.CreateAsync(newUser, userVM.Password);

            if (newUserResponse.Succeeded)
            {
                if (userVM.userRoles == 1)
                {
                    newUser.UserRoleName = UserRolesArbic.AdminGeneralFederation;
                    newUser.RoleId = 1;
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminGeneralFederation);

                }
                else if (userVM.userRoles == 2)
                {
                    newUser.UserRoleName = UserRolesArbic.AdminGovernorate;
                    newUser.RoleId = 2;
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminGovernorate);
                }
                else if (userVM.userRoles == 3)
                {
                    newUser.UserRoleName = UserRolesArbic.AdminDirectorate;
                    newUser.RoleId = 3;
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminDirectorate);
                }
                else if (userVM.userRoles == 4)
                {
                    newUser.UserRoleName = UserRolesArbic.AdminSubDirectorate;
                    newUser.RoleId = 4;
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminSubDirectorate);
                }

                else if (userVM.userRoles == 5)
                {
                    newUser.UserRoleName = UserRolesArbic.Beneficiarie;
                    newUser.RoleId = 5;
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Beneficiarie);
                }
                await _userManager.AddPasswordAsync(newUser, userVM.Password);

            }

            else
            {
                returntype = 2;

                Error = "كلمة السر يجب ان تكون ارقام و حروف و رموز";
                return;
            }


        }


        // انشاء مستخدم جديد
        public async Task RegisterAsync(AddUserViewModel userVM)
        {

            var newUser = new ApplicationUser()
            {
                FullName = userVM.FullName,
                UserName = userVM.IdentityNumber.ToString(),
                Email = userVM.IdentityNumber.ToString(),
                IdentityNumber = userVM.IdentityNumber,
                PhoneNumber = userVM.PhoneNumber,
                ProfilePicture = null,
                GovernorateId = userVM.GovernorateId,
                DirectorateId = userVM.DirectorateId,
                SubDirectorateId = userVM.SubDirectorateId,
                IsBlocked = false,
                SocietyId = userVM.SocietyId,
                RoleId = 5,// مستخدم عادي
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,

            };

            var userIdentity1 = await _context.Users.FirstOrDefaultAsync(u => u.IdentityNumber == newUser.IdentityNumber);
            if (userIdentity1 != null)
            {
                returntype = 1;
                Error = "رقم الهوية  موجود مسبقًا";
                return;
            }

            var newUserResponse = await _userManager.CreateAsync(newUser, userVM.Password);

            if (newUserResponse.Succeeded)
            {


                newUser.UserRoleName = UserRolesArbic.Beneficiarie;
                newUser.RoleId = 5;
                await _userManager.AddToRoleAsync(newUser, UserRoles.Beneficiarie);

                await _userManager.AddPasswordAsync(newUser, userVM.Password);
            }

            else
            {
                returntype = 2;

                Error = "كلمة السر يجب ان تكون ارقام و حروف و رموز";
                return;
            }


        }


        //public async Task<OperationResult> TogelBlockUserAsync(int UserId)
        //{
        //    var existedUser = await _context.Users.FindAsync(UserId);
        //    if (existedUser == null)
        //    {
        //        return OperationResult.NotFond();
        //    }
        //    existedUser.IsBlocked = !existedUser.IsBlocked;
        //    _context.Update(existedUser);
        //    await _context.SaveChangesAsync();
        //    return OperationResult.Successeded();
        //}
        public async Task<OperationResult> TogelBlockUserAsync(string id)
        {
            var selectedItem = await _context.Users.FindAsync(id);
            if (selectedItem != null)
            {
                if (await _userManager.IsEmailConfirmedAsync(selectedItem))
                {
                    selectedItem.EmailConfirmed = false;
                    selectedItem.IsBlocked = false;
                }
                else
                {
                    selectedItem.IsBlocked = true;
                    selectedItem.EmailConfirmed = true;

                }


                _context.Update(selectedItem);
                await _context.SaveChangesAsync();
                return OperationResult.Successeded();
            }

            return OperationResult.NotFond();

        }
        // عرض كل الحسابات المقيدة 
        public IQueryable<ApplicationUser> GetAllUserBlockedAsync(string byuserId)
        {
            var result = _context.Users.Where(u => u.IsBlocked == false && u.UserId == byuserId)
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate);
            return result;
        }

        public IQueryable<AddUserViewModel> Search(string term)
        {
            var result = _context.Users.Where(
                 //u => u.IdentityNumber == term||
                 u => u.UserName == term).ProjectTo<AddUserViewModel>(
                mapper.ConfigurationProvider);
            return result;
        }

        public async Task<int> UserRegistrationCountAsync()
        {
            var count = await _context.Users.CountAsync();
            return count;
        }

        public async Task<int> UserRegistrationCountAsync(int month)
        {
            var year = DateTime.Today.Year;
            var count = await _context.Users.CountAsync(u => u.CreatedDate.Month == month && u.CreatedDate.Year == year);
            return count;
        }


        public async Task<ApplicationUser> EnableAndDisbleUser(string id)
        {
            var UserEdited = await _userManager.FindByIdAsync(id);
            if (UserEdited != null)
            {
                if (await _userManager.IsEmailConfirmedAsync(UserEdited))
                {
                    UserEdited.EmailConfirmed = false;
                    UserEdited.IsBlocked = false;
                }
                else
                {
                    UserEdited.IsBlocked = true;
                    UserEdited.EmailConfirmed = true;

                }
                await _userManager.UpdateAsync(UserEdited);
                // __contextt.SaveChanges();
                //await _signInManager.RefreshSignInAsync(UserEdited).ConfigureAwait(false);
                return UserEdited;
            }
            else
                return null;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var profile = await _context.Users.FindAsync(userId);
            if (profile != null)
            {
                //AutoMapper 
                var compalintDetails = _context.Users
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate)


                .FirstOrDefaultAsync(c => c.Id == userId);
                //var compalintDetails = from m in __contextt.UploadsComplainte select m;
                return await compalintDetails;
            }
            return null;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(string identityUser, int govId, int dirId, int subId)
        {
            return await _context.Set<ApplicationUser>().Where(i => i.UserId == identityUser
            || i.GovernorateId == govId
            || i.DirectorateId == dirId
            || i.SubDirectorateId == subId
            )
                .OrderByDescending(d => d.CreatedDate)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<ApplicationUser> GetByIdAsync(string id) => await _context.Set<ApplicationUser>()
            .Include(g => g.Governorate)
            .Include(d => d.Directorate)
            .Include(su => su.SubDirectorate)
            .Include(r => r.UserRoles)
            .FirstOrDefaultAsync(n => n.Id == id);

        public async Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(string id, EditUserViewModel entity)
        {
            var updatedUser = await _userManager.FindByIdAsync(id);
            var roleId = await _userManager.GetRolesAsync(updatedUser);
            if (updatedUser == null)
                return;
            else
            {
                updatedUser.Id = entity.Id;
                updatedUser.FullName = entity.FullName;
                updatedUser.PhoneNumber = entity.PhoneNumber;
                updatedUser.ProfilePicture = entity.ProfilePicture;
                updatedUser.IdentityNumber = entity.IdentityNumber;
                updatedUser.GovernorateId = entity.GovernorateId;
                updatedUser.DirectorateId = entity.DirectorateId;
                updatedUser.SubDirectorateId = entity.SubDirectorateId;
                updatedUser.RoleId = entity.RoleId;
                updatedUser.CreatedDate = DateTime.Now;
                updatedUser.DateOfBirth = entity.DateOfBirth;

                await _userManager.UpdateAsync(updatedUser);

                if (entity.RoleId == 1)
                {
                    await _userManager.RemoveFromRolesAsync(updatedUser, roleId);
                    await _userManager.AddToRoleAsync(updatedUser, UserRoles.AdminGeneralFederation);
                }
                else if (entity.RoleId == 2)
                {
                    await _userManager.RemoveFromRolesAsync(updatedUser, roleId);
                    await _userManager.AddToRoleAsync(updatedUser, UserRoles.AdminGovernorate);
                }
                else if (entity.RoleId == 3)
                {
                    await _userManager.RemoveFromRolesAsync(updatedUser, roleId);
                    await _userManager.AddToRoleAsync(updatedUser, UserRoles.AdminDirectorate);
                }
                else if (entity.RoleId == 4)
                {
                    await _userManager.RemoveFromRolesAsync(updatedUser, roleId);
                    await _userManager.AddToRoleAsync(updatedUser, UserRoles.AdminSubDirectorate);
                }
                else if (entity.RoleId == 5)
                {
                    await _userManager.RemoveFromRolesAsync(updatedUser, roleId);
                    await _userManager.AddToRoleAsync(updatedUser, UserRoles.Beneficiarie);
                }

                //Change password 
                //await _userManager.RemovePasswordAsync(updatedUser);
                //await _userManager.AddPasswordAsync(updatedUser, entity.Password);

            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(string id, EditUserViewModel entity, string CurrentUserLoginId)
        {
            var currentuser = _userManager.Users.First(u => u.Id == CurrentUserLoginId);
            var updatedUser = await _userManager.FindByIdAsync(id);
            var roleId = await _userManager.GetRolesAsync(updatedUser);
            if (updatedUser == null)
                return;
            else
            {

                updatedUser.PhoneNumber = entity.PhoneNumber;
                updatedUser.IsBlocked = entity.IsBlocked;
                updatedUser.EmailConfirmed = entity.IsBlocked;
                updatedUser.CreatedDate = DateTime.Now;
                await _userManager.UpdateAsync(updatedUser);
                //Change password 
                //await _userManager.RemovePasswordAsync(updatedUser);
                //await _userManager.AddPasswordAsync(updatedUser, entity.Password);

            }

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllBenefAsync()
        {
            return await _context.Set<ApplicationUser>().Where(b => b.RoleId == 5)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllBenefAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public IQueryable<ApplicationUser> GetAllUserBlockedAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        IQueryable<UserViewModels> IUserService.Search(string term)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(string id)
        {
            try
            {
                var userToDelete = await _context.Users.FindAsync(id);
                if (userToDelete == null)
                {
                    return null;
                }

                var roleId = await _userManager.GetRolesAsync(userToDelete);
                if (await _context.UserRoles.AnyAsync(x => x.UserId == id && x.RoleId == UserRoles.AdminGeneralFederation))
                {
                    return "لا يمكن حذف هذا المستخدم";
                }

                await _userManager.RemoveFromRolesAsync(userToDelete, roleId);
                await _userManager.DeleteAsync(userToDelete);
                await _context.SaveChangesAsync();

                var userRolesToDelete = _context.UserRoles.Where(x => x.UserId == id);
                _context.UserRoles.RemoveRange(userRolesToDelete);
                await _context.SaveChangesAsync();

                return userToDelete.UserName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<List<ApplicationUser>> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            var data = await GetData();
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count;
        }

        private async Task<List<ApplicationUser>> GetData()
        {
            var json = await File.ReadAllTextAsync(Path.Combine(_hostingEnvironment.ContentRootPath, "Data", "paging.json"));
            return JsonConvert.DeserializeObject<List<ApplicationUser>>(json);
        }


    }
}
