using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.ViewModels
{
    public class AddTypeComplaintVM
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الصنف ")]
        public string Type { get; set; }
        public string UserId{ get; set; }

        public string UsersNameAddType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
