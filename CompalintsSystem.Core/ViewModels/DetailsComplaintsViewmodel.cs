using CompalintsSystem.Core.Models;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels
{
    public class DetailsComplaintsViewmodel
    {
        public UploadsComplainte compalint { get; set; }

        public IEnumerable<Compalints_Solution> Compalints_SolutionList { get; set; }
    }
}
