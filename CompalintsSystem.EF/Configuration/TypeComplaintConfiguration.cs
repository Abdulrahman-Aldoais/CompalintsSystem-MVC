using CompalintsSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CompalintsSystem.EF.Configuration
{
    public class TypeComplaintConfiguration : IEntityTypeConfiguration<TypeComplaint>
    {
        public void Configure(EntityTypeBuilder<TypeComplaint> builder)
        {
            builder.HasData(
                    new TypeComplaint
                    {
                        //Id = Guid.NewGuid().ToString(),
                        Id = 1,
                        Type = "زراعية",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,
                    },
                    new TypeComplaint
                    {
                        Id = 2,
                        Type = "فساد",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,

                    }
                );
        }


    }

}
