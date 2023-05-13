
using CompalintsSystem.Core.Models;
using CompalintsSystem.Core.ViewModels;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels
{
    public class ProvideSolutionsVM
    {
        public UploadsComplainte compalint { get; set; }
        public IEnumerable<Compalints_Solution> Compalints_SolutionList { get; set; }
        public Compalints_Solution CompalintsSolution { get; set; }
        public AddSolutionVM AddSolution { get; set; }
        public IEnumerable<ComplaintsRejected> ComplaintsRejectedList { get; set; }
        public ComplaintsRejectedVM RejectedComplaintVM { get; set; }
        public UpComplaintVM UpComplaint { get; set; }
        public IEnumerable<UpComplaintCause> UpComplaintCauseList { get; set; }
        public ComplaintsUpVM UpComplaintViewModel { get; set; }
    }
}
