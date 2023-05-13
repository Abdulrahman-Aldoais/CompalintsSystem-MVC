using CompalintsSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CompalintsSystem.EF.Configuration
{
    public class TypeCommuncationConfiguration : IEntityTypeConfiguration<TypeCommunication>
    {
        public void Configure(EntityTypeBuilder<TypeCommunication> builder)
        {
            builder.HasData(
                    new TypeCommunication
                    {
                        Id = 1,
                        Type = "تماطل",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,
                    },
                    new TypeCommunication
                    {
                        //Id = Guid.NewGuid().ToString(),
                        Id = 2,
                        Type = "تلاعب بالحلول",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,

                    }
                );
        }


    }

}
