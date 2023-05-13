using CompalintsSystem.Core.Models;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels
{
    public class SelectDataCommuncationDropdownsVM
    {
        public SelectDataCommuncationDropdownsVM()
        {
            ApplicationUsers = new List<ApplicationUser>();
            TypeCommunications = new List<TypeCommunication>();
        }

        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<TypeCommunication> TypeCommunications { get; set; }
    }
}
