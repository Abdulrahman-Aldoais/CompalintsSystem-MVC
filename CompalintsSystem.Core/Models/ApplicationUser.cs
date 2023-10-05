using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class ApplicationUser : IdentityUser
    {


        public string FullName { get; set; }

        public string IdentityNumber { get; set; }

        public string PhoneNumber { get; set; } = "";

        public virtual int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }

        public virtual int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]
        public virtual Directorate Directorate { get; set; }

        public virtual int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]
        public virtual SubDirectorate SubDirectorate { get; set; }
        public virtual ICollection<Compalints_Solution> Compalints_Solutions { get; set; }
        public virtual ICollection<ComplaintsRejected> ComplaintsRejecteds { get; set; }

        public int? SocietyId { get; set; }
        public virtual Society Societies { get; set; }
        //public byte[] ProfilePicture { get; set; }
        //[Display(Name = "Image User")]
        [Column(TypeName = "varchar(250)")]
        public string ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        public string UserId { get; set; }
        public string originatorName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public int RoleId { get; set; }
        [NotMapped]
        public string RoleName { get; set; }
        public virtual ICollection<UsersCommunication> UsersCommunications { get; set; }
        public virtual ICollection<UploadsComplainte> UploadsComplaintes { get; set; }
        public virtual ICollection<IdentityRole> UserRoles { get; set; }


    }


}



