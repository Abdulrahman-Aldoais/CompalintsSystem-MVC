using AutoMapper;
using CompalintsSystem;
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

        public async Task<IEnumerable<T>> GetByCondationAndOrderAsync(
        Expression<Func<T, bool>> conditional,
        Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending,
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
            IQueryable<T> query = _context.Set<T>().Where(conditional);
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return query.SingleOrDefaultAsync();
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



        public async Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int SubDirctoty)
        {
            var response = new SelectDataCommuncationDropdownsVM()
            {
                ApplicationUsers = await _context.Users.OrderBy(n => n.FullName).Where(r => r.RoleId != 5 && r.RoleId != 1).ToListAsync(),
                TypeCommunications = await _context.TypeCommunications.OrderBy(n => n.Type).ToListAsync(),

            };

            return response;
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


    }
}
