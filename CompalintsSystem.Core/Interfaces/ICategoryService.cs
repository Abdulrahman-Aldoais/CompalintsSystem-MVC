using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<TypeComplaint> GetByIdAsync(int Id);
        Task<TypeCommunication> GetCommunicationByIdAsync(int Id);
        Task UpdateAsync(int Id, TypeComplaint entity);
        Task DeleteAsync(int Id);
        Task DeleteCommAsync(int Id);
        Task AddCategoruComp(TypeComplaint entity);
        Task AddCategoruComm(TypeCommunication entity);
        Task<IEnumerable<TypeComplaint>> GetAllGategoryCompAsync();
        Task<IEnumerable<TypeCommunication>> GetAllGategoryCommAsync();
        Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues();
        Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int SubDirctoty);
    }
}
