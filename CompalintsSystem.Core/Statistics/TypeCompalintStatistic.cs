using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Statistics
{
    public class TypeCompalintStatistic
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string TotalCount { get; set; }
        public double TypeComp { get; set; }
    }
}
