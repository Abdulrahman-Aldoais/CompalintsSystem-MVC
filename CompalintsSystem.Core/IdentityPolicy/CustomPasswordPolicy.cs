using CompalintsSystem.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompalintsSystem.Core.IdentityPolicy
{
    public class CustomPasswordPolicy : PasswordValidator<ApplicationUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Description = "لا يجب ان تكون كلمة السر نفس اسم المستخدم"
                });
            }
            if (password.Contains("123"))
            {
                errors.Add(new IdentityError
                {
                    Description = "لا يجب ان تحتوى كلمة السر على 123 فقط"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
