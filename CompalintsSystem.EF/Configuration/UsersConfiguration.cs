using CompalintsSystem.Core;
using CompalintsSystem.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompalintsSystem.EF.Configuration
{
    public class UsersConfiguration
    {


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var usersToCreate = new List<(ApplicationUser User, string RoleName)>
        {
            (new ApplicationUser
            {
                FullName = "عبدالرحمن علي سرحان الدعيس",
                IdentityNumber = "000243124111",
                Email = "000243124111",
                UserName = "000243124111",
                PhoneNumber = "775115810",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 1,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminGeneralFederation),
            (new ApplicationUser
            {
                FullName = "قناف عبدالخالق الدعيس",
                IdentityNumber = "023453253455",
                Email = "023453253455",
                UserName = "023453253455",
                PhoneNumber = "77883534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminGovernorate),
            (new ApplicationUser
            {
                FullName = "عبدالواحد الصوفي",
                IdentityNumber = "023453253454",
                Email = "023453253454",
                UserName = "023453253454",
                PhoneNumber = "77883534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminDirectorate),
            (new ApplicationUser
            {
                FullName = "عبدالجليل سرحان",
                IdentityNumber = "001024312444",
                Email = "001024312444",
                UserName = "001024312444",
                PhoneNumber = "77883534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminSubDirectorate),
            (new ApplicationUser
            {
                FullName = "سعيد علي احمد",
                IdentityNumber = "000243124222",
                Email = "000243124222",
                UserName = "000243124222",
                PhoneNumber = "773453534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminDirectorate),



            //======================================
            (new ApplicationUser
            {
                FullName = "صادق نعمان ",
                IdentityNumber = "000243124001",
                Email = "000243124001",
                UserName = "000243124001",
                PhoneNumber = "775115810",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 1,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminGovernorate),
            (new ApplicationUser
            {
                FullName = " داحش هزاع الدعيس",
                IdentityNumber = "023453253433",
                Email = "023453253433",
                UserName = "023453253433",
                PhoneNumber = "77883534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminGovernorate),
            (new ApplicationUser
            {
                FullName = "حمود الصوفي",
                IdentityNumber = "023453253422",
                Email = "023453253422",
                UserName = "023453253422",
                PhoneNumber = "77883534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminDirectorate),
            (new ApplicationUser
            {
                FullName = "وهبان حمود",
                IdentityNumber = "001024312455",
                Email = "001024312455",
                UserName = "001024312455",
                PhoneNumber = "77883534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminSubDirectorate),
            (new ApplicationUser
            {
                FullName = " علي احمد موسى",
                IdentityNumber = "000243124121",
                Email = "000243124121",
                UserName = "000243124121",
                PhoneNumber = "773453534",
                GovernorateId = 2,
                DirectorateId = 1,
                SubDirectorateId = 2,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminDirectorate),

            //==================================================
             (new ApplicationUser
            {
                FullName = "محمد على ",
                IdentityNumber = "000243124445",
                Email = "000243124445",
                UserName = "000243124445",
                PhoneNumber = "775115810",
                GovernorateId = 1,
                DirectorateId = 3,
                SubDirectorateId = 3,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminGeneralFederation),
            (new ApplicationUser
            {
                FullName = "إبراهيم الجبري",
                IdentityNumber = "023453253490",
                Email = "023453253490",
                UserName = "023453253490",
                PhoneNumber = "77883534",
                GovernorateId = 1,
                DirectorateId = 3,
                SubDirectorateId = 3,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminGovernorate),
            (new ApplicationUser
            {
                FullName = "مهاب الصوفي",
                IdentityNumber = "023453253499",
                Email = "023453253499",
                UserName = "023453253499",
                PhoneNumber = "77883534",
                GovernorateId = 1,
                DirectorateId = 4,
                SubDirectorateId = 4,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminDirectorate),
            (new ApplicationUser
            {
                FullName = "ناجي المهشمي",
                IdentityNumber = "001024312555",
                Email = "001024312555",
                UserName = "001024312555",
                PhoneNumber = "77883534",
                GovernorateId = 1,
                DirectorateId = 4,
                SubDirectorateId = 5,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminSubDirectorate),
            (new ApplicationUser
            {
                FullName = " علي وهبان",
                IdentityNumber = "000243124666",
                Email = "000243124666",
                UserName = "000243124666",
                PhoneNumber = "773453534",
                GovernorateId = 1,
                DirectorateId = 3,
                SubDirectorateId = 5,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
            }, UserRoles.AdminSubDirectorate),



        };

                foreach (var userData in usersToCreate)
                {
                    var (user, roleName) = userData;

                    var existingUser = await userManager.FindByEmailAsync(user.Email);
                    if (existingUser == null)
                    {
                        await userManager.CreateAsync(user, "Coding@1234?");

                        if (!await roleManager.RoleExistsAsync(roleName))
                        {
                            await roleManager.CreateAsync(new IdentityRole(roleName));
                        }

                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
        }

    }
}
