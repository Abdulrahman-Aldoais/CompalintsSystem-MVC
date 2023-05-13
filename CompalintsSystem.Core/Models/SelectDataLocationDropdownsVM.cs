using System.Collections.Generic;

namespace CompalintsSystem.Core.Models
{
    public class SelectDataLocationDropdownsVM
    {
        public SelectDataLocationDropdownsVM()
        {

            Governorates = new List<Governorate>();
            Directorates = new List<Directorate>();
            SubDirectorates = new List<SubDirectorate>();
        }


        public List<Governorate> Governorates { get; set; }
        public List<Directorate> Directorates { get; set; }
        public List<SubDirectorate> SubDirectorates { get; set; }
    }
}
