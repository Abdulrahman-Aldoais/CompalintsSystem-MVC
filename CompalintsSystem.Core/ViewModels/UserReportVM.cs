using System;

namespace CompalintsSystem.Core.ViewModels
{
    public class UserReportVM
    {
        public string UserId{ get; set; }
        public string FullName { get; set; }
        public string PhonNumber { get; set; }
        public string Role { get; set; }
        public int TotlSolutionComp { get; set; }
        public int TotlRejectComp { get; set; }
        public int TotlAcceptSolution { get; set; }
        public string Gov { get; set; }
        public string Dir { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
