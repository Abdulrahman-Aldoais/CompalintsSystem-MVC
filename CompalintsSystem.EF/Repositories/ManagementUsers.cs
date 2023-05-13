using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.EF.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Repositories
{
    public class ManagementUsers : IManagementUsers
    {
        private readonly AppCompalintsContextDB _context;

        public ManagementUsers(AppCompalintsContextDB context)
        {
            _context = context;

        }



        public IQueryable<ApplicationUser> GetAllUsersAsync()
        {
            var result = _context.Users;
            return result;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(params Expression<Func<ApplicationUser, object>>[] includeproperties)
        {
            System.Linq.IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();
        }
    }
}
