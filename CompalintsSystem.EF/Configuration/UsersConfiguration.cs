using CompalintsSystem.Core;
using CompalintsSystem.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Configuration
{
    public class UsersConfiguration
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string IdentityAdmin = "000243124111";

                var adminUser = await userManager.FindByEmailAsync(IdentityAdmin);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "عبدالرحمن علي سرحان الدعيس ",
                        IdentityNumber = IdentityAdmin,
                        Email = IdentityAdmin,
                        UserName = IdentityAdmin,
                        PhoneNumber = "775115810",
                        GovernorateId = 2,
                        DirectorateId = 1,
                        SubDirectorateId = 1,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        CreatedDate = DateTime.Now,
                        RoleId = 1,

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.AdminGeneralFederation);
                }


                string IdentityUser = "000243124222";

                var appUser = await userManager.FindByEmailAsync(IdentityUser);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = " سعيد علي احمد",
                        Email = IdentityUser,
                        UserName = IdentityUser,
                        IdentityNumber = IdentityUser,
                        PhoneNumber = "773453534",
                        GovernorateId = 2,
                        DirectorateId = 1,
                        SubDirectorateId = 2,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        CreatedDate = DateTime.Now,
                        RoleId = 5,
                    };
                    await userManager.CreateAsync(newAppUser, "B@ww11");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Beneficiarie);
                }
            }
        }

    }
}
