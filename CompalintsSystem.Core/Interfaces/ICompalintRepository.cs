using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.Interfaces
{
    public interface ICompalintRepository : IEntityBaseRepository<UploadsComplainte>
    {
        public string Error { get; set; }
        public int returntype { get; set; }
        IQueryable<UploadsComplainte> GetAll();
        Task<UploadsComplainte> FindAsync(int id);
        Task<UploadsComplainte> GetCompalintById(int id);
        IQueryable<UploadsComplainte> GetBy(string UserId);
        IQueryable<UploadsComplainte> GetBenfeficarieCompalintBy(string UserId);
        IQueryable<UsersCommunication> GetCommunicationBy(string UserId);
        IQueryable<UploadsComplainte> GetAllRejectedComplaints(string UserId);
        IQueryable<UploadsComplainte> GetAllResolvedComplaints(string UserId);
        //Task CreateAsync(InputCompmallintVM model);
        Task CreateAsync(InputCompmallintVM model);
        Task CreateCommuncationAsync(AddCommunicationVM model);
        Task GetAllGategoryCompAsync();
        Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues(int subDirctoty, int directoryId, int governorateId, string role, string roleId);
    }
}


