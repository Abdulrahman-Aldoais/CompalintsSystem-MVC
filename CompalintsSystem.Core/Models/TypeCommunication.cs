using CompalintsSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class TypeCommunication : IEntityBase
    {
        public TypeCommunication()
        {
            //Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الصنف ")]
        public string Type { get; set; }
        public string UserId { get; set; }
        public string UsersNameAddType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual ICollection<UsersCommunication> UsersCommunications { get; set; }

    }
}
