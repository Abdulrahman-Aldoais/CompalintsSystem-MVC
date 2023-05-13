using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using System;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityBaseRepository<UploadsComplainte> Compalinte { get; }
        ICompalintRepository CompalinteRepo { get; }
        IUserService User { get; }
        Task<int> Complete();
    }
}
