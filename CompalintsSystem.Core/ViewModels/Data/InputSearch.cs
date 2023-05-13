using System.ComponentModel.DataAnnotations;

namespace CompalintsSystem.Core.ViewModels.Data
{
    public class InputSearch
    {
        [MinLength(3)]
        [Required]
        public string Term { get; set; }
    }
}
