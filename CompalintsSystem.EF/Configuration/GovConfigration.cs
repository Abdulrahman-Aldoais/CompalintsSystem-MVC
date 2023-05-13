using CompalintsSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompalintsSystem.EF.Configuration
{
    public class GovConfigration : IEntityTypeConfiguration<Governorate>
    {


        public void Configure(EntityTypeBuilder<Governorate> builder)
        {


            builder.HasData(
                    new Governorate
                    {
                        Id = 1,
                        Name = "صنعاء",
                    },
                    new Governorate
                    {
                        Id = 2,
                        Name = " تعز",
                    },
                     new Governorate
                     {
                         Id = 3,
                         Name = "الحديدة",
                     }
                );
        }


    }

}