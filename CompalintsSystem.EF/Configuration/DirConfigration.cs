using CompalintsSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompalintsSystem.EF.Configuration
{
    public class DirConfigration : IEntityTypeConfiguration<Directorate>
    {


        public void Configure(EntityTypeBuilder<Directorate> builder)
        {
            builder.HasData(
                    new Directorate
                    {
                        Id = 1,
                        Name = "شرعب السلام",
                        GovernorateId = 2,
                    },
                    new Directorate
                    {
                        Id = 2,
                        Name = "شرعب الرونة",
                        GovernorateId = 2,

                    },
                     new Directorate
                     {
                         Id = 3,
                         Name = "همدان",
                         GovernorateId = 1,

                     },
                      new Directorate
                      {
                          Id = 4,
                          Name = "الحيمة",
                          GovernorateId = 1,

                      }
                );
        }




    }
}
