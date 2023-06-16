using CompalintsSystem.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompalintsSystem.EF.DataBase
{
    public class AppCompalintsContextDB : IdentityDbContext<ApplicationUser>
    {
        public AppCompalintsContextDB(DbContextOptions<AppCompalintsContextDB> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.HasDefaultSchema("notdbo");

            modelBuilder.HasDefaultSchema("Identity");


            modelBuilder.Entity<UploadsComplainte>()
               .Property(u => u.Size)
               .HasColumnType("decimal(18, 4)");


            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<ApplicationUser>(c =>
            {
                c.HasOne(e => e.Governorate)
                .WithMany(e => e.Users)
                .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(e => e.Directorate)
                  .WithMany(e => e.Users)
                  .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(e => e.SubDirectorate)
              .WithMany(e => e.Users)
              .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<UploadsComplainte>(u =>
            {
                u.HasOne(e => e.Governorate)
                  .WithMany(e => e.UploadsComplaintes)
                  .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.Directorate)
                .WithMany(e => e.UploadsComplaintes)
                .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.SubDirectorate)
                .WithMany(e => e.UploadsComplaintes)
                .OnDelete(DeleteBehavior.Restrict);

                //u.HasOne(e => e.TypeComplaint)
                //.WithMany(e => e.UploadsComplaintes)
                //.OnDelete(DeleteBehavior.Restrict);




            });

            //modelBuilder.Entity<TypeComplaint>(u =>
            //{
            //    u.HasMany(e => e.UploadsComplaintes)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Restrict);
            //});

            modelBuilder.Entity<Compalints_Solution>(u =>
            {
                u.HasOne(e => e.CompalintsHasSolution)
                .WithMany(e => e.Compalints_Solutions)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<UsersCommunication>(u =>
            {
                u.HasOne(e => e.Governorate)
                 .WithMany(e => e.UsersCommunications)
                 .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.Directorate)
                 .WithMany(e => e.UsersCommunications)
                 .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.SubDirectorate)
                 .WithMany(e => e.UsersCommunications)
                 .OnDelete(DeleteBehavior.Restrict);

            });

        }


        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<TypeComplaint> TypeComplaints { get; set; }
        public DbSet<TypeCommunication> TypeCommunications { get; set; }
        public DbSet<UploadsComplainte> UploadsComplaintes { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public DbSet<SubDirectorate> SubDirectorates { get; set; }
        //public DbSet<Village> Villages { get; set; }
        //public DbSet<LimitationOrder> LimitationOrders { get; set; }
        public DbSet<UsersCommunication> UsersCommunications { get; set; }
        public DbSet<Compalints_Solution> Compalints_Solutions { get; set; }
        public DbSet<ComplaintsRejected> ComplaintsRejecteds { get; set; }
        public DbSet<UpComplaintCause> UpComplaintCauses { get; set; }
        public DbSet<Society> Societys { get; set; }
        public DbSet<StagesComplaint> StagesComplaints { get; set; }
        public DbSet<StatusCompalint> StatusCompalints { get; set; }
        public DbSet<Proposal> Proposals { get; set; }


    }

}
