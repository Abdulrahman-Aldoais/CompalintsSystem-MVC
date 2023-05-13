using CompalintsSystem.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CompalintsSystem.EF.Configuration
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminGeneralFederation,
                     NormalizedName = UserRoles.AdminGeneralFederation.ToUpper(),

                 },
                 new IdentityRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminGovernorate,
                     NormalizedName = UserRoles.AdminGovernorate.ToUpper(),

                 }
                 ,
                 new IdentityRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminDirectorate,
                     NormalizedName = UserRoles.AdminDirectorate.ToUpper(),


                 },
                 new IdentityRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminSubDirectorate,
                     NormalizedName = UserRoles.AdminSubDirectorate.ToUpper(),

                 },

                  new IdentityRole
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = UserRoles.Beneficiarie,
                      NormalizedName = UserRoles.Beneficiarie.ToUpper(),

                  }

            );
        }
    }
}