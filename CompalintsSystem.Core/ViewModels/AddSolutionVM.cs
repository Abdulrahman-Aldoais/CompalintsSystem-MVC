using System.ComponentModel.DataAnnotations;

namespace CompalintsSystem.Core.ViewModels
{
    public class AddSolutionVM
    {
        public int UploadsComplainteId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string ContentSolution { get; set; }
    }
}
