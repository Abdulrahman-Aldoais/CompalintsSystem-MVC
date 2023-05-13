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
        public string BenfId { get; set; }
        public string BenfName { get; set; }
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
        public string UserId { get; set; }
        //public string NameUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserName { get; set; }
        public virtual int TypeCommuncationId { get; set; }
        [ForeignKey("TypeCommuncationId")]
        public virtual TypeCommunication TypeCommunication { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Titile { get; set; }
        public string reason { get; set; }

    }
}