using CompalintsSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompalintsSystem.EF.Configuration
{
    public class SubConfigration : IEntityTypeConfiguration<SubDirectorate>
    {
        public void Configure(EntityTypeBuilder<SubDirectorate> builder)
        {
            builder.HasData(
                    new SubDirectorate
                    {
                        Id = 1,
                        Name = " القفاعة",
                        DirectorateId = 1,
                    },
                      new SubDirectorate
                      {
                          Id = 2,
                          Name = " المخلاف",
                          DirectorateId = 1,
                      },
                        new SubDirectorate
                        {
                            Id = 3,
                            Name = " بني سعد",
                            DirectorateId = 3,
                        },
                        new SubDirectorate
                        {
                            Id = 4,
                            Name = " الاحبوب",
                            DirectorateId = 4,
                        },
                         new SubDirectorate
                         {
                             Id = 5,
                             Name = "غوبر",
                             DirectorateId = 4,
                         }


                );
        }
    }
}
