using System;
using System.ComponentModel.DataAnnotations;

namespace CompalintsSystem.Core.ViewModels
{
    public class AddCommunicationVM
    {

        public int Id { get; set; }
        public int BenfId { get; set; }
        public string BenfName { get; set; }
        public string BenfPhoneNumber { get; set; }
        public int GovernorateId { get; set; }

        public int DirectorateId { get; set; }

        public int SubDirectorateId { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بإختيار نوع البلاغ ")]
        public string TypeCommuncationId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "يجب ان تقوم بكتابة العنوان  ")]
        public string Titile { get; set; }
        public string reason { get; set; }

    }
}
