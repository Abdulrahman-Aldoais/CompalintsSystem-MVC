using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.Interfaces
{
    public interface IUserService
    {
        public string Error { get; set; }
        public int returntype { get; set; }
        Task<IEnumerable<ApplicationUser>> GetAllAsync(string IdentityUser, int gorId, int dirId, int subId);
        Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task<IEnumerable<ApplicationUser>> GetAllBenefAsync();
        Task<IEnumerable<ApplicationUser>> GetAllBenefAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task AddBenefAsync(AddUserViewModel entity, string originatorName, string CurrentUserLoginId);
        Task AddUserAsync(AddUserViewModel entity, string originatorName, string UserId);
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task UpdateAsync(string id, EditUserViewModel entity);
        Task UpdateAsync(string id, EditUserViewModel entity, string CurrentUserLoginId);
        IQueryable<ApplicationUser> GetAllUserBlockedAsync(string byuserId);
        IQueryable<ApplicationUser> GetAllUserBlockedAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task<ApplicationUser> GetUserByIdAsync(string UserId);
        IQueryable<UserViewModels> Search(string term);
        Task<int> UserRegistrationCountAsync();
        Task<OperationResult> TogelBlockUserAsync(string Id);
        Task<int> UserRegistrationCountAsync(int month);
        Task DeleteAsync(string Id);

        Task<List<ApplicationUser>> GetPaginatedResult(int currentPage, int pageSize = 10);
        Task<int> GetCount();

    }
}
