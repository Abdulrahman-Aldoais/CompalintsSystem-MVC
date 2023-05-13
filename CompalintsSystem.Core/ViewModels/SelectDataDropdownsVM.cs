
using CompalintsSystem.Core.Models;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels
{
    public class SelectDataDropdownsVM
    {
        public SelectDataDropdownsVM()
        {
            TypeComplaints = new List<TypeComplaint>();
            StatusCompalints = new List<StatusCompalint>();
        }

        public List<TypeComplaint> TypeComplaints { get; set; }
        public List<StatusCompalint> StatusCompalints { get; set; }
    }
}
