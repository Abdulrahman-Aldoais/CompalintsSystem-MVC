using ComplantSystem.Service.Helpers;
using System.Collections.Generic;

namespace ComplantSystem
{
    public static class Globals
    {
        public static List<RolesList> RolesLists { get; set; } = new List<RolesList>
        {
            new RolesList{ Id = 1 , Name = "مدير إتحاد عام"},
            new RolesList{ Id = 2 , Name = "مدير محافظة"},
            new RolesList{ Id = 3 , Name = "مدير مديريه"},
            new RolesList{ Id = 4 , Name = "مدير عزلة"},
            new RolesList{ Id = 5 , Name = "مزارع"}
        };
    }
}
