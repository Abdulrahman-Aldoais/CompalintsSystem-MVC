using CompalintsSystem.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class ComplaintsRejected : IEntityBase
    {
        //public ComplaintsRejected()
        //{
        //    //Id = Guid.NewGuid().ToString();
        //}
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UserRejectComplaint { get; set; }
        public int UploadsComplainteId { get; set; }
        [ForeignKey("UploadsComplainteId")]
        public virtual UploadsComplainte CompalintsRejected { get; set; }
        public string RejectedProvName { get; set; }
        public string RejectedUserProvIdentity { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الحل المقدم ")]
        public string reume { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSolution { get; set; } = DateTime.Now;




    }
}