using CompalintsSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class UploadsComplainte : IEntityBase
    {
        public UploadsComplainte()
        {
            UploadDate = DateTime.Now;
        }
        public int Id { set; get; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TitleComplaint { get; set; }

        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public virtual int TypeComplaintId { get; set; }
        [ForeignKey("TypeComplaintId")]
        public virtual TypeComplaint TypeComplaint { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string DescComplaint { get; set; }
        public int? SocietyId { get; set; }
        public virtual Society Society { get; set; }
        public int StatusCompalintId { get; set; } = 1;
        public virtual StatusCompalint StatusCompalint { get; set; }
        public int StagesComplaintId { get; set; } = 1;
        public virtual StagesComplaint StagesComplaint { get; set; }
        public string PropBeneficiarie { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]
        public virtual int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]

        public virtual int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]

        public virtual Directorate Directorate { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]

        public virtual int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]

        public virtual SubDirectorate SubDirectorate { get; set; }

        public virtual ICollection<Compalints_Solution> Compalints_Solutions { get; set; }
        public virtual ICollection<ComplaintsRejected> ComplaintsRejecteds { get; set; }
        public virtual ICollection<UpComplaintCause> ComplaintsUp { get; set; }

        public string UserId { get; set; }
        public string UserRoleName { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public decimal Size { get; set; }
        public string ContentType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }

    }
}
