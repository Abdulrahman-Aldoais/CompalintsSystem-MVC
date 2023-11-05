using CompalintsSystem.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class UsersCommunication : IEntityBase
    {
        //public UsersCommunication()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}

        public int Id { get; set; }
        public string reportSubmitterId { get; set; }
        public virtual ApplicationUser reportSubmitter { get; set; }
        public string reportSubmitterName { get; set; }
        public string reporteeName { get; set; }
        public string BenfPhoneNumber { get; set; }
        public virtual int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }
        public virtual int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]
        public virtual Directorate Directorate { get; set; }
        public virtual int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]
        public virtual SubDirectorate SubDirectorate { get; set; }
        public virtual int TypeCommuncationId { get; set; }
        [ForeignKey("TypeCommuncationId")]
        public virtual TypeCommunication TypeCommunication { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Titile { get; set; }
        public string reason { get; set; }

    }
}