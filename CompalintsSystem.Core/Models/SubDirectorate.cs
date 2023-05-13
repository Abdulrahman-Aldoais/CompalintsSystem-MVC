using CompalintsSystem.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompalintsSystem.Core.Models
{
    public class SubDirectorate : IEntityBase
    {


        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]
        public virtual Directorate Directorate { get; set; }

        //RelationShipes noe to many
        //public virtual ICollection<Village> Villages { get; set; }
        public virtual ICollection<UsersCommunication> UsersCommunications { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        //public virtual List<Beneficiarie> Beneficiaries { get; set; }
        public virtual ICollection<UploadsComplainte> UploadsComplaintes { get; set; }


    }
}
