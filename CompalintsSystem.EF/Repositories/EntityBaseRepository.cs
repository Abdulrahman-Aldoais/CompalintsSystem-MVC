using AutoMapper;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppCompalintsContextDB _context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public EntityBaseRepository(
            AppCompalintsContextDB context,
            IMapper mapper,
            IWebHostEnvironment env,
            UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager
            )
        {
            _context = context;
            this.mapper = mapper;
            this.env = env;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public string Error { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int returntype { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties)
        //هذه الدالة للحصول على كافة عناصر الجدول وتضمين الجداول المرتبطه بها
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();
        }



        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> conditional,
            params Expression<Func<T, object>>[] includeproperties)
        //هذه الدالة للحصول على كافة عناصر مع وجود
        //شرط معين وايضا تضمين الجداول المرتبطه بها
        {
            IQueryable<T> query = _context.Set<T>().Where(conditional);
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();
        }

        //هذه الدالة للحصول على كافة عناصر مع وجود
        //شرط معين وترتيب العناصر وايضا تضمين الجداول المرتبطه بها
        public async Task<IEnumerable<T>> GetAllByOrderAsync(
             Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending,
            params Expression<Func<T, object>>[] includeproperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return await query.ToListAsync();
        }



        // تعريف وظيفة Generics للبحث في قاعدة بيانات Entity Framework بناءً على شرط معين وترتيب النتائج حسب خيارات الترتيب
        //public async Task<IEnumerable<T>> GetByCondationAndOrderAsync(
        //    Expression<Func<T, bool>> conditional, // شرط البحث
        //    Expression<Func<T, object>> orderBy = null, // تحديد العمود الذي سيتم ترتيب النتائج بناءً عليه
        //    string orderByDirection = OrderBy.Ascending, // تحديد ترتيب الترتيب (تصاعدي / تنازلي)
        //    params Expression<Func<T, object>>[] includeproperties) // تحميل العلاقات الفرعية
        //{
        //    IQueryable<T> query = _context.Set<T>().Where(conditional); // إنشاء كائن IQueryable وتطبيق الشرط الممرر
        //    query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty)); // تضمين العلاقات الفرعية الممررة باستخدام Aggregate و Include
        //    if (orderBy != null) // إذا تم تمرير معامل orderBy
        //    {
        //        if (orderByDirection == OrderBy.Ascending) // إذا كان ترتيب الترتيب تصاعدياً
        //            query = query.OrderBy(orderBy); // ترتيب النتائج باستخدام OrderBy
        //        else
        //            query = query.OrderByDescending(orderBy); // ترتيب النتائج باستخدام OrderByDescending
        //    }
        //    return await query.ToListAsync(); // إرجاع النتائج كـ IEnumerable باستخدام ToListAsync
        //}
        public async Task<IEnumerable<T>> GetByCondationAndOrderAsync(
    Expression<Func<T, bool>> conditional,
    Expression<Func<T, object>> orderBy = null,
    string orderByDirection = OrderBy.Ascending,
    params Expression<Func<T, object>>[] includeproperties)
        {
            IQueryable<T> query = _context.Set<T>().Where(conditional);
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }



        public Task<T> FaindAsync(Expression<Func<T, bool>> conditional, params Expression<Func<T, object>>[] includeproperties)
        {
            IQueryable<T> query = _context.Set<T>().Where(conditional); // إنشاء كائن IQueryable وتطبيق الشرط الممرر
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty)); // تضمين العلاقات الفرعية الممررة باستخدام Aggregate و Include
            return query.SingleOrDefaultAsync(); // البحث عن عنصر واحد وإرجاعه باستخدام SingleOrDefaultAsync
        }


        public int Count()
        {
            return _context.Set<T>().Count();
        }


        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }


        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }



        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task AddUser(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);




        public async Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int subDirctoty, int directoryId, int governorateId, string role, string roleId)
        {
            if (role == "AdminGovernorate")
            {

                var responseGov = new SelectDataCommuncationDropdownsVM
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



                return responseGov;
            }
            else if (role == "AdminDirectorate")
            {
                var responseDir = new SelectDataCommuncationDropdownsVM
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
                  .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                  .Where(x => x.UserRole.RoleId != roleId)
                  .OrderBy(x => x.User.FullName)
                  .Select(x => x.User)
                  .ToListAsync(),

                TypeCommunications = await _context.TypeCommunications
                 .OrderBy(tc => tc.Type)
                 .ToListAsync()
            };

            return responseAdmin;
        }



        public async Task AddNewSolutionCompalintAsync(string id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }



        public async Task UpdateAsync(string id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        public async Task DeleteAsync(int id)
        {
            var entity = _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(await entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public IList<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<SelectDataCommuncationDropdownsVM> GetAndAddCommunicationDropdownsValuesForBeneficaie(int subDirctoty, int directoryId, int governorateId, string role, string roleId)
        {
            var responseSub = new SelectDataCommuncationDropdownsVM
            {

                ApplicationUsers = await _context.Users
                   .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { User = u, UserRole = ur })
                   .Where(x => x.UserRole.RoleId == "901d057e-c4d6-41e1-8616-fc74da8e16da"//  عرض جميع المستخدمين في العزلة التابعة 
                       && x.User.SubDirectorateId == subDirctoty)
                   .OrderBy(x => x.User.FullName)
                   .Select(x => x.User)
                   .ToListAsync(),

                TypeCommunications = await _context.TypeCommunications
                  .OrderBy(tc => tc.Type)
                  .ToListAsync()
            };

            return responseSub;
        }
    }
}
