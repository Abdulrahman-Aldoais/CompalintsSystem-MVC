using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.EF.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Repositories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppCompalintsContextDB _context;

        public CategoryService(AppCompalintsContextDB context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TypeComplaint>> GetAllGategoryCompAsync() => await _context.TypeComplaints.ToListAsync();
        public async Task<IEnumerable<TypeCommunication>> GetAllGategoryCommAsync() => await _context.TypeCommunications.ToListAsync();

        //public async Task<TypeComplaint> GetByIdAsync(string id) => await _context.Set<TypeComplaint>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task AddCategoruComm(TypeCommunication entity)
        {
            await _context.TypeCommunications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddCategoruComp(TypeComplaint entity)
        {
            await _context.TypeComplaints.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TypeComplaint> GetByIdAsync(int id) => await _context.TypeComplaints.FirstOrDefaultAsync(n => n.Id == id);

        public async Task<TypeCommunication> GetCommunicationByIdAsync(int id) => await _context.TypeCommunications.FirstOrDefaultAsync(n => n.Id == id);


        public async Task DeleteAsync(int id)
        {
            var selectedCategory = await _context.TypeComplaints.FirstOrDefaultAsync(n => n.Id == id);
            if (selectedCategory != null)
            {
                _context.TypeComplaints.Remove(selectedCategory);
                await _context.SaveChangesAsync();
            }


        }

        public async Task DeleteCommAsync(int id)
        {
            var selectedCategory = await _context.TypeCommunications.FirstOrDefaultAsync(n => n.Id == id);
            if (selectedCategory != null)
            {
                _context.TypeCommunications.Remove(selectedCategory);
                await _context.SaveChangesAsync();
            }


        }



        public async Task UpdateAsync(int id, TypeComplaint entity)
        {
            EntityEntry entityEntry = _context.Entry<TypeComplaint>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues()
        {
            var response = new SelectDataDropdownsVM()
            {

                StatusCompalints = await _context.StatusCompalints.OrderBy(n => n.Name).ToListAsync(),
                TypeComplaints = await _context.TypeComplaints.OrderBy(n => n.Type).ToListAsync(),

            };

            return response;

        }

        public async Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int SubDirctoty)
        {
            var response = new SelectDataCommuncationDropdownsVM()
            {
                ApplicationUsers = await _context.Users.OrderBy(n => n.FullName).Where(r => r.RoleId != 5 && r.RoleId != 1).ToListAsync(),
                TypeCommunications = await _context.TypeCommunications.OrderBy(n => n.Type).ToListAsync(),

            };

            return response;

        }
    }
}
