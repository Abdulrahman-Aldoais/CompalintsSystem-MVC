using CompalintsSystem.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class StatusCompalint : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        //RelationShipes one to many with UploadsComplainte and StatusCompalint
        public virtual ICollection<UploadsComplainte> UploadsComplainte { get; set; }
    }
}
