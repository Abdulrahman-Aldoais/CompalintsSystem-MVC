

using CompalintsSystem.Core.Models;
using System;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels
{
    public class TypeCompalintVM
    {
        public string Type { get; set; }
        public string UserId{ get; set; }

        public string UsersNameAddType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual ICollection<UploadsComplainte> UploadsComplainte { get; set; }
    }
}
