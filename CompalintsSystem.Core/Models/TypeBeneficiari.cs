using CompalintsSystem.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class TypeBeneficiari : IEntityBase
    {
        //public TypeBeneficiari()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}

        public int Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Type { get; set; }

    }
}
