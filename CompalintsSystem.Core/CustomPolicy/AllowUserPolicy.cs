using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Identity.CustomPolicy
{
    public class AllowUserPolicy : IAuthorizationRequirement
    {
        public string[] AllowUsers { get; set; }

        public AllowUserPolicy(params string[] users)
        {
            AllowUsers = users;
        }
    }
}