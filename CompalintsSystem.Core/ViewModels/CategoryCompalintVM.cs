using System;

namespace CompalintsSystem.Core.ViewModels
{
    public class CategoryCompalintVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string UserId{ get; set; }
        public string UsersNameAddType { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}
