using CompalintsSystem.Core.Constants;
using CompalintsSystem.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplantSystem
{
    public class AdminClaimsService : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public AdminClaimsService(
        UserManager<ApplicationUser> userManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var isMinimumAge = user.DateOfBirth.AddYears(18) >= DateTime.Now;
            identity.AddClaim(new Claim(AdminClaims.isMinimumAge, isMinimumAge.ToString()));
            //identity.AddClaim(new Claim(AdminClaims.FullName, $"{user.FirstName} {user.LastName}"));

            foreach (var role in await UserManager.GetRolesAsync(user))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }
    }
}

