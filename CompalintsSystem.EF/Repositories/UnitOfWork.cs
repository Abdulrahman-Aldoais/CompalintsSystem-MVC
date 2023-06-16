using AutoMapper;
using CompalintsSystem.Core.Interfaces;
using CompalintsSystem.Core.Models;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppCompalintsContextDB _context { get; }
        public IMapper mapper { get; }
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public IWebHostEnvironment env { get; }
        public RoleManager<IdentityRole> roleManager { get; }

        public IHttpContextAccessor httpContextAccessor { get; }
        public IHostingEnvironment hostingEnvironment { get; }


        public IEntityBaseRepository<UploadsComplainte> Compalinte { get; private set; }
        public IUserService User { get; private set; }
        public ICompalintRepository CompalinteRepo { get; private set; }
        public UnitOfWork(
            AppCompalintsContextDB context,
            IMapper mapper, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment env,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor

            )
        {
            _context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.env = env;
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;


            Compalinte = new EntityBaseRepository<UploadsComplainte>(_context, mapper, env, userManager, signInManager);
            CompalinteRepo = new CompalintRepository(_context, mapper, env, userManager, signInManager);
            User = new UserService(_context, mapper, userManager, roleManager, signInManager, httpContextAccessor, hostingEnvironment);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

    }
}
