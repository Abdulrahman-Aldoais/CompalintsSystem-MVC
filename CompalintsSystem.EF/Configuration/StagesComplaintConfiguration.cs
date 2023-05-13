using CompalintsSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompalintsSystem.EF.Configuration
{
    public class StagesComplaintConfiguration : IEntityTypeConfiguration<StagesComplaint>
    {
        public void Configure(EntityTypeBuilder<StagesComplaint> builder)
        {
            builder.HasData(

                    new StagesComplaint
                    {
                        Id = 1,
                        Name = "العزلة",
                    },
                     new StagesComplaint
                     {
                         Id = 2,
                         Name = "المديرية",
                     },
                      new StagesComplaint
                      {
                          Id = 3,
                          Name = "المحافظة",
                      },
                       new StagesComplaint
                       {
                           Id = 4,
                           Name = "الإتحاد العام",
                       }
                );
        }


    }

}