using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Statistics
{
    public class UsersInStatistic
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string totalUsers { get; set; }
        public double Users { get; set; }
    }
}
